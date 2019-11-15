using System;
using Updater.Base;
using System.Windows.Forms;

namespace Updater.Configurator
{
    //Класс, представляющий элемент упраления развёрнутого вида IPathNode
    public partial class NodeBox : UserControl, IPathNode
    {
        public NodeBox()
        {
            InitializeComponent();
        }

        //Событие нажатия на 'кнопку' со стрелкой
        public event EventHandler ArrowClick
        {
            add => Arrow.Click += value;
            remove => Arrow.Click -= value;
        }

        //(реализация интерфейса IPathNode) Свойство - обёртка для TextBox'а Description
        public string Description
        {
            get => DescriptionField.Text;
            set => DescriptionField.Text = value;
        }

        //(реализация интерфейса IPathNode) Свойство - обёртка для PathBox'а Source
        public string Source
        {
            get => SourcePathBox.Path;
            set => SourcePathBox.Path = value;
        }

        //(реализация интерфейса IPathNode) Свойство - обёртка для TextBox'а Destination
        public string Destination
        {
            get => DestinationPathBox.Path;
            set => DestinationPathBox.Path = value;
        }

        //Обработчик события наведения курсора на 'кнопку' со стрелочкой
        private void OnUpArrowMouseEnter(object sender, EventArgs e)
        {
            Arrow.BorderStyle = BorderStyle.Fixed3D;
        }

        //Обработчик события снятия курсора мыши с 'кнопки' со стрелочкой
        private void OnUpArrowMouseLeave(object sender, EventArgs e)
        {
            Arrow.BorderStyle = BorderStyle.FixedSingle;
        }

        //Обработчик события изменения размеров элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            DescriptionField.Left = DescriptionLabel.Left = DescriptionField.Margin.Left;
            Arrow.Left = Width - Arrow.Margin.Right - Arrow.Width;
            DescriptionField.Width = Arrow.Left - Arrow.Margin.Left - DescriptionField.Margin.Left - DescriptionField.Margin.Right;

            SourcePathBox.Width = DestinationPathBox.Width = Width;
        }
    }
}
