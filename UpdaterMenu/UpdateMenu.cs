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
            updater.Interval = 1;
        }

        public event Action OnComplete;

        private List<IPathNode> nodes = new List<IPathNode>();

        private int FilesCount = 0;
        private int counter = 0;

        private Timer updater = new Timer();

        private void OnFileCopyComplete()
        {
            counter++;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (FilesCount != ProgressBox.Maximum)
                ProgressBox.Maximum = FilesCount;
            ProgressBox.Value = counter < ProgressBox.Maximum? counter : ProgressBox.Maximum;
            label1.Text = ((float)ProgressBox.Value * 100 / ProgressBox.Maximum).ToString();
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

        private void CheckNodes()
        {
            string tempPath = string.Empty;
            string dateTime = "Obsolete_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_" +
                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            foreach (IPathNode node in nodes)
            {
                tempPath = Path.Combine(node.Destination, Path.GetFileNameWithoutExtension(node.Source + ".folder"));

                if (Directory.Exists(tempPath))
                {
                    Directory.Move(tempPath, Path.Combine(node.Destination, dateTime));
                }
            }
        }

        private void StartCopy()
        {
            CheckNodes();

            Parallel.ForEach(nodes, node =>
            {
                (new DirectoryInfo(node.Source)).CopyTo(node.Destination);
            });
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

        public async void Start()
        {
            counter = FilesCount = 0;
            ProgressBox.Maximum = 100;

            updater.Start();

            await Task.Run(CalculateFilesCount);
            await Task.Run(StartCopy);

            OnTick(null, null);
            updater.Stop();

            Clear();

            if (MessageBox.Show("Complete") == DialogResult.OK)
                OnComplete?.Invoke();
        }

        public void Clear()
        {
            nodes.Clear();
            FilesCount = 0;
            counter = 0;
        }
    }
}
