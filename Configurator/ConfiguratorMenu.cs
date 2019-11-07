using System;
using Updater.Base;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Updater.Configurator
{
    public partial class ConfiguratorMenu : UserControl
    {
        public ConfiguratorMenu()
        {
            InitializeComponent();
        }

        public event EventHandler OnSaveClick
        {
            add => SaveButton.Click += value;
            remove => SaveButton.Click -= value;
        }
        public event EventHandler OnBackClick
        {
            add => BackButton.Click += value;
            remove => BackButton.Click -= value;
        }

        public bool SetPathNodeList<T>(List<T> nodes) where T : IPathNode 
        {
            return SetPathNodeList(nodes.AsReadOnly());
        }

        public bool SetPathNodeList<T>(System.Collections.ObjectModel.ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            if (nodes == null)
                return false;

            nodeCollectionBox.Clear();
            nodeCollectionBox.AddPathNodeList(nodes);

            return true;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IPathNode> GetPathNodeList() 
        {
            return nodeCollectionBox.GetPathNodeList();
        }

        private void ConfiguratorMenu_SizeChanged(object sender, EventArgs e)
        {
            SaveButton.Top = Height - SaveButton.Margin.Bottom - SaveButton.Height;

            nodeCollectionBox.Width = Width - nodeCollectionBox.Margin.Left - nodeCollectionBox.Margin.Right;
            nodeCollectionBox.Height = SaveButton.Top - nodeCollectionBox.Margin.Top - SaveButton.Margin.Top - nodeCollectionBox.Margin.Bottom;

            BackButton.Top = SaveButton.Top;
            BackButton.Left = nodeCollectionBox.Left + nodeCollectionBox.Width - BackButton.Width;
        }
    }
}
