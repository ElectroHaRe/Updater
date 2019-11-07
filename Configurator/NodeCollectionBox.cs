using System;
using Updater.Base;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Updater.Configurator
{
    public partial class NodeCollectionBox : UserControl, IEnumerable<IPathNode>
    {
        public NodeCollectionBox()
        {
            InitializeComponent();
        }

        List<IPathNode> Nodes = new List<IPathNode>();

        private bool RemoveNode(IPathNode node)
        {
            int index = Nodes.IndexOf(node);

            if (index == -1)
                return false;

            Nodes.Remove(node);
            Controls.Remove(node as Control);
            RecalculateTopCountFrom(index);
            RecalculateScroll();

            return true;
        }

        private void RecalculateTop()
        {
            RecalculateTopCountFrom(0);
        }

        private void RecalculateTopCountFrom(int index)
        {
            for (int i = index; i < Nodes.Count; i++)
            {
                Control current = Nodes[i] as Control;

                if (i == 0)
                {
                    current.Top = current.Margin.Top;
                    continue;
                }

                Control last = Nodes[i - 1] as Control;
                current.Top = last.Bottom + last.Margin.Bottom + current.Margin.Top;
            }

            AddButton.Top = RemoveButton.Top = Nodes.Count == 0 ? AddButton.Margin.Top :
                (Nodes[Nodes.Count - 1] as Control).Bottom + (Nodes[Nodes.Count - 1] as Control).Margin.Bottom + AddButton.Margin.Top;
        }

        private void RecalculateScroll()
        {
            float factor = VScrollBar.Maximum == 0 ? 0 : (float)VScrollBar.Value / VScrollBar.Maximum; // множитель отнасительной позиции Value

            ChangeScrollPosition(0); // сбрасываем текущий скрол в 0

            VScrollBar.Maximum = Nodes.Count == 0 ? 0 : AddButton.Top + AddButton.Height + AddButton.Margin.Bottom; // Пересчитываем максимум, минимум = 0

            VScrollBar.Maximum = VScrollBar.Maximum > Height ? VScrollBar.Maximum - Height * 9 / 10 : 0; // Досчитываем максимум, учитывая высоту нашего бокса

            ChangeScrollPosition((int)(VScrollBar.Maximum * factor)); // возращаем скрол в сохранённую позицию
        }

        private void ChangeScrollPosition(int newValue)
        {
            newValue = newValue < 0 ? 0 : newValue > VScrollBar.Maximum ? VScrollBar.Maximum : newValue;

            OnScrollBarValueChanged(null, new ScrollEventArgs(ScrollEventType.ThumbPosition, VScrollBar.Value, newValue));
            VScrollBar.Value = newValue;
        }

        /// <summary>
        /// Заменяет NodeBox на NodePreviewBox и наоборот
        /// </summary>
        /// <param name="index">Индекс PathNode элемента в листе Nodes</param>
        private void ChangePathNodeControlState(int index)
        {
            if (index < 0 && index >= Nodes.Count)
                throw new IndexOutOfRangeException();

            var lastPathNode = Nodes[index] as Control;

            Control newPatnNode = lastPathNode is NodePreviewBox ? CreateNodeBox() as Control : CreateNodePreviewBox() as Control;

            ReplaceControlForPathNode(Nodes[index], newPatnNode);

            Controls.Remove(lastPathNode);
            Controls.Add(newPatnNode);
        }

        private NodeBox CreateNodeBox()
        {
            var temp = new NodeBox();

            temp.UpArrowClick += OnArrowClick;

            return temp;
        }

        private NodePreviewBox CreateNodePreviewBox()
        {
            var temp = new NodePreviewBox();

            temp.DownArrowClick += OnArrowClick;

            return temp;
        }

        private void ReplaceControlForPathNode(IPathNode last, Control newControl)
        {
            if (!(newControl is IPathNode))
                throw new ArgumentException("PathNode controls must be compatible with the IPathNode type.");

            int index = Nodes.IndexOf(last);

            if (index == -1)
                throw new ArgumentException("Replaceable PathNode is not in the collection.");

            (newControl as IPathNode).Source = last.Source ?? string.Empty;
            (newControl as IPathNode).Destination = last.Destination ?? string.Empty;
            (newControl as IPathNode).Description = last.Description ?? string.Empty;

            newControl.Width = (last as Control).Width;
            newControl.Left = (last as Control).Left;
            newControl.Top = (last as Control).Top;

            Nodes[index] = newControl as IPathNode;
        }

        public void AddPathNode(string sourcePath, string destinationPath, string description)
        {
            var nodeBox = CreateNodeBox();

            nodeBox.Left = nodeBox.Margin.Left;
            nodeBox.Width = Width - nodeBox.Left - nodeBox.Margin.Right;

            if (Nodes.Count == 0)
                RecalculateTop();
            else nodeBox.Top = (Nodes[Nodes.Count - 1] as Control).Bottom + (Nodes[Nodes.Count - 1] as Control).Margin.Bottom + nodeBox.Margin.Top;

            nodeBox.Description = description ?? string.Empty;
            nodeBox.Source = sourcePath ?? string.Empty;
            nodeBox.Destination = destinationPath ?? string.Empty;

            RemoveButton.Top = AddButton.Top = nodeBox.Bottom + nodeBox.Margin.Bottom;

            Nodes.Add(nodeBox);
            Controls.Add(nodeBox);

            RecalculateTopCountFrom(Nodes.Count - 1);
            RecalculateScroll();
        }

        public void AddPathNode(IPathNode pathNode)
        {
            AddPathNode(pathNode.Source, pathNode.Destination, pathNode.Description);
        }

        public void AddPathNodeList<T>(List<T> nodes) where T : IPathNode
        {
            AddPathNodeList(nodes.AsReadOnly());
        }

        public void AddPathNodeList<T>(System.Collections.ObjectModel.ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                AddPathNode(item);
            }
        }

        public void Clear()
        {
            foreach (var item in Nodes)
            {
                Controls.Remove(item as Control);
            }

            Nodes.Clear();

            RecalculateTop();
            RecalculateScroll();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IPathNode> GetPathNodeList()
        {
            return Nodes.AsReadOnly();
        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            AddPathNode("", "", "");
            RecalculateScroll();
        }

        private void OnAddButtonMouseEnter(object sender, EventArgs e)
        {
            AddButton.ForeColor = Color.Green;
        }

        private void AddButton_MouseLeave(object sender, EventArgs e)
        {
            AddButton.ForeColor = Color.Black;
        }

        private void RemoveButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveButton.ForeColor = Color.Red;
        }

        private void RemoveButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveButton.ForeColor = Color.Black;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (Nodes.Count > 0)
                RemoveNode(Nodes[Nodes.Count - 1]);
        }

        private void OnArrowClick(object sender, EventArgs e)
        {
            var temp = (sender as Control).Parent as IPathNode;
            int index = Nodes.IndexOf(temp);

            ChangePathNodeControlState(index);

            RecalculateTopCountFrom(index + 1);
            RecalculateScroll();
        }

        private void OnScrollBarValueChanged(object sender, ScrollEventArgs e)
        {
            foreach (Control item in Nodes)
            {
                item.Top -= e.NewValue - e.OldValue;
            }

            AddButton.Top -= e.NewValue - e.OldValue;
            RemoveButton.Top -= e.NewValue - e.OldValue;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            foreach (Control item in Nodes)
            {
                item.Width = Width - item.Margin.Left - item.Margin.Right;
                item.Left = item.Margin.Left;
            }

            AddButton.Left = Width / 2 + AddButton.Margin.Left;
            RemoveButton.Left = Width / 2 - RemoveButton.Margin.Left - RemoveButton.Width;

            VScrollBar.Left = Width - VScrollBar.Width;
            VScrollBar.Height = Height;
        }

        public IEnumerator<IPathNode> GetEnumerator()
        {
            return ((IEnumerable<IPathNode>)Nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IPathNode>)Nodes).GetEnumerator();
        }
    }
}
