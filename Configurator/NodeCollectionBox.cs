using System;
using Updater.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater.Configurator
{
    public partial class NodeCollectionBox : UserControl
    {
        public NodeCollectionBox()
        {
            InitializeComponent();
        }

        List<IPathNode> Nodes = new List<IPathNode>();

        private NodeBox CreateNodeBox()
        {
            var nodeBox = new NodeBox();

            nodeBox.Width = Width - nodeBox.Margin.Left - nodeBox.Margin.Right;
            if (Nodes.Count > 0)
            {
                var lastBox = Nodes[Nodes.Count - 1] as Control;
                nodeBox.Top = lastBox.Top + lastBox.Height + lastBox.Margin.Bottom + nodeBox.Margin.Top;
            }
            else nodeBox.Top = nodeBox.Margin.Top;

            nodeBox.UpArrowClick += OnUpArrowMoseClick;

            Nodes.Add(nodeBox);
            Controls.Add(nodeBox);

            AddButton.Top = nodeBox.Top + nodeBox.Height + nodeBox.Margin.Bottom + AddButton.Margin.Top;

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
            return AddPathNode(pathNode.Source, pathNode.Destination, pathNode.Description);
        }

        public void AddPathNodeList(List<IPathNode> nodes)
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
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {

        }

        private void OnMouseLeave(object sender, EventArgs e)
        {

        }

        private void OnUpArrowMoseClick(object sender, EventArgs e)
        {
            var temp = sender as Control;

            var preview = new NodePreviewBox();

            preview.Source = (temp as IPathNode).Source;
            preview.Destination = (temp as IPathNode).Destination;
            preview.Description = (temp as IPathNode).Description;

            preview.Width = temp.Width;
            preview.Left = temp.Left;
            preview.Top = temp.Top;

            var delta = preview.Top - temp.Top;

            for (int i = Nodes.IndexOf(temp as IPathNode) + 1; i < Nodes.Count; i++)
            {
                (Nodes[i] as Control).Top += delta;
            }

            AddButton.Top += delta;
        }

        private void OnDownArrowMoseClick(object sender, EventArgs e)
        {
            var temp = sender as Control;

            var nodeBox = new NodeBox();

            nodeBox.Source = (temp as IPathNode).Source;
            nodeBox.Destination = (temp as IPathNode).Destination;
            nodeBox.Description = (temp as IPathNode).Description;

            nodeBox.Width = temp.Width;
            nodeBox.Left = temp.Left;
            nodeBox.Top = temp.Top;

            var delta = nodeBox.Top - temp.Top;

            for (int i = Nodes.IndexOf(temp as IPathNode) + 1; i < Nodes.Count; i++)
            {
                (Nodes[i] as Control).Top += delta;
            }

            AddButton.Top += delta;
        }
    }
}
