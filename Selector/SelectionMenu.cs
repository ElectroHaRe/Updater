using System;
using Updater.Base;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Updater.Selector
{
    //Элемент управления, представляющий собой меню пользовательского выбора нужных IPathNode
    public partial class SelectionMenu : UserControl
    {
        public SelectionMenu()
        {
            InitializeComponent();
        }

        public event EventHandler OnCheckerChanged
        {
            add => nodeCheckerCollection.OnCheckerChanged += value;
            remove => nodeCheckerCollection.OnCheckerChanged -= value;
        }

        //Свойство - обёртка для текста левой кнопки
        public string LeftButtonText 
        {
            get => LeftButton.Text;
            set => LeftButton.Text = value;
        }

        // Свойство - обёртка для текста центральной кнопки
        public string MiddleButtonText
        {
            get => MiddleButton.Text;
            set => MiddleButton.Text = value;
        }

        //Свойство - обёртка для текста правой кнопки
        public string RightButtonText
        {
            get => RightButton.Text;
            set => RightButton.Text = value;
        }

        //Событие нажатия на левую кнопку
        public event EventHandler OnLeftButtonClick
        {
            add => LeftButton.Click += value;
            remove => LeftButton.Click -= value;
        }
        
        //Событие нажатия на центральную кнопку
        public event EventHandler MiddleButtonClick
        {
            add => MiddleButton.Click += value;
            remove => MiddleButton.Click -= value;
        }
        
        //Событие нажатия на правую кнопку
        public event EventHandler RightButtonClick
        {
            add => RightButton.Click += value;
            remove => RightButton.Click -= value;
        }

        //Generic метод задания листа IPathNode
        public void SetPathNodeList<T>(List<T> nodes) where T : Base.IPathNode
        {
            SetPathNodeList(nodes.AsReadOnly());
        }

        //Generic метод задания листа IPathNode через ReadOnlyCollection
        public void SetPathNodeList<T>(ReadOnlyCollection<T> nodes) where T : Base.IPathNode
        {
            nodeCheckerCollection.Clear();
            nodeCheckerCollection.AddPathNodeList(nodes);
        }

        //Метод, возвращающий ReadOnly коллекцию NodeCheckerBox'ов, у которых Checked флаг == true
        public ReadOnlyCollection<IPathNode> GetCheckedNodes() 
        {
            return nodeCheckerCollection.GetCheckedNodes();
        }

        public bool LeftButtonIsActive
        {
            get => LeftButton.Enabled;
            set => LeftButton.Enabled = value;
        }

        public bool MiddleButtonIsActive
        {
            get => MiddleButton.Enabled;
            set => MiddleButton.Enabled = value;
        }

        public bool RightButtonIsActive
        {
            get => RightButton.Enabled;
            set => RightButton.Enabled = value;
        }

        //Метод обработчик события изменения размера элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            nodeCheckerCollection.Left = nodeCheckerCollection.Margin.Left;
            nodeCheckerCollection.Top = nodeCheckerCollection.Margin.Top;
            nodeCheckerCollection.Width = Width - nodeCheckerCollection.Left - nodeCheckerCollection.Margin.Right;
            nodeCheckerCollection.Height = Height - MiddleButton.Margin.Bottom - MiddleButton.Height - MiddleButton.Margin.Top -
                nodeCheckerCollection.Margin.Bottom - nodeCheckerCollection.Top;

            LeftButton.Top = MiddleButton.Top = RightButton.Top = nodeCheckerCollection.Bottom + nodeCheckerCollection.Margin.Bottom + MiddleButton.Margin.Top;
            LeftButton.Left = nodeCheckerCollection.Left;
            RightButton.Left = nodeCheckerCollection.Right - RightButton.Width;
            MiddleButton.Left = Width / 2 - MiddleButton.Width / 2;
        }
    }
}
