using System;
using System.Windows.Forms;

namespace Updater.Configurator
{
    public partial class NodePreviewBox : UserControl, Base.IPathNode
    {
        public NodePreviewBox()
        {
            InitializeComponent();
        }

        public event EventHandler DownArrowClick
        {
            add => DownArrow.Click += value;
            remove => DownArrow.Click -= value;
        }

        public string DescriptionLabelText
        {
            get => DescriptionLabel.Text;
            set => DescriptionLabel.Text = value ?? string.Empty;
        }

        public string SourceLabelText
        {
            get => SourcePathLabel.Text;
            set => SourcePathLabel.Text = value ?? string.Empty;
        }

        public string DestinationLabelText
        {
            get => DestinationPathLabel.Text;
            set => DestinationPathLabel.Text = value ?? string.Empty;
        }

        public string Description
        {
            get => DescriptionField.Text;
            set => DescriptionField.Text = value ?? string.Empty;
        }

        public string Source
        {
            get => SourcePathField.Text;
            set => SourcePathField.Text = value ?? string.Empty;
        }

        public string Destination
        {
            get => DestinationPathField.Text;
            set => DestinationPathField.Text = value ?? string.Empty;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            // позиция стрелочки вниз отсчитывается от правого края контрола по правому отступу самой стрелочки
            DownArrow.Left = Width - DownArrow.Width - DownArrow.Margin.Right;

            // ширина контрола без промежутков между полями Description, Source и Destination (также вычитается позиция Description)
            var tempWidth = DownArrow.Left - DestinationPathField.Margin.Right - 
                SourcePathField.Margin.Right - DescriptionField.Margin.Right - DescriptionField.Margin.Left;

            // ширина текст боксов и лэйблов одинакова. Ширину каждого элемента считаем в порядке слева направо
            DescriptionField.Width = DescriptionLabel.Width = tempWidth / 3;
            SourcePathField.Width = SourcePathLabel.Width = (tempWidth - DescriptionField.Width) / 2;
            DestinationPathField.Width = DestinationPathLabel.Width = tempWidth - DescriptionField.Width - SourcePathField.Width;

            // позиция слева для текстбоксов и смежных лэйблов одинакова
            DescriptionField.Left = DescriptionLabel.Left = DescriptionField.Margin.Left;
            SourcePathField.Left = SourcePathLabel.Left = DescriptionField.Left + DescriptionField.Width + DescriptionField.Margin.Right;
            DestinationPathField.Left = DestinationPathLabel.Left = SourcePathField.Left + SourcePathField.Width + SourcePathField.Margin.Right;
        }

        private void OnDownArrowMouseEnter(object sender, EventArgs e)
        {
            DownArrow.BorderStyle = BorderStyle.Fixed3D;
        }

        private void DownArrow_MouseLeave(object sender, EventArgs e)
        {
            DownArrow.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
