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

            configuratorMenu1.OnSaveClick += OnSaveClick;
            configuratorMenu1.OnBackClick += OnBackClick;

            ChangeState(States.Check);
        }

        private enum States : byte { Check, Config, Update };

        private States state = States.Check;

        private readonly string ConfigPath = @".\Config.xml";

        private void OnSaveClick(object sender, EventArgs e)
        {
            PathNodeSerializer.Save(configuratorMenu1.GetPathNodeList(), ConfigPath);
        }

        private void OnBackClick(object sender, EventArgs e) 
        {
            OnSaveClick(null, null);
            ChangeState(States.Check);
        }

        private void ChangeState(States state) 
        {
            var nodes = PathNodeSerializer.Load(ConfigPath);
            switch (state)
            {
                case States.Check:
                    nodeCheckerCollectionBox1.Show();
                    configuratorMenu1.Hide();
                    updateMenu1.Hide();
                    nodeCheckerCollectionBox1.Clear();
                    nodeCheckerCollectionBox1.AddPathNodeList(nodes);

                    UpdateButton.Show();
                    ExitButton.Show();
                    ConfigButton.Show();
                    break;
                case States.Config:
                    nodeCheckerCollectionBox1.Hide();
                    configuratorMenu1.Show();
                    updateMenu1.Hide();
                    configuratorMenu1.SetPathNodeList(nodes);

                    UpdateButton.Hide();
                    ExitButton.Hide();
                    ConfigButton.Hide();
                    break;
                case States.Update:
                    nodeCheckerCollectionBox1.Hide();
                    configuratorMenu1.Hide();
                    updateMenu1.Show();
                    updateMenu1.Clear();
                    updateMenu1.SetPathNodeList(nodeCheckerCollectionBox1.GetCheckedNodes());
                    updateMenu1.Start();

                    UpdateButton.Hide();
                    ExitButton.Hide();
                    ConfigButton.Hide();
                    break;
                default:
                    break;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            ChangeState(States.Update);
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            ChangeState(States.Config);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updateMenu1_OnComplete()
        {
            ChangeState(States.Check);
        }
    }
}
