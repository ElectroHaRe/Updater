using System;
using System.Windows.Forms;

namespace Updater.Configurator
{
    //Элемент управления, для удобного задания какого-либо пути файловой системы
    public partial class PathBox : UserControl
    {
        public PathBox()
        {
            InitializeComponent();
        }

        //Свойство - обёртка для private элемента Label
        public string Label 
        {
            get => pathLabel.Text;
            set => pathLabel.Text = value;
        }

        //Свойство - обёртка для private элемента TextBox
        public string Path
        {
            get => pathField.Text;
            set => pathField.Text = value;
        }

        //Обработчик события нажатия кнопки изменения пути
        private void OnChangePathClick(object sender, EventArgs e)
        {
            //Вызов диалогового окна. Если путь выбран и принят, то его значение переносится в соответствующее текстовое поле
            if (PathDialog.ShowDialog() == DialogResult.OK)
            {
                Path = PathDialog.SelectedPath;
            }
        }

        //Событие изменения размера элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            //Кнопку открытия диалогового окна выбора пути равняем по правой стороне элемента управления.
            changePath.Left = Width - changePath.Margin.Right - changePath.Width;
            //Текстовое поле пути не передвигаем, но изменяем ширину его с учётом текущей ширины элемента управления и положения кнопки ChangePath
            pathField.Width = changePath.Left - changePath.Margin.Left - pathField.Margin.Left - pathField.Margin.Right; 
        }
    }
}
