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
            RecalculateScroll();
        }

        List<IPathNode> Nodes = new List<IPathNode>();

        private void RemoveNode(IPathNode node)
        {
            Nodes.Remove(node);
            Controls.Remove(node as Control);
            RecalculateTop();
            RecalculateScroll();
        }

        private void RecalculateTop()
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Control last = Nodes.Count > 1 && i > 0 ? Nodes[i - 1] as Control : null;
                Control current = Nodes[i] as Control;

                current.Top = last == null ? current.Margin.Top : last.Bottom + last.Margin.Bottom + current.Margin.Top;
            }

            AddButton.Top = RemoveButton.Top = Nodes.Count == 0 ? AddButton.Margin.Top : (Nodes[Nodes.Count - 1] as Control).Top + (Nodes[Nodes.Count - 1] as Control).Height
                + (Nodes[Nodes.Count - 1] as Control).Margin.Bottom + AddButton.Margin.Top;
        }

        private void RecalculateScroll()
        {
            RecalculateTop();

            int value = 0;
            float factor = 0;
            if (VScrollBar.Maximum != VScrollBar.Minimum)
                factor = (float)VScrollBar.Value / VScrollBar.Maximum;

            VScrollBar.Maximum = Nodes.Count == 0 ? 0 : AddButton.Top + AddButton.Height + AddButton.Margin.Bottom;

            if (VScrollBar.Maximum - VScrollBar.Minimum <= Height)
                VScrollBar.Maximum = 0;
            else
                VScrollBar.Maximum -= (int)(Height * 0.9f);


            value = (int)(VScrollBar.Maximum * factor);

            if (value < VScrollBar.Maximum)
            {
                VScrollBar.Value = (int)(VScrollBar.Maximum * factor);

                VScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.ThumbPosition, value));
            }
        }

        private NodeBox CreateNodeBox()
        {
            var nodeBox = new NodeBox();

            nodeBox.Width = Width - nodeBox.Margin.Left - nodeBox.Margin.Right;
            if (Nodes.Count > 0)
            {
                var lastBox = Nodes[Nodes.Count - 1] as Control;
                nodeBox.Top = lastBox.Top + lastBox.Height + lastBox.Margin.Bottom + nodeBox.Margin.Top;
                nodeBox.Left = lastBox.Left;
            }
            else
            {
                nodeBox.Top = nodeBox.Margin.Top;
                nodeBox.Left = nodeBox.Margin.Left;
            }

            nodeBox.UpArrowClick += OnUpArrowClick;

            Nodes.Add(nodeBox);
            Controls.Add(nodeBox);

            AddButton.Top = RemoveButton.Top = nodeBox.Top + nodeBox.Height + nodeBox.Margin.Bottom + AddButton.Margin.Top;

            return nodeBox;
        }

        public bool AddPathNode(string sourcePath, string destinationPath, string description)
        {
            var nodeBox = CreateNodeBox();

            nodeBox.Description = description;
            nodeBox.Source = sourcePath;
            nodeBox.Destination = destinationPath;

            return true;
        }

        public bool AddPathNode(IPathNode pathNode)
        {
            var result = AddPathNode(pathNode.Source, pathNode.Destination, pathNode.Description);
            RecalculateScroll();
            return result;
        }

        public void AddPathNodeList<T>(List<T> nodes) where T : IPathNode
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

        private void OnMouseEnter(object sender, EventArgs e)
        {

        }

        private void OnMouseLeave(object sender, EventArgs e)
        {

        }

        private void OnUpArrowClick(object sender, EventArgs e)
        {
            var temp = (sender as Control).Parent;

            var preview = new NodePreviewBox();

            preview.Source = (temp as IPathNode).Source ?? string.Empty;
            preview.Destination = (temp as IPathNode).Destination ?? string.Empty;
            preview.Description = (temp as IPathNode).Description ?? string.Empty;

            preview.Width = temp.Width;
            preview.Left = temp.Left;
            preview.Top = temp.Top;

            preview.DownArrowClick += OnDownArrowClick;

            var delta = preview.Height - temp.Height;

            var index = Nodes.IndexOf(temp as IPathNode);

            AddButton.Top += delta;
            RemoveButton.Top += delta;

            Nodes[index] = preview;

            Controls.Remove(temp);
            Controls.Add(preview);

            for (int i = index + 1; i < Nodes.Count; i++)
            {
                var last = Nodes[i - 1] as Control;
                var current = Nodes[i] as Control;
                current.Top = last.Top + last.Height + last.Margin.Bottom + current.Margin.Top;
            }

            RecalculateScroll();
        }

        private void OnDownArrowClick(object sender, EventArgs e)
        {
            var temp = (sender as Control).Parent;

            var nodeBox = new NodeBox();

            nodeBox.Source = (temp as IPathNode).Source ?? string.Empty;
            nodeBox.Destination = (temp as IPathNode).Destination ?? string.Empty;
            nodeBox.Description = (temp as IPathNode).Description ?? string.Empty;

            nodeBox.Width = temp.Width;
            nodeBox.Left = temp.Left;
            nodeBox.Top = temp.Top;

            nodeBox.UpArrowClick += OnUpArrowClick;

            var delta = nodeBox.Height - temp.Height;

            var index = Nodes.IndexOf(temp as IPathNode);

            AddButton.Top += delta;
            RemoveButton.Top += delta;

            Nodes[index] = nodeBox;

            Controls.Remove(temp);
            Controls.Add(nodeBox);

            for (int i = index + 1; i < Nodes.Count; i++)
            {
                (Nodes[i] as Control).Top += delta;
            }

            RecalculateScroll();
        }

        private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control item in Nodes)
            {
                item.Top -= e.NewValue - e.OldValue;
            }

            AddButton.Top -= e.NewValue - e.OldValue;
            RemoveButton.Top -= e.NewValue - e.OldValue;
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
