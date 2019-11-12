using System;
using System.IO;
using Updater.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Text;

namespace Updater.UpdaterMenu
{
    //Класс элемента управления, представляющего собой меню Updat'а (или копирования файлов)
    public partial class UpdateMenu : UserControl
    {
        public UpdateMenu()
        {
            InitializeComponent();
            DirectoryInfoExtension.FileCopyCompleted += OnFileCopyCompleted;
            updater.Tick += OnTick;
            updater.Interval = 10;
        }

        //Переменая, хранящая значение полного количесва файлов в source дирректориях
        private int filesCount = 0;

        //переменная, хранящая значение текущего количества скопированных файлов
        private int counter = 0;

        //Событие клика на кнопку Back
        public event EventHandler OnBackClick
        {
            add => BackButton.Click += value;
            remove => BackButton.Click -= value;
        }

        //Событие клика на кнопку Exit
        public event EventHandler OnExitClick
        {
            add => ExitButton.Click += value;
            remove => ExitButton.Click -= value;
        }

        private List<IPathNode> nodes = new List<IPathNode>();

        //Timer для регулярного обновления шкалы прогресса
        private Timer updater = new Timer();

        //Асинхронный метод стартаоперации копирования
        public async void Start()
        {
            //Отключаем кнопки грубого прерывания приложения
            FindForm().ControlBox = false;
            //Отключаем кнопку назад и Exit
            BackButton.Enabled = ExitButton.Enabled = false;

            //Сообщаем пользователю что надо посчитать
            progressLabel.Text = "Calculation in progress";

            //Запускаем параллельно функцию разрешения конфликтов и подсчёта количества файлов
            Parallel.Invoke(CalculateFilesCount, ResolveConflictsForNodes);

            //включаем кнопки грубого прерывания работы приложения
            FindForm().ControlBox = true;

            //записываем количество файлов
            ProgressBox.Maximum = filesCount;

            //запускаем таймер для обновления значений прогресс бара
            updater.Start();

            //Запускаем процесс копирования
            await Task.Run(StartCopy);

            //Останавливаем таймер (прекращаем Update прогресс бара)
            updater.Stop();

            //Сообщаем пользователю что мы закончили
            progressLabel.Text = "Update completed!";
            ProgressBox.Value = ProgressBox.Maximum;

            //Включаем кнопки меню
            BackButton.Enabled = ExitButton.Enabled = true;
        }

        public void SetPathNodeList<T>(ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                this.nodes.Add(item);
            }
        }

        //Функция сброса самого элемента управления
        public void Clear()
        {
            nodes.Clear();
            filesCount = counter = 0;
            ProgressBox.Value = 0;
            ProgressBox.Maximum = 100;
        }

        //Функция, которая возвращает количество файлов в директории и всех поддиректориях
        private int GetFilesCountByDirectoryPath(string path)
        {
            //инициализация экземпляра ООП представления директории по переданному пути
            var dir = new DirectoryInfo(path);

            //Если директории не существует, то файлов в ней 0
            if (!dir.Exists)
                return 0;

            //получаем количество файлов в директории
            int count = dir.GetFiles().Length;

            //Обходим все поддиректории и рекурсивно считаем все файлы
            foreach (var subDir in dir.GetDirectories())
            {
                try { count += GetFilesCountByDirectoryPath(subDir.FullName); } catch { continue; }
            }

            //Возвращаем общее количество файлов в директории и всех поддиректориях
            return count;
        }

        //Функция, которая находит количество всех файлов во всех Source директориях и их поддиректориях
        private void CalculateFilesCount()
        {
            int counter = 0;

            Parallel.ForEach(nodes, node =>
            {
                counter = GetFilesCountByDirectoryPath(node.Source);
            });

            filesCount = counter;
        }

        //Ищет папки с именем Source  в папке Destination и, если находит, запихивает их в резервную папку
        private void ResolveConflictsForNodes()
        {

            string dateTime = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_" +
            DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            foreach (IPathNode node in nodes)
            {
                string conflictPath = Path.Combine(node.Destination, Path.GetFileNameWithoutExtension(node.Source + ".folder"));
                string finalFolder = string.Empty;

                if (Directory.Exists(conflictPath))
                {
                    finalFolder = Path.GetFileNameWithoutExtension(node.Source + "_" + dateTime + ".folder");

                    Directory.CreateDirectory(Path.Combine(node.Destination, "Obsolete"));

                    finalFolder = Path.Combine(node.Destination, "Obsolete", finalFolder);
                    Directory.Move(conflictPath, finalFolder);
                }
            }

        }

        //Метод логики самого копирования
        private void StartCopy()
        {
            Parallel.ForEach(nodes, node =>
            {
                (new DirectoryInfo(node.Source)).CopyTo(node.Destination);
            });
        }

        //Обработчик события завершения копирования файла
        private void OnFileCopyCompleted()
        {
            counter++;
        }

        //Метод обработчик события обновления
        private void OnTick(object sender, EventArgs e)
        {
            ProgressBox.Value = counter < ProgressBox.Maximum ? counter : ProgressBox.Maximum;
            if (DirectoryInfoExtension.CopiedFiles.Count > 0)
                progressLabel.Text = DirectoryInfoExtension.CopiedFiles[DirectoryInfoExtension.CopiedFiles.Count - 1];
        }

        //Метод обработчик события нажатия кнопки (Любой)
        private void OnButtonClick(object sender, EventArgs e)
        {
            Clear();
        }

        //Обработчик события изменения размера элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            progressLabel.Left = progressLabel.Margin.Left;
            progressLabel.Top = progressLabel.Margin.Top;

            ProgressBox.Left = ProgressBox.Margin.Left;
            ProgressBox.Top = progressLabel.Bottom + progressLabel.Margin.Bottom + ProgressBox.Margin.Top;
            ProgressBox.Width = Width - ProgressBox.Left - ProgressBox.Margin.Right;

            BackButton.Left = ProgressBox.Left;
            BackButton.Top = ProgressBox.Bottom + ProgressBox.Margin.Bottom + BackButton.Margin.Top;

            ExitButton.Left = ProgressBox.Right - ExitButton.Width;
            ExitButton.Top = BackButton.Top;
        }
    }
}
