using System;
using System.Collections.ObjectModel;
using Updater.Base;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Updater.Configurator
{
    //Класс элемента управления, для хранения листа типа IPathNode. Служит частью интерфейса для редактирования списка таких элементов
    public partial class NodeCollectionBox : UserControl, IEnumerable<IPathNode>
    {
        public NodeCollectionBox()
        {
            InitializeComponent();
        }

        //Этот лист хранит экземпляры классов NodeBox и NodePreviewBox, реализующих интерфейс IPathNode и наследующихся от UserControl
        List<IPathNode> Nodes = new List<IPathNode>();

        //Функция удаления элемента из списка Nodes (Удаление происходит иcходя из равенства возвращаемых значений Description, Destination, Source)
        public bool RemoveNode(IPathNode node)
        {
            var index = Nodes.FindIndex(item => item.Description == node.Description && item.Destination == node.Destination && item.Source == node.Source);

            if (index == -1)
                return false;

            node = Nodes[index];

            Nodes.Remove(node);
            Controls.Remove(node as Control);
            RecalculateTopCountFrom(index);
            RecalculateScroll();

            return true;
        }

        //Пересчитывает координаты Y всех элементов списка Nodes и кнопок +/-
        private void RecalculateTop()
        {
            RecalculateTopCountFrom(0);
        }

        //Пересчитывает координаты Y всех элементов списка Nodes начиная с некоторого индекса. А также кнопок +/-. 
        //Если индекс вне границ массива листа, то пересчитываются только Y координаты кнопок
        private void RecalculateTopCountFrom(int index)
        {
            //Перебор всех элементов списка Nodes, начиная с некоторого индекса
            for (int i = index; i < Nodes.Count; i++)
            {
                //Если элемент первый в списке, то Y координата отсчитывается от верхней границы контрола. Иначе от нижней границы последнего элемента в списке Nodes
                switch (i)
                {
                    case 0:
                        (Nodes[i] as Control).Top = (Nodes[i] as Control).Margin.Top;
                        break;
                    default:
                        Control last = Nodes[i - 1] as Control;
                        (Nodes[i] as Control).Top = last.Bottom + last.Margin.Bottom + (Nodes[i] as Control).Margin.Top;
                        break;
                }
            }
            //Если элементов в списке нет, то Y координаты кнопок отсчитываем от верхней границы элемента, иначе от последнего элемента списка Nodes 
            if (Nodes.Count == 0)
                AddButton.Top = RemoveButton.Top = AddButton.Margin.Top;
            else AddButton.Top = RemoveButton.Top = (Nodes[Nodes.Count - 1] as Control).Bottom + (Nodes[Nodes.Count - 1] as Control).Margin.Bottom + AddButton.Margin.Top;
        }

        //Пересчёт параметров скрола с сохранением отнасительной позиции полузнка
        private void RecalculateScroll()
        {
            float factor = VScrollBar.Maximum == 0 ? 0 : (float)VScrollBar.Value / VScrollBar.Maximum; // множитель отнасительной позиции Value

            ChangeScrollPosition(0); // сбрасываем текущий скрол в 0

            VScrollBar.Maximum = Nodes.Count == 0 ? 0 : AddButton.Top + AddButton.Height + AddButton.Margin.Bottom; // Пересчитываем максимум, минимум = 0

            VScrollBar.Maximum = VScrollBar.Maximum > Height ? VScrollBar.Maximum - Height * 9 / 10 : 0; // Досчитываем максимум, учитывая высоту нашего бокса

            ChangeScrollPosition((int)(VScrollBar.Maximum * factor)); // возращаем скрол в сохранённую позицию
        }

        //Функция изменения позиции ползунка полосы прокрутки
        private void ChangeScrollPosition(int newValue)
        {
            //Оставляет ползунок в пределах полосы прокрутки
            if (newValue < 0)
                newValue = 0;
            else if (newValue > VScrollBar.Maximum)
                newValue = VScrollBar.Maximum;

            //Обращается к обработчику события изменения положения ползунка полосы прокрутки
            OnScrollBarValueChanged(null, new ScrollEventArgs(ScrollEventType.ThumbPosition, VScrollBar.Value, newValue));
            VScrollBar.Value = newValue;
        }

        //Функция переключения между состояниями предпросмотра PathNode и развёрнутого вида (NodePreviewBox и NodeBox)
        private void ChangePathNodeControlState(int index)
        {
            var lastPathNode = Nodes[index] as Control;

            //Создаём NodePreviewBox или NodeBox, в зависимости от текущего состояния IPathNode элемента
            Control newPatnNode = lastPathNode is NodePreviewBox ? CreateNodeBox() as Control : CreateNodePreviewBox();

            //Заменяем один элемент IPathNode, другим
            ReplaceControlForPathNode(Nodes[index], newPatnNode);

            //Удаление старого элемента управления
            Controls.Remove(lastPathNode);
            Controls.Add(newPatnNode);
        }

        //Создаёт NodeBox
        private NodeBox CreateNodeBox()
        {
            var temp = new NodeBox();

            temp.ArrowClick += OnArrowClick;

            return temp;
        }

        //Создаёт NodePreviewBox
        private NodePreviewBox CreateNodePreviewBox()
        {
            var temp = new NodePreviewBox();

            temp.ArrowClick += OnArrowClick;

            return temp;
        }

        //Безболезненно устанавливает Control для элемента IPathNode
        private void ReplaceControlForPathNode(IPathNode pathNode, Control newControl)
        {
            //Если новый контрол не наследуется от IPathNode, то выбрасываем исключение
            if (!(newControl is IPathNode))
                throw new ArgumentException("PathNode controls must be compatible with the IPathNode type.");

            //Находим индекс элемента, коответствующего передаваемому
            int index = Nodes.FindIndex(item => pathNode.Description == item.Description && pathNode.Destination == item.Destination && pathNode.Source == item.Source);

            //Если PathNode не найдена, то выбрасываем исключение
            if (index == -1)
                throw new ArgumentException("Replaceable PathNode is not in the collection.");

            pathNode = Nodes[index];

            //Блок транзации значений от старого элемента PathNode к новому
            (newControl as IPathNode).Source = pathNode.Source ?? string.Empty;
            (newControl as IPathNode).Destination = pathNode.Destination ?? string.Empty;
            (newControl as IPathNode).Description = pathNode.Description ?? string.Empty;

            //Блок транзакции позиционирования и ширины от старого элемента PathNode к новому
            newControl.Width = (pathNode as Control).Width;
            newControl.Left = (pathNode as Control).Left;
            newControl.Top = (pathNode as Control).Top;

            //Изменяем значение старого контрола на новый
            Nodes[index] = newControl as IPathNode;

            //пересчитываем позиции по Y элементов, так как могла изменится высота элемента управления
            RecalculateTopCountFrom(index);
            RecalculateScroll();
        }

        //Добавляет PathNode в список, отображая в интерфейса
        public void AddPathNode(string sourcePath, string destinationPath, string description)
        {
            //инициализация экземпляра
            var nodeBox = CreateNodeBox();

            //Позиционирование
            nodeBox.Left = nodeBox.Margin.Left;
            nodeBox.Width = Width - nodeBox.Left - nodeBox.Margin.Right;
            if (Nodes.Count > 0)
                nodeBox.Top = (Nodes[Nodes.Count - 1] as Control).Bottom + (Nodes[Nodes.Count - 1] as Control).Margin.Bottom + nodeBox.Margin.Top;

            //блок установки значений IPathBox
            nodeBox.Description = description ?? string.Empty;
            nodeBox.Source = sourcePath ?? string.Empty;
            nodeBox.Destination = destinationPath ?? string.Empty;

            //Добавление нового элемента управления в список Nodes и вывод на экран
            Nodes.Add(nodeBox);
            Controls.Add(nodeBox);

            RecalculateTopCountFrom(Nodes.Count - 1);
            RecalculateScroll();
        }

        public void AddPathNode(IPathNode pathNode)
        {
            AddPathNode(pathNode.Source, pathNode.Destination, pathNode.Description);
        } 

        public void AddPathNodeList<T>(ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                AddPathNode(item);
            }
        }

        //Сброс этого элемента управление в пустое состояние
        public void Clear()
        {
            //удаляем все элементы списка Nodes из списка прикреплённых Control'ов
            foreach (var item in Nodes)
            {
                Controls.Remove(item as Control);
            }

            Nodes.Clear();

            //Пересчёт позиций и скрола
            RecalculateTop();
            RecalculateScroll();
        }

        public ReadOnlyCollection<IPathNode> GetPathNodeList()
        {
            return Nodes.AsReadOnly();
        }

        //Обработчик события клика на кнопку +
        private void OnAddButtonClick(object sender, EventArgs e)
        {
            AddPathNode("", "", "");
            RecalculateScroll();
        }

        //Обработчик события наведения мыши на кнопку +
        private void OnAddButtonMouseEnter(object sender, EventArgs e)
        {
            AddButton.ForeColor = Color.Green;
        }

        //Обработчик события снятия курсора мыши с кнопки +
        private void OnAddButtonMouseLeave(object sender, EventArgs e)
        {
            AddButton.ForeColor = Color.Black;
        }

        //Обработчик события клика по кнопке -
        private void OnRemoveButtonClick(object sender, EventArgs e)
        {
            if (Nodes.Count > 0)
                RemoveNode(Nodes[Nodes.Count - 1]);
        }

        //Обработчик события наведения мыши на кнопку -
        private void OnRemoveButtonMouseEnter(object sender, EventArgs e)
        {
            RemoveButton.ForeColor = Color.Red;
        }

        //Обработчик события снятия курсора мыши с кнопки -
        private void OnRemoveButtonMouseLeave(object sender, EventArgs e)
        {
            RemoveButton.ForeColor = Color.Black;
        }

        //Событие клика на кнопку стрелочки (для NodeBox и NodePreviewBox)
        private void OnArrowClick(object sender, EventArgs e)
        {
            var temp = (sender as Control).Parent as IPathNode;
            int index = Nodes.IndexOf(temp);

            ChangePathNodeControlState(index);

            RecalculateTopCountFrom(index + 1);
            RecalculateScroll();
        }

        //Обработчик события изменения положения ползунка полосы прокрутки
        private void OnScrollBarValueChanged(object sender, ScrollEventArgs e)
        {
            //Сдвигаем все элементы в противоположную сторону
            foreach (Control item in Nodes)
            {
                item.Top -= e.NewValue - e.OldValue;
            }

            //Сдвигаем обе кнопки в противоположную сторону
            AddButton.Top -= e.NewValue - e.OldValue;
            RemoveButton.Top -= e.NewValue - e.OldValue;
        }

        //Обработчик события изменения размеров элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            //Пересчитываем позиции слева для каждого элемента списка Nodes
            foreach (Control item in Nodes)
            {
                item.Width = Width - item.Margin.Left - item.Margin.Right;
                item.Left = item.Margin.Left;
            }

            //Выравниваем кнопки +/- по центру элемента управления (по горизонтали)
            AddButton.Left = Width / 2 + AddButton.Margin.Left;
            RemoveButton.Left = Width / 2 - RemoveButton.Margin.Left - RemoveButton.Width;


            VScrollBar.Left = Width - VScrollBar.Width;
            VScrollBar.Height = Height;

            RecalculateScroll();
        }

        public IEnumerator<IPathNode> GetEnumerator()
        {
            return ((IEnumerable<IPathNode>)Nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IPathNode>)Nodes).GetEnumerator();
        }
    }
}
