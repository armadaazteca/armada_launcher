using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Net;
using System.IO.Compression;
using System.Configuration;

namespace armadaLauncher
{
    public partial class Form1 : Form
    {
        private LauncherSettings launchSettings = new LauncherSettings();
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            this.Region = BitmapToRegion.getRegionFast((Bitmap)this.BackgroundImage, Color.Transparent, 100);
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString("Normal style", this.Font, Brushes.Black, 50, 50);
            e.Graphics.TextRenderingHint =
                 System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString("ClearType style", this.Font, Brushes.Black, 50, 100);
        }

        private bool mouseIsDown = false;
        private Point firstPoint;
        private int files_remaining;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                var config = XDocument.Load(@".\\config.xml");
                foreach (XElement x in config.Elements("config").Elements("servers").Elements("server"))
                {
                    cmbServers.Items.Add(x.Element("name").Value);
                    lstExe.Items.Add(x.Element("path").Value + x.Element("exe").Value);
                }
                cmbServers.SelectedIndex = launchSettings.defaultServerIndex;
                this.chkGamemaster.Checked = launchSettings.gameMaster;
            }catch (Exception ex){
                MessageBox.Show("Error al leer el archivo de configuracion: " + "\n" + ex.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int indexe = cmbServers.SelectedIndex;
            try
            {
                Process.Start(lstExe.Text);
                Application.Exit();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error ejecutando: " + lstExe.Text + "\n" + ee.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnPlay.Enabled = false;
            this.cmbServers.Enabled = false;
            this.lstExe.SelectedIndex = cmbServers.SelectedIndex;
            this.progressBar1.Visible = true;
            this.backgroundWorker1.RunWorkerAsync(cmbServers.SelectedItem);            
        }

        // ********************************************************
        // ********************************************************
        // ********************************************************
        // **********      Funciones Mamadas     ******************
        // ********************************************************
        // ********************************************************
        // ********************************************************
        delegate void SetTextCallback(string text);
        delegate void SetIntCallback(int text);
        delegate void SetBoolCallback(bool value);

        // **************       FUNCTION               ************
        private void setlblFilenameVisible(bool value)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.lblFilename2.InvokeRequired)
            {
                SetBoolCallback d = new SetBoolCallback(setlblFilenameVisible);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.lblFilename2.Visible = value;
            }
        }

        // **************       FUNCTION               ************
        private void setlblFilenameText(string value)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.lblFilename2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setlblFilenameText);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.lblFilename2.Text = value;
            }
        }

        // **************       FUNCTION               ************
        private void setPb2Visible(bool value)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.progressBar2.InvokeRequired)
            {
                SetBoolCallback d = new SetBoolCallback(setPb2Visible);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.progressBar2.Visible = value;
            }
        }

        // **************       FUNCTION               ************
        private void setPb2Value(int value)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.progressBar2.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(setPb2Value);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.progressBar2.Value = value;
            }
        }

        // **************       FUNCTION               ************
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e, string path, string dest_file, string zip_file, AutoResetEvent notify)
        {
            try
            {
                if (e.Error != null)
                {
                    // handle error scenario
                    MessageBox.Show("Error Descargando archivo: " + dest_file + " en:" + zip_file + "\n" + e.Error.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e.Error;
                }
                if (e.Cancelled)
                {
                    // handle cancelled scenario
                }
                setlblFilenameText("Descomprimiendo " + zip_file + "...");
                using (FileStream outFile = File.Create(dest_file))
                {
                    using (FileStream inFile = File.OpenRead(zip_file))
                    {
                        using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
                        {
                            Decompress.CopyTo(outFile);
                        }
                    }
                }
                File.Delete(zip_file);
                setPb2Visible(false);
                setPb2Value(0);
                setlblFilenameVisible(false);
                notify.Set();
            }
            catch (Exception ex){
                Application.Exit();
            }
        }
        // **************       FUNCTION               ************
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            setPb2Value(int.Parse(Math.Truncate(percentage).ToString()));
        }
        // **************       FUNCTION               ************
        private void DownloadFile(string url, string path, string dest_file, string zip_file, AutoResetEvent notify)
        {
            WebClient client = new WebClient();
            client = new WebClient();
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadFileCompleted += (sender, e) => client_DownloadFileCompleted(sender, e, path, dest_file, zip_file, notify);
            setPb2Visible(true);
            setlblFilenameText("Descargando " + zip_file + "...");
            setlblFilenameVisible(true);
            //Form1.ActiveForm.Update();
            client.DownloadFileAsync(new Uri(url), zip_file);
            return;
        }
        // **************       FUNCTION               ************
        //private void update_file(string id, string path, string file_name)
        private void update_file(object value)
        {            
            try
            {
                object[] parameters;
                parameters = (object[]) value;
                string id = (string)parameters[0];
                string path = (string)parameters[1];
                string file_name = (string)parameters[2];
                AutoResetEvent notify = (AutoResetEvent)parameters[3];
                string url = "http://armada-azteca.com/azteca/launcher/" + id + "/files/" + file_name + ".gz";
                string zip_file =  path + file_name + ".tmp";
                string dest_file = path + file_name;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                // NEW
                DownloadFile(url, path, dest_file, zip_file, notify);
                //NEW
            }
            catch (Exception e)
            {
                string file_name = "Armada";
                MessageBox.Show("Error actualizando archivo: " + file_name + "\n" + e.Message + "\n" + e.StackTrace, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // **************       FUNCTION               ************
        private string getHash(string file_name)
        {
            try{
                using (var md5 = MD5.Create()){
                    using (var stream = File.OpenRead(file_name)){
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    }
                }
            }
            catch (Exception){
                return "XX";
            }
        }
        // **************       FUNCTION               ************
        public static bool requires_update(string id,string file_name, string current_hash)
        {
            try{
                string URI = "http://armada-azteca.com/azteca/launcher/" + id + "/" + file_name + ".html";
                System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                if (sr.ReadToEnd().Trim().Equals(current_hash))
                    return false;
                else
                    return true;
            }
            catch (Exception e){
                MessageBox.Show("Error al checar actualizaciones de: " + file_name + "\n" + e.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // *******************************************
        // *******************************************  
        // **********  Fin Funciones Mamadas  ********
        // *******************************************  
        // *******************************************
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try{   
                var notifier = new AutoResetEvent(false);
                var config = XDocument.Load(@".\\config.xml");
                string server_name = (string)e.Argument;
                foreach (XElement x in config.Elements("config").Elements("servers").Elements("server")){
                    if (x.Element("name").Value.Equals(server_name)){
                        var root_path = x.Element("path").Value;
                        int total_files = x.Elements("files").Elements("filename").Count();
                        files_remaining = total_files;
                        int i = 1;
                        foreach (XElement y in x.Elements("files").Elements("filename")){
                            if (requires_update(x.Element("id").Value, y.Attribute("name").Value, getHash(root_path + y.Attribute("name").Value))){
                                notifier.Reset();
                                ThreadPool.QueueUserWorkItem(new WaitCallback(update_file),
                                    new object[] { x.Element("id").Value, root_path, y.Attribute("name").Value, notifier });
                                //update_file(x.Element("id").Value, root_path, y.Attribute("name").Value);
                                notifier.WaitOne();
                            }
                            backgroundWorker1.ReportProgress((100 / total_files) * i);
                            i++;
                        }
                    }
                }
                e.Result = "Done";
            }
            catch (Exception ex){
                MessageBox.Show("Error al leer el archivo de configuracion: " + "\n" + ex.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MessageBox.Show("Cambio");
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Visible = false;
            this.progressBar1.Value = 0;
            this.btnPlay.Enabled = true;
            this.cmbServers.Enabled = true;
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            int indexe = cmbServers.SelectedIndex;
            try{
                var psi = new ProcessStartInfo(lstExe.Text);
                string working_dir = Path.GetDirectoryName(lstExe.Text) + "\\";
                if (this.chkGamemaster.Checked)
                    psi.Arguments = "gamemaster";
                psi.WindowStyle = ProcessWindowStyle.Maximized;
                psi.UseShellExecute = false;
                psi.WorkingDirectory = working_dir;
                Process.Start(psi);
                Application.Exit();
            }
            catch (Exception ee){
                MessageBox.Show("Error ejecutando: " + lstExe.Text + "\n" + ee.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frm_options options_form = new frm_options();
            options_form.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.BorderStyle = BorderStyle.None;
            this.pictureBox1.Size = new Size(20, 20);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            //this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.Size = new Size(23, 23);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkGamemaster_CheckedChanged(object sender, EventArgs e)
        {
            launchSettings.gameMaster = this.chkGamemaster.Checked;
            launchSettings.Save();
        }

    }
}
