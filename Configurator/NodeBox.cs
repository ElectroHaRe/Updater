using System;
using System.Windows.Forms;

namespace Updater.Configurator
{
    public partial class NodeBox : UserControl, Base.IPathNode
    {
        public NodeBox()
        {
            InitializeComponent();
        }

        public event EventHandler UpArrowClick
        {
            add => UpArrow.Click += value;
            remove => UpArrow.Click -= value;
        }

        public string Description
        {
            get => DescriptionField.Text;
            set => DescriptionField.Text = value ?? string.Empty;
        }

        public string Source
        {
            get => SourcePathBox.Path;
            set => SourcePathBox.Path = value ?? string.Empty;
        }

        public string Destination
        {
            get => DestinationPathBox.Path;
            set => DestinationPathBox.Path = value ?? string.Empty;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            DescriptionField.Left = DescriptionLabel.Left = DescriptionField.Margin.Left;
            UpArrow.Left = Width - UpArrow.Margin.Right - UpArrow.Width;
            DescriptionField.Width = UpArrow.Left - UpArrow.Margin.Left - DescriptionField.Margin.Left - DescriptionField.Margin.Right;

            SourcePathBox.Width = DestinationPathBox.Width = Width;
        }

        private void OnUpArrowMouseEnter(object sender, EventArgs e)
        {
            UpArrow.BorderStyle = BorderStyle.Fixed3D;
        }

        private void OnUpArrowMouseLeave(object sender, EventArgs e)
        {
            UpArrow.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
