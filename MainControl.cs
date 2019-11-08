using System;
using Updater.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Updater
{
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
            UpdateNodes();
            ActivateMenu(Menu.selection);
        }

        private enum Menu : byte { selection, config, update }

        private readonly string ConfigFilePath = @".\Config.xml";

        private List<IPathNode> nodes = new List<IPathNode>();

        private void UpdateNodes()
        {
            nodes = PathNodeSerializer.Load(ConfigFilePath);
        }

        private void ActivateMenu(Menu menu)
        {
            switch (menu)
            {
                case Menu.selection:
                    selectionMenu.SetPathNodeList(nodes);
                    selectionMenu.Show();
                    configMenu.Hide();
                    updateMenu.Hide();
                    break;
                case Menu.config:
                    selectionMenu.Hide();
                    configMenu.SetPathNodeList(nodes);
                    configMenu.Show();
                    updateMenu.Hide();
                    break;
                case Menu.update:
                    selectionMenu.Hide();
                    configMenu.Hide();
                    updateMenu.SetPathNodeList(selectionMenu.GetCheckedNodes());
                    updateMenu.Show();
                    updateMenu.Start();
                    break;
                default:
                    break;
            }
        }

        private void OnUpdateClick(object sender, EventArgs e)
        {
            updateMenu.Clear();
            ActivateMenu(Menu.update);
        }

        private void OnConfigClick(object sender, EventArgs e)
        {
            ActivateMenu(Menu.config);
        }

        private void OnBackClick(object sender, EventArgs e)
        {
            UpdateNodes();
            ActivateMenu(Menu.selection);
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            Base.PathNodeSerializer.Save(configMenu.GetPathNodeList(), ConfigFilePath);
            OnBackClick(null, null);
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            updateMenu.Width = Width;
        }
    }
}
