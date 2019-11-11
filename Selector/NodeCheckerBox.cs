using System.IO;
using Updater.Base;
using System.Drawing;
using System.Windows.Forms;

namespace Updater.Selector
{
    //Класс элемента управления, представляющий собой единичный элемент IPathNode с функционалом чека действительности путей
    public partial class NodeCheckerBox : UserControl, IPathNode
    {
        public NodeCheckerBox()
        {
            InitializeComponent();
        }

        public NodeCheckerBox(string source, string destination, string description) : this()
        {
            this.Source = source;
            this.Destination = destination;
            this.Description = description;
        }

        public enum ConnectionStatus : byte { Completed, Failed, FatalError }
        public ConnectionStatus State = ConnectionStatus.Failed;

        //Свойство - флаг, обёртка для CheckerBox'a
        public bool Checked
        {
            get => Checker.Checked;
            set => Checker.Checked = value;
        }

        private string source = string.Empty;
        private string destination = string.Empty;

        public string Description
        {
            get => Checker.Text;
            set
            {
                Checker.Text = value;
                StatusLabel.Left = Checker.Right + Checker.Margin.Right + StatusLabel.Margin.Left;
            }
        }
        public string Source
        {
            get => source;
            set
            {
                source = value;
                Check();
            }
        }
        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                Check();
            }
        }

        private void Check()
        {
            try { new DirectoryInfo(Destination); } catch { ChangeStatus(ConnectionStatus.FatalError); return; }

            if (!Directory.Exists(Source))
                ChangeStatus(ConnectionStatus.FatalError);
            else
            if (!Directory.Exists(Destination))
                ChangeStatus(ConnectionStatus.Failed);
            else
                ChangeStatus(ConnectionStatus.Completed);
        }

        private void ChangeStatus(ConnectionStatus status)
        {
            switch (status)
            {
                case ConnectionStatus.Completed:
                    StatusLabel.Text = "Connection : " + status.ToString();
                    StatusLabel.ForeColor = Color.Green;
                    Checker.Enabled = true;
                    break;
                case ConnectionStatus.Failed:
                    StatusLabel.Text = "Connection : " + status.ToString();
                    StatusLabel.ForeColor = Color.Red;
                    Checker.Enabled = true;
                    break;
                case ConnectionStatus.FatalError:
                    StatusLabel.Text = "Connection : " + status.ToString();
                    StatusLabel.ForeColor = Color.Red;
                    Checker.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        //Обработчик события клика по этому элементу управления (Обёртка)
        private void OnClick(object sender, System.EventArgs e)
        {
            if (Checker.Enabled)
                Checker.Checked = !Checker.Checked;
        }
    }
}
