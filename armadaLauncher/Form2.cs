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
using System.Net;
using System.Security.Cryptography;

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
            myToolTip.SetToolTip(groupBox1, "Selecciona el server que quieres que este seleccionado por default al abrir el programa");
            myToolTip.SetToolTip(lstServers, "Selecciona el server que quieres que se seleccione por default al abrir el programa");
            myToolTip.SetToolTip(chkActivateGameMaster, "Si activas esta opción, en la ventana principal podras elegir si quieres abrir el cliente con GameMaster para poder usar MC");
            myToolTip.SetToolTip(chkDisableUpdates, "Si activas esta opción, el cliente no se actualizara automaticamente");
            myToolTip.SetToolTip(lstPerfiles, "Todos los perfiles para tus hotkeys");
            myToolTip.SetToolTip(btnAdd, "Agregar un nuevo perfil");
            myToolTip.SetToolTip(btnEdit, "Editar el perfil seleccionado");
            myToolTip.SetToolTip(btnRemove, "Eliminar el perfil seleccionado");
            myToolTip.SetToolTip(btnBorrarTodo, "Eliminar todos los datos y cerrar el Launcher, esto hara que la siguiente vez que lo abras, se descargen todos los archivos");
            
            //if (launchSettings.profileList == null)
            //this.Invoke(loadPerfiles);
            loadPerfiles();
            //fbdCarpetaPerfil.RootFolder

            if (launchSettings.showGameMaster == 1)
                chkActivateGameMaster.Checked = true;
            else
                chkActivateGameMaster.Checked = false;
            if (launchSettings.disableUpdates == 1)
                chkDisableUpdates.Checked = true;
            else
                chkDisableUpdates.Checked = false;
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
            if (tabControl1.SelectedTab.Name == "gmOptions")
                gmOptions_Click(sender, e);
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
            
            ///LOADPERFILES
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
            ///LOADPERFILES
            ///
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
                launchSettings.defaultProfileIndex = 0;
                launchSettings.Save();
                MessageBox.Show("Listo. Perfil Eliminado", "Vientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadPerfiles();
            }
        }

        private void reparar_Click(object sender, EventArgs e)
        {

        }

        private void gmOptions_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            try
            {
                string promptValue = Prompt.ShowDialog("Password:", "Escribe el Password",this.Icon);
                WebClient client = new WebClient();
                client = new WebClient();
                string url = "http://armada-azteca.com/azteca/launcher/passwordGMS.txt";
                string password = client.DownloadString(url);
                if (MD5Hash(promptValue) == password.Trim())
                    groupBox5.Visible = true;
                else
                {
                    groupBox5.Visible = false;
                    MessageBox.Show("Contraseña Incorrecta!", "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al Obtener el Password." + "\n" + err.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox5.Visible = false;
            }
        }

        private static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private void chkActivateGameMaster_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkActivateGameMaster.Checked)
            {
                launchSettings.showGameMaster = 1;
            }
            else
            {
                launchSettings.showGameMaster = 0;
                launchSettings.gameMaster = false;
            }
            launchSettings.Save();
        }

        private void chkDisableUpdates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisableUpdates.Checked)
            {
                launchSettings.disableUpdates = 1;
            }
            else
            {
                launchSettings.disableUpdates = 0;
            }
            launchSettings.Save();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            gmOptions_Click(sender,e);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("Estas seguro que quieres borrar todos los archivos y cerrar el launcher?\nEsto provocara que la siguiente vez que abras el launcher se vuelvan a descargar todos los archivos","Aguas!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (results == DialogResult.Yes)
            {
                try
                {
                    var config = XDocument.Load(@".\\config.xml");
                    int iter = 0;
                    foreach (XElement x in config.Elements("config").Elements("servers").Elements("server"))
                    {
                        string root_path = x.Element("path").Value;
                        foreach (XElement y in x.Elements("files").Elements("filename"))
                        {
                            if (File.Exists(root_path + y.Attribute("name").Value))
                                File.Delete(root_path + y.Attribute("name").Value);
                        }
                        iter++;
                    }
                    MessageBox.Show("Listo, Ahora el launcher se cerrará.","Listo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Application.Exit();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error eliminando archivos." + "\n" + err.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        public int showGameMaster
        {
            get { return (int)this["showGameMaster"]; }
            set { this["showGameMaster"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0")]
        public int disableUpdates
        {
            get { return (int)this["disableUpdates"]; }
            set { this["disableUpdates"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0")]
        public int defaultProfileIndex
        {
            get { return (int)this["defaultProfileIndex"]; }
            set { this["defaultProfileIndex"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("")]
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
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, Icon icono)
        {
            Form prompt = new Form();
            prompt.Icon = icono;
            prompt.Width = 200;
            prompt.Height = 140;
            prompt.Text = caption;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            Label textLabel = new Label() { Left = 10, Top = 23, Text = text };
            textLabel.AutoSize = true;
            TextBox textBox = new TextBox() { Left = 70, Top = 20, Width = 100 };
            textBox.UseSystemPasswordChar = true;
            //textBox.KeyDown += new KeyEventHandler(tb_KeyDown);
            textBox.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) prompt.Close(); };
            Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 60 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;
            prompt.StartPosition = FormStartPosition.CenterParent;
            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}
