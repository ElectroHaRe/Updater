using System;
using Updater.Base;
using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var nodes = PathNodeSerializer.Load(ConfigPath);
            nodeCheckerCollectionBox1.AddPathNodeList(nodes);
            configuratorMenu1.SetPathNodeList(nodes);
        }

        private readonly string ConfigPath = @".\Config.xml";

        private void OnSaveClick(object sender, EventArgs e) 
        {
            PathNodeSerializer.Save(configuratorMenu1.GetPathNodeList(),ConfigPath);
        }
    }
}
