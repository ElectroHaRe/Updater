using Updater.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Updater.Selector
{
    public partial class NodeCheckerCollectionBox : UserControl
    {
        public NodeCheckerCollectionBox()
        {
            InitializeComponent();
        }

        private List<IPathNode> Nodes = new List<IPathNode>();

        public System.Collections.ObjectModel.ReadOnlyCollection<IPathNode> GetCheckedNodes() 
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
            Nodes.Add(new NodeCheckerBox(sourcePath, destinationPath, description));

            var newNode = Nodes[Nodes.Count - 1] as Control;

            newNode.Left = newNode.Margin.Left;
            newNode.Width = Width - newNode.Left - newNode.Margin.Right;
            newNode.Top = Nodes.Count == 1 ? newNode.Margin.Top : (Nodes[Nodes.Count - 2] as Control).Bottom +
                (Nodes[Nodes.Count - 2] as Control).Margin.Bottom + newNode.Margin.Top;

            Controls.Add(newNode);

            return true;
        }

        public bool AddPathNode(IPathNode pathNode)
        {
            return AddPathNode(pathNode.Source, pathNode.Destination, pathNode.Description);
        }

        public bool AddPathNodeList<T>(System.Collections.ObjectModel.ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                AddPathNode(item);
            }

            return true;
        }

        public bool AddPathNodeList<T>(List<T> nodes) where T : IPathNode
        {
            return AddPathNodeList(nodes.AsReadOnly());
        }

        private void NodeCheckerCollectionBox_SizeChanged(object sender, System.EventArgs e)
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
    }
}
