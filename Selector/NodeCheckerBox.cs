using System.IO;
using Updater.Base;
using System.Drawing;
using System.Windows.Forms;

namespace Updater.Selector
{
    public partial class NodeCheckerBox : UserControl, IPathNode
    {
        public NodeCheckerBox()
        {
            InitializeComponent();
        }

        public NodeCheckerBox(string source, string destination, string description) : this()
        {
            Source = source;
            Destination = destination;
            Description = description;
        }

        public enum ConnectionStatus : byte { Establiched, Failed, FatalError }
        public ConnectionStatus State = ConnectionStatus.Failed;

        public bool Checked
        {
            get => Checker.Checked;
            set => Checker.Checked = value;
        }

        private string _source = string.Empty;
        private string _destination = string.Empty;

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
            get => _source;
            set
            {
                _source = value;
                Check();
            }
        }
        public string Destination
        {
            get => _destination;
            set
            {
                _destination = value;
                Check();
            }
        }

        private void Check()
        {
            if (!Directory.Exists(Source))
                ChangeStatus(ConnectionStatus.FatalError);
            else
            if (!Directory.Exists(Destination))
                ChangeStatus(ConnectionStatus.Failed);
            else
                ChangeStatus(ConnectionStatus.Establiched);
        }

        private void ChangeStatus(ConnectionStatus status)
        {
            switch (status)
            {
                case ConnectionStatus.Establiched:
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

        private void OnClick(object sender, System.EventArgs e)
        {
            if (Checker.Enabled)
                Checker.Checked = !Checker.Checked;
        }
    }
}
