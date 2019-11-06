using System;
using System.Windows.Forms;

namespace Updater.Configurator
{
    public partial class PathBox : UserControl
    {
        public PathBox()
        {
            InitializeComponent();
        }

        public string Label 
        {
            get => pathLabel.Text;
            set => pathLabel.Text = value;
        }

        public string Path
        {
            get => pathField.Text;
            set => pathField.Text = value;
        }

        private void OnChangePathClick(object sender, EventArgs e)
        {
            if (PathDialog.ShowDialog() == DialogResult.OK)
            {
                Path = PathDialog.SelectedPath;
            }
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            changePath.Left = Width - changePath.Margin.Right - changePath.Width;
            pathField.Width = changePath.Left - pathField.Margin.Left - pathField.Margin.Right; 
        }
    }
}
