using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using System.Diagnostics;

namespace armadaLauncher
{
    public partial class frm_options : Form
    {
        private LauncherSettings launchSettings = new LauncherSettings();
        public frm_options()
        {
            InitializeComponent();

        }

        private void frm_options_Load(object sender, EventArgs e)
        {
            loadServers();
            var myToolTip = new System.Windows.Forms.ToolTip
            {
                AutomaticDelay = 5000,
                AutoPopDelay = 50000,
                InitialDelay = 100,
                ReshowDelay = 500
            };
            myToolTip.SetToolTip(groupBox1, "Selecciona el server que quieres que se seleccione por default al abrir el programa.");
            myToolTip.SetToolTip(lstServers, "Selecciona el server que quieres que se seleccione por default al abrir el programa.");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            launchSettings.defaultServerIndex = this.lstServers.SelectedIndex;
            launchSettings.Save();
            //MessageBox.Show("Listo, ahora \"" + this.lstServers.SelectedValue + "\" es el server default de inicio.", "Vientos!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Servers_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadServers();
        }

        private void loadServers()
        {
            try{
                var config = XDocument.Load(@".\\config.xml");
                int iter = 0;
                lstServers.Items.Clear();
                foreach (XElement x in config.Elements("config").Elements("servers").Elements("server"))
                {

                    lstServers.Items.Add(x.Element("name").Value);
                    iter++;
                }
                lstServers.SelectedIndex = launchSettings.defaultServerIndex;
            }
            catch(Exception e){
                MessageBox.Show("Error al leer el archivo de configuracion: " + "\n" + e.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(".\\");
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe",".\\config.xml");
        }
    }

    sealed class LauncherSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0")]
        public int defaultServerIndex
        {
            get { return (int)this["defaultServerIndex"]; }
            set { this["defaultServerIndex"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("false")]
        public bool gameMaster
        {
            get { return (bool)this["gameMaster"]; }
            set { this["gameMaster"] = value; }
        }
    }
}
