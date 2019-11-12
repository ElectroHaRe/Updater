using System;
using Updater.Base;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Updater.Configurator
{
    //Класс элемента управления для конфигурации списка IPathNode
    public partial class ConfiguratorMenu : UserControl
    {
        public ConfiguratorMenu()
        {
            InitializeComponent();
        }

        //Событие клика по кнопке Save
        public event EventHandler OnSaveClick
        {
            add => SaveButton.Click += value;
            remove => SaveButton.Click -= value;
        }

        //Событие клика по кнопке Back
        public event EventHandler OnBackClick
        {
            add => BackButton.Click += value;
            remove => BackButton.Click -= value;
        }

        //Функция установки листа параметризированного типом, реализющим интерфейс IPathNode
        public bool SetPathNodeList<T>(List<T> nodes) where T : IPathNode
        {
            return SetPathNodeList(nodes.AsReadOnly());
        }

        //Функция установки листа только для чтения параметризированного типом, реализющим интерфейс IPathNode
        public bool SetPathNodeList<T>(ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            if (nodes == null)
                return false;

            nodeCollectionBox.Clear();
            nodeCollectionBox.AddPathNodeList(nodes);

            return true;
        }

        //Функция, возвращающая список всех IPathNodes, сконфигурированных в данный момент. Список возвращается в виде листа только для чтения, параметризированного типом IPathNode
        public ReadOnlyCollection<IPathNode> GetPathNodeList()
        {
            var nodes = new List<IPathNode>();

            foreach (IPathNode item in nodeCollectionBox)
            {
                //Таким образом мы отсекаем все пустые элементы
                if (item.Source == string.Empty && item.Description == string.Empty && item.Destination == string.Empty)
                    continue;

                nodes.Add(item);
            }

            return nodes.AsReadOnly();
        }

        //Обработчик события изменения размеров элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            SaveButton.Top = Height - SaveButton.Margin.Bottom - SaveButton.Height;

            nodeCollectionBox.Width = Width - nodeCollectionBox.Margin.Left - nodeCollectionBox.Margin.Right;
            nodeCollectionBox.Height = SaveButton.Top - nodeCollectionBox.Margin.Top - SaveButton.Margin.Top - nodeCollectionBox.Margin.Bottom;

            BackButton.Top = SaveButton.Top;
            BackButton.Left = nodeCollectionBox.Left + nodeCollectionBox.Width - BackButton.Width;
        }
    }
}
