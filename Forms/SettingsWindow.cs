using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using INADRGExporter.Properties;

namespace INADRGExporter.Forms
{
    public partial class SettingsWindow : Form
    {
        public Settings settings;
        public SettingsWindow()
        {
            InitializeComponent();
            settings = Settings.Default;
            settingsPropertyGrid.SelectedObject = Properties.Settings.Default;
        }
    }
}
