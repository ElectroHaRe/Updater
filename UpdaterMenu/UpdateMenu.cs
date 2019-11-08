using System;
using System.IO;
using Updater.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater.UpdaterMenu
{
    public partial class UpdateMenu : UserControl
    {
        public UpdateMenu()
        {
            InitializeComponent();
            DirectoryExtension.FileCopyComplete += OnFileCopyComplete;
            updater.Tick += OnTick;
            updater.Interval = 10;
        }

        private int FilesCount = 0;
        private int counter = 0;

        public event EventHandler OnBackClick
        {
            add => BackButton.Click += value;
            remove => BackButton.Click -= value;
        }

        public event EventHandler OnExitClick
        {
            add => ExitButton.Click += value;
            remove => ExitButton.Click -= value;
        }

        private List<IPathNode> nodes = new List<IPathNode>();

        private Timer updater = new Timer();

        public async void Start()
        {
            BackButton.Enabled = ExitButton.Enabled = false;

            progressLabel.Text = "Calculation in progress";

            Parallel.Invoke(CalculateFilesCount, ResolveConflictsForNodes);

            ProgressBox.Maximum = FilesCount;

            updater.Start();

            await Task.Run(StartCopy);

            updater.Stop();

            progressLabel.Text = "Update completed!";
            ProgressBox.Value = ProgressBox.Maximum;

            BackButton.Enabled = ExitButton.Enabled = true;
        }

        public void SetPathNodeList<T>(List<T> nodes) where T : IPathNode
        {
            SetPathNodeList(nodes.AsReadOnly());
        }

        public void SetPathNodeList<T>(System.Collections.ObjectModel.ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                this.nodes.Add(item);
            }
        }

        public void AddPathNode<T>(T node) where T : IPathNode
        {
            nodes.Add(node);
        }

        public void Clear()
        {
            nodes.Clear();
            FilesCount = counter = 0;
            ProgressBox.Value = 0;
            ProgressBox.Maximum = 100;
        }

        private int GetFilesCountByDirectoryPath(string path)
        {
            var dir = new DirectoryInfo(path);

            if (!dir.Exists)
                return 0;

            int count = dir.GetFiles().Length;

            foreach (var subDir in dir.GetDirectories())
            {
                try { count += GetFilesCountByDirectoryPath(subDir.FullName); } catch { continue; }
            }

            return count;
        }

        private void CalculateFilesCount()
        {
            int counter = 0;

            Parallel.ForEach(nodes, node =>
            {
                counter += GetFilesCountByDirectoryPath(node.Source);
            });

            FilesCount = counter;
        }

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

        private void StartCopy()
        {
            ResolveConflictsForNodes();

            Parallel.ForEach(nodes, node =>
            {
                (new DirectoryInfo(node.Source)).CopyTo(node.Destination);
            });
        }

        private void OnFileCopyComplete()
        {
            counter++;
        }

        private void OnTick(object sender, EventArgs e)
        {
            ProgressBox.Value = counter < ProgressBox.Maximum ? counter : ProgressBox.Maximum;
            progressLabel.Text = DirectoryExtension.currentFile;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Clear();
        }

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
