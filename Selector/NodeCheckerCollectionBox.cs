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

        public bool AddPathNodeList<T>(List<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                AddPathNode(item);
            }

            return true;
        }

        private void NodeCheckerCollectionBox_SizeChanged(object sender, System.EventArgs e)
        {
            foreach (Control item in Nodes)
            {
                item.Left = item.Margin.Left;
                item.Width = Width - item.Left - item.Margin.Right;
            }
        }
    }
}
