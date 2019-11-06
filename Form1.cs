using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (Updater.Base.IPathNode item in configuratorMenu1.LoadConfig())
            {
                nodeCheckerCollectionBox1.AddPathNode(item);
            }
        }
    }
}
