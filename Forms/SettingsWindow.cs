using System.Windows.Forms;
using InadrgExporter.Properties;

namespace InadrgExporter.Forms
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, System.EventArgs e)
        {
            settingsPropertyGrid.SelectedObject = Settings.Default;
        }
    }
}
