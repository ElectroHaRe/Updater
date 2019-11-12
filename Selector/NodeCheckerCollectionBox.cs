using Updater.Base;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Updater.Selector
{
    //Класс элемента управления, представляющего собой коллекцию элементов IPathNode
    public partial class NodeCheckerCollectionBox : UserControl, IEnumerable<IPathNode>
    {
        public NodeCheckerCollectionBox()
        {
            InitializeComponent();
        }

        public event EventHandler OnCheckerChanged;

        private List<IPathNode> Nodes = new List<IPathNode>();

        //Возвращает все элементы коллекции Nodes, флаг Checked которых true, в виде коллекции только для чтения параметризированной IPathNode
        public ReadOnlyCollection<IPathNode> GetCheckedNodes()
        {
            List<IPathNode> temp = new List<IPathNode>();

            foreach (NodeCheckerBox item in Nodes)
            {
                if (item.Checked)
                    temp.Add(item as IPathNode);
            }

            return temp.AsReadOnly();
        }

        public bool AddPathNode(string sourcePath, string destinationPath, string description)
        {
            //добавляет новый элемент в коллекцию
            Nodes.Add(new NodeCheckerBox(sourcePath, destinationPath, description));

            //получаем ссылку на новый элемент коллекции
            var newNode = Nodes[Nodes.Count - 1] as Control;

            //Позиционируем элемент
            newNode.Left = newNode.Margin.Left;
            newNode.Width = Width - newNode.Left - newNode.Margin.Right;
            if (Nodes.Count == 1)
                newNode.Top = newNode.Margin.Top;
            else newNode.Top = (Nodes[Nodes.Count - 2] as Control).Bottom + (Nodes[Nodes.Count - 2] as Control).Margin.Bottom + newNode.Margin.Top;

            (newNode as NodeCheckerBox).CheckedChanged += OnCheckerChanged;

            //отображаем элемент на элементе управления
            Controls.Add(newNode);

            return true;
        }

        public bool AddPathNode(IPathNode pathNode)
        {
            return AddPathNode(pathNode.Source, pathNode.Destination, pathNode.Description);
        }

        public bool AddPathNodeList<T>(ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                AddPathNode(item);
            }

            return true;
        }

        private void OnSizeChanged(object sender, System.EventArgs e)
        {
            foreach (Control item in Nodes)
            {
                item.Left = item.Margin.Left;
                item.Width = Width - item.Left - item.Margin.Right;
            }
        }

        public void Clear()
        {
            foreach (Control item in Nodes)
            {
                Controls.Remove(item);
            }

            Nodes.Clear();
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
