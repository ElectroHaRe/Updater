using System;
using Updater.Base;
using System.Windows.Forms;

namespace Updater.Configurator
{
    //Класс элемента управления, представляющий собой вид предпросмотра свойств IPathNode
    public partial class NodePreviewBox : UserControl, IPathNode
    {
        public NodePreviewBox()
        {
            InitializeComponent();
        }

        //Событие клика по кнопке со стрелочкой
        public event EventHandler ArrowClick
        {
            add => ArrowButton.Click += value;
            remove => ArrowButton.Click -= value;
        }

        //Свойство - обёртка, предоставляющее доступ к Лэйблу TextBox'a Description
        public string DescriptionLabelText
        {
            get => DescriptionLabel.Text;
            set => DescriptionLabel.Text = value;
        }

        //Свойство - обёртка, предоставляющее доступ к Лэйблу TextBox'a Source
        public string SourceLabelText
        {
            get => SourcePathLabel.Text;
            set => SourcePathLabel.Text = value;
        }

        //Свойство - обёртка, предоставляющее доступ к Лэйблу TextBox'a Destination
        public string DestinationLabelText
        {
            get => DestinationPathLabel.Text;
            set => DestinationPathLabel.Text = value;
        }

        //(элемент интерфейса IPathNode) Зписывает и считывает значение с TextBox элемента Description
        public string Description
        {
            get => DescriptionField.Text;
            set => DescriptionField.Text = value;
        }

        //(элемент интерфейса IPathNode) Зписывает и считывает значение с TextBox элемента Source
        public string Source
        {
            get => SourcePathField.Text;
            set => SourcePathField.Text = value;
        }

        //(элемент интерфейса IPathNode) Зписывает и считывает значение с TextBox элемента Destination
        public string Destination
        {
            get => DestinationPathField.Text;
            set => DestinationPathField.Text = value;
        }

        //Событие изменения размеров элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            // позиция стрелочки вниз отсчитывается от правого края контрола по правому отступу самой стрелочки
            ArrowButton.Left = Width - ArrowButton.Width - ArrowButton.Margin.Right;

            // ширина элемента управления без промежутков между полями Description, Source и Destination (также вычитается позиция Description)
            var tempWidth = ArrowButton.Left - DestinationPathField.Margin.Right - 
                SourcePathField.Margin.Right - DescriptionField.Margin.Right - DescriptionField.Margin.Left;

            // ширина текст боксов и лэйблов одинакова. Ширину каждого элемента считаем в порядке слева направо
            DescriptionField.Width = DescriptionLabel.Width = tempWidth / 3;
            SourcePathField.Width = SourcePathLabel.Width = (tempWidth - DescriptionField.Width) / 2;
            DestinationPathField.Width = DestinationPathLabel.Width = tempWidth - DescriptionField.Width - SourcePathField.Width;

            // позиция слева для текстбоксов и смежных лэйблов одинакова
            DescriptionField.Left = DescriptionLabel.Left = DescriptionField.Margin.Left;
            SourcePathField.Left = SourcePathLabel.Left = DescriptionField.Right + DescriptionField.Margin.Right;
            DestinationPathField.Left = DestinationPathLabel.Left = SourcePathField.Right + SourcePathField.Margin.Right;
        }

        //Обработчик события наведения мыши на 'кнопку' со стрелочкой
        private void OnArrowMouseEnter(object sender, EventArgs e)
        {
            ArrowButton.BorderStyle = BorderStyle.Fixed3D;
        }

        //Обработчик события снятия курсора мыши с 'кнопки' со стрелочкой
        private void OnArrowMouseLeave(object sender, EventArgs e)
        {
            ArrowButton.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
