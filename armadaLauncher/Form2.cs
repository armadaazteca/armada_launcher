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
using System.IO;

namespace armadaLauncher
{
    public partial class frm_options : Form
    {
        private LauncherSettings launchSettings = new LauncherSettings();
        public List<string> carpeta = new List<string>();
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
            //if (launchSettings.profileList == null)
            loadPerfiles();
            //fbdCarpetaPerfil.RootFolder 
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addPerfil_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            grpDetails.Enabled = true;
            txtNombre.Text = "";
            txtCarpeta.Text = "";
            txtCarpeta.Enabled = false;
            chkAutomatica.Checked = true;
            button2.Text = "Agregar";
            txtNombre.Enabled = true;
        }

        private void perfiles_Click(object sender, EventArgs e)
        {
            
        }

        private void lstPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNombre.Text = lstPerfiles.Text;
            grpDetails.Enabled = false;
            if (lstPerfiles.SelectedIndex > 0)
            {
                txtCarpeta.Text = carpeta[lstPerfiles.SelectedIndex - 1];
                chkAutomatica.Checked = false;
                txtCarpeta.Enabled = true;
            }
            else
                txtCarpeta.Text = "";
        }

        private void grpDetails_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (txtCarpeta.Enabled == true)
            {
                fbdCarpetaPerfil.RootFolder = Environment.SpecialFolder.Desktop;
                fbdCarpetaPerfil.SelectedPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\') + 1);
                DialogResult result = fbdCarpetaPerfil.ShowDialog();
                if (result == DialogResult.OK)
                    txtCarpeta.Text = fbdCarpetaPerfil.SelectedPath;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstPerfiles.Text.Equals("Default"))
                MessageBox.Show("No se puede editar el Perfil: Default", "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (lstPerfiles.Text.Equals(""))
                MessageBox.Show("Debes seleccionar un perfil primero.", "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                grpDetails.Enabled = true;
                txtNombre.Enabled = false;
                button2.Text = "Actualizar";
            }
        }

        private void loadPerfiles()
        {
            lstPerfiles.Items.Clear();
            lstPerfiles.Items.Add("Default");
            carpeta.Clear();
            foreach (string profile in launchSettings.profileList) // Loop through List with foreach
            {
                string[] profile_data = profile.Split(',');
                lstPerfiles.Items.Add(profile_data[0]);
                carpeta.Add(profile_data[1]);
            }
            txtCarpeta.Text = "";
            txtNombre.Text = "";
            chkAutomatica.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string perfil_string = "";
            string full_path = "";
            if (txtNombre.Text.Trim().Equals(""))
                MessageBox.Show("Tienes que Escribir un nombre para el perfil", "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (chkAutomatica.Checked == false && txtCarpeta.Text.Trim().Equals(""))
                    MessageBox.Show("Selecciona una carpeta Valida o\n Activa la casilla de Carpeta Automatica.", "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    grpDetails.Enabled = false;
                    if (txtCarpeta.Text.Trim().Equals("") && chkAutomatica.Checked == true)
                    {
                        full_path = Application.ExecutablePath;
                        txtCarpeta.Text = full_path.Substring(0, full_path.LastIndexOf('\\') + 1) + rnd.Next(1, 10000).ToString();
                    }
                    //List<string> tomala = new List<string>() { "John", "Anna", "Monica" };
                    perfil_string = txtNombre.Text.Trim() + "," + txtCarpeta.Text.Trim();
                    if (button2.Text.Equals("Actualizar"))
                    {
                        int index = 0;
                        foreach (string perfil in launchSettings.profileList)
                        {
                            string nombre = perfil.Split(',')[0];
                            if (nombre.Equals(txtNombre.Text))
                            {
                                launchSettings.profileList[index] = perfil_string;
                                break;
                            }
                            index++;
                        }
                    }
                    else
                        launchSettings.profileList.Add(perfil_string);
                    launchSettings.Save();
                    Directory.CreateDirectory(txtCarpeta.Text.Trim());
                    loadPerfiles();
                }
            }
        }

        private void fbdCarpetaPerfil_HelpRequest(object sender, EventArgs e)
        {

        }

        private void chkAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutomatica.Checked == true)
                txtCarpeta.Enabled = false;
            else
                txtCarpeta.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstPerfiles.Text.Equals("Default"))
                MessageBox.Show("No se puede borrar el Perfil: Default", "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (lstPerfiles.Text.Equals(""))
                MessageBox.Show("Debes seleccionar un perfil primero.", "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                launchSettings.profileList.Remove(lstPerfiles.Text+","+carpeta[lstPerfiles.SelectedIndex-1]);
                launchSettings.Save();
                MessageBox.Show("Listo. Perfil Eliminado", "Vientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadPerfiles();
            }
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
        [DefaultSettingValueAttribute("0")]
        public int defaultProfileIndex
        {
            get { return (int)this["defaultProfileIndex"]; }
            set { this["defaultProfileIndex"] = value; }
        }

        [UserScopedSettingAttribute()]
        //[DefaultSettingValueAttribute("Def")]
        public List<string> profileList
        {
            get { return (List<string>)this["profileList"]; }
            set { this["profileList"] = value; }
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
