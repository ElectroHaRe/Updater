using System;
using System.IO;
using Updater.Base;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Updater.Configurator
{
    public partial class ConfiguratorMenu : UserControl
    {
        public ConfiguratorMenu()
        {
            InitializeComponent();
            LoadConfig();
        }

        public event EventHandler OnBackClick
        {
            add => BackButton.Click += value;
            remove => BackButton.Click -= value;
        }

        private readonly string ConfigPath = @".\Config.xml";

        public void SaveConfig()
        {
            var nodeCollection = nodeCollectionBox.GetPathNodeList();

            List<PathNode> pathList = new List<PathNode>();

            foreach (var item in nodeCollection)
            {
                if (item.Source != string.Empty || item.Destination != string.Empty || item.Description != string.Empty)
                    pathList.Add(new PathNode(item.Description, item.Source, item.Destination));
            }

            XmlSerializer serializer = new XmlSerializer(pathList.GetType());

            using (var stream = new FileStream(ConfigPath, FileMode.Create))
            {
                serializer.Serialize(stream, pathList);
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IPathNode> LoadConfig()
        {
            if (!File.Exists(ConfigPath))
                return new List<IPathNode>().AsReadOnly();

            List<PathNode> pathList = new List<PathNode>();

            XmlSerializer serializer = new XmlSerializer(pathList.GetType());

            using (var stream = new FileStream(ConfigPath, FileMode.Open))
            {
                pathList = serializer.Deserialize(stream) as List<PathNode>;
            }

            nodeCollectionBox.Clear();
            nodeCollectionBox.AddPathNodeList(pathList);

            return nodeCollectionBox.GetPathNodeList();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveConfig();
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
