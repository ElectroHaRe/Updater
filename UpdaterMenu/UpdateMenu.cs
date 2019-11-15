using System;
using System.IO;
using Updater.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Updater.UpdaterMenu
{
    public partial class UpdateMenu : UserControl
    {
        public UpdateMenu()
        {
            InitializeComponent();
            updater.Tick += OnTick;
            updater.Interval = 10;
        }

        private long FullSize = 0;

        private long CurrentSize = 0;

        private string CurrentFile = string.Empty;

        public event EventHandler BackClick
        {
            add => BackButton.Click += value;
            remove => BackButton.Click -= value;
        }

        public event EventHandler ExitClick
        {
            add => ExitButton.Click += value;
            remove => ExitButton.Click -= value;
        }

        private List<IPathNode> nodes = new List<IPathNode>();

        private Timer updater = new Timer();

        public async void Start()
        {
            FindForm().ControlBox = false;
            BackButton.Enabled = ExitButton.Enabled = false;
            progressLabel.Text = "Calculation in progress";

            Parallel.Invoke(CalculateFullSize, ResolveConflictsForNodes);

            FindForm().ControlBox = true;
            updater.Start();

            foreach (var node in nodes)
            {
               await (new DirectoryInfo(node.Source)).CopyTo(node.Destination, OnFileCopyCompleted);
            }

            updater.Stop();

            progressLabel.Text = "Update completed!";
            ProgressBox.Value = ProgressBox.Maximum;
            BackButton.Enabled = ExitButton.Enabled = true;
        }

        public void SetPathNodeList<T>(ReadOnlyCollection<T> nodes) where T : IPathNode
        {
            foreach (var item in nodes)
            {
                this.nodes.Add(item);
            }
        }

        public void Clear()
        {
            nodes.Clear();
            FullSize = ProgressBox.Maximum;
            CurrentSize = 0;
            CurrentFile = string.Empty;
            ProgressBox.Value = 0;
        }

        private void OnFileCopyCompleted(string fileName)
        {
            CurrentFile = Path.GetFileName(fileName);
            CurrentSize += (new FileInfo(fileName)).Length;
        }

        private void CalculateFullSize()
        {
            foreach (var node in nodes)
            {
                foreach (var file in new DirectoryInfo(node.Source).GetFiles("*", SearchOption.AllDirectories))
                {
                    FullSize += file.Length;
                }
            }
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

        private void OnTick(object sender, EventArgs e)
        {
            progressLabel.Text = CurrentFile;
            ProgressBox.Value = (int)(CurrentSize * ProgressBox.Maximum / FullSize);
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
