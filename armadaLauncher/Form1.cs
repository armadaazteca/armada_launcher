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
using LibRSync.Core;
using System.Reflection;
using System.Net.Configuration;
//using Rdiff;

namespace armadaLauncher
{

    public partial class Form1 : Form
    {
        private LauncherSettings launchSettings = new LauncherSettings();
        private bool always_update_flag = false;
        public List<string> carpeta_perfiles = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            this.Region = BitmapToRegion.getRegionFast((Bitmap)this.BackgroundImage, Color.Transparent, 100);
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private bool isFileLocked(string file_path)
        {
            try
            {
                using (Stream stream = new FileStream(file_path, FileMode.Open))
               {
                    
               }
               return false;
            } catch {
              return true;
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;                
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
            this.Visible = true;
            this.notifyIcon1.Visible = false;
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
            btnMinimize.FlatAppearance.BorderSize = 0;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                btnMinimize.FlatAppearance.BorderSize = 0;
                ToggleAllowUnsafeHeaderParsing(true);
                if (requires_update("001","config.xml",getHash(".\\config.xml"))){
                    //MessageBox.Show("Actualizando");
                    update_sync_file("001", ".\\","config.xml");
                }
                var config = XDocument.Load(@".\\config.xml");
                foreach (XElement x in config.Elements("config").Elements("servers").Elements("server"))
                {
                    cmbServers.Items.Add(x.Element("name").Value);
                    lstExe.Items.Add(x.Element("path").Value + x.Element("exe").Value);
                }
                cmbServers.SelectedIndex = launchSettings.defaultServerIndex;

                if (launchSettings.showGameMaster == 1)
                    chkGamemaster.Visible = true;
                else
                    chkGamemaster.Visible = false;
                
                chkGamemaster.Checked = launchSettings.gameMaster;
                cargaPerfiles();
                //timer = new System.Threading.Timer(obj => { cargaPerfiles(); }, null, 1000, System.Threading.Timeout.Infinite);
            }catch (Exception ex){
                MessageBox.Show("Error al leer el archivo de configuracion: " + "\n" + ex.Message + "\n" + ex.StackTrace, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.btnUpdate.Enabled = false;
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
        private void setNotifyVisible(bool value)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.InvokeRequired)
            {
                SetBoolCallback d = new SetBoolCallback(setNotifyVisible);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.notifyIcon1.Visible = value;
            }
        }

        // **************       FUNCTION               ************
        private void setFormVisible(bool value)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.InvokeRequired)
            {
                SetBoolCallback d = new SetBoolCallback(setFormVisible);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.Visible = value;
            }
        }


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
        private void client_DownloadPatchFileCompleted(object sender, AsyncCompletedEventArgs e, string path, string dest_file, string patch_uri, AutoResetEvent notify)
        {
            try
            {
                //MessageBox.Show("Magia");
                if (e.Error != null)
                {
                    // handle error scenario
                    MessageBox.Show("Error Descargando archivo: " + patch_uri + " en:" + dest_file + "\n" + e.Error.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e.Error;
                }
                if (e.Cancelled)
                {
                    // handle cancelled scenario
                }
                setPb2Visible(true);
                setlblFilenameText("Aplicando delta " + dest_file + ".patch" + "...");
                setlblFilenameVisible(true);
                setPb2Value(0);
                //File.WriteAllBytes(dest_file + ".patch", e.Result);
                setPb2Value(25);
                apply_patch_file(path, dest_file);


                setPb2Visible(false);
                setPb2Value(0);
                setlblFilenameVisible(false);                
                notify.Set();
            }
            catch (Exception ex)
            {
                Application.Exit();
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
                    MessageBox.Show("Error Descargando archivo: " + dest_file + " en:" + zip_file + "\n" + e.Error.Message + "\n" + e.Error.StackTrace, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e, string path, string dest_file, string zip_file, AutoResetEvent notify)
        {
            try
            {
                string signature_file = dest_file + ".sig";
                if (e.Error != null)
                {
                    // handle error scenario
                    MessageBox.Show("Error Subiendo archivo: " + signature_file + "\n" + e.Error.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e.Error;
                }
                if (e.Cancelled)
                {
                    // handle cancelled scenario
                }
                // Here, we are going to handle how to display the progress of applying the patch
                setPb2Visible(true);
                setlblFilenameText("Aplicando delta " + dest_file + ".patch" + "...");
                setlblFilenameVisible(true);
                setPb2Value(0);


                File.WriteAllBytes(dest_file + ".patch.gz", e.Result);
                setPb2Value(25);
                apply_patch_file(path, dest_file);
                File.Delete(signature_file);
                

                setPb2Visible(false);
                setPb2Value(0);
                setlblFilenameVisible(false);
                notify.Set();
            }
            catch (Exception ex)
            {
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

        private void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesSent.ToString());
            double totalBytes = double.Parse(e.TotalBytesToSend.ToString());
            double percentage = bytesIn / totalBytes * 100;
            setPb2Value(int.Parse(Math.Truncate(percentage).ToString()));
        }

        private void apply_patch_file(string path, string file_name)
        {
            try
            {
                // Some variable declarations
                string delta_name = file_name + ".patch";
                string delta_zip_name = file_name + ".patch.gz";
                string new_file_name = file_name + ".new";
                // Cleanup validations
                if (File.Exists(new_file_name))
                    File.Delete(new_file_name);
                if (File.Exists(delta_name))
                    File.Delete(delta_name);
                // Now, to unzip the patch file
                setlblFilenameText("Descomprimiendo " + delta_zip_name + "...");
                using (FileStream outFile = File.Create(delta_name))
                {
                    using (FileStream inFile = File.OpenRead(delta_zip_name))
                    {
                        using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
                        {
                            Decompress.CopyTo(outFile);
                        }
                    }
                }
                setlblFilenameText("Aplicando Parche " + delta_name + "...");
                // Now, lets create the streams
                RDiff rdiff = new RDiff();
                using (FileStream base_file = File.OpenRead(file_name))
                {
                    using (FileStream delta_file = File.OpenRead(delta_name))
                    {
                        using (FileStream new_file = File.OpenWrite(new_file_name))
                        {
                            rdiff.Patch(base_file, delta_file, new_file);
                        }
                    }
                }
                //FileStream new_file = File.OpenWrite(new_file_name);
                //FileStream delta_file = File.OpenRead(delta_name);
                //FileStream base_file = File.OpenRead(file_name);
                // Lets apply patches
                
                
                
                //MessageBox.Show(isFileLocked(file_name).ToString());
                setPb2Value(75);
                // Here, close all the files
                //new_file.Close();
                //delta_file.Close();
                //base_file.Close();
                
                //System.Threading.Thread.Sleep(1000);
                // Now some final cleanups
                setPb2Value(85);
                setlblFilenameText("Eliminando " + delta_name + "...");
                File.Delete(delta_name);
                setlblFilenameText("Eliminando " + delta_zip_name + "...");
                File.Delete(delta_zip_name);
                /*
                //FileUtil.WaitForFile(file_name, FileMode.Open, FileAccess.Read, FileShare.None);
                Thread.Sleep(2000);
                List<Process> lop = FileUtil.WhoIsLocking(file_name);
                string list = "";
                foreach (var lps in lop){
                    list += lps.ProcessName + ";;";
                }
                */
                setlblFilenameText("Eliminando " + file_name + "...");
                File.Delete(file_name);
                setlblFilenameText("Moviendo " + file_name + "...");
                File.Move(new_file_name, file_name);
                setPb2Value(99);
            }
            catch (Exception e)
            {
                
                MessageBox.Show("Error Aplicando Parche: " + file_name + "\n" + e.ToString() + "\n\n\n" + e.StackTrace , "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_sync_file(string id, string path, string file_name)
        {
            try
            {
                WebClient client = new WebClient();
                client = new WebClient();
                string zip_file = path + file_name + ".tmp";
                string dest_file = path + file_name;

                if (file_name.Equals("config.xml")) 
                {
                    string url = "http://armada-azteca.com/azteca/launcher/" + file_name;
                    client.DownloadFile(url, zip_file);
                    File.Copy(zip_file, dest_file,true);
                    File.Delete(zip_file);
                }
                else
                {
                    string url = "http://armada-azteca.com/azteca/launcher/" + id + "/files/" + file_name + ".gz";
                    client.DownloadFile(url, zip_file);
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
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Descargando y Actualizando: " + file_name + "\n" + e.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        private void update_sync_file(string id, string path, string file_name){
            try
            {
                WebClient client = new WebClient();
                client = new WebClient();
                string zip_file = path + file_name + ".tmp";
                string dest_file = path + file_name;
                string url = "http://armada-azteca.com/azteca/launcher/" + id + "/files/" + file_name + ".gz";
                client.DownloadFile(url, zip_file);
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
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Descargando y Actualizando: " + file_name + "\n" + e.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         * 
         */
        // **************       FUNCTION               ************
        private void DownloadFile(string id, string url, string path, string dest_file, string zip_file, AutoResetEvent notify)
        {
            if (File.Exists(dest_file))
            {
                //MessageBox.Show(url + path + dest_file);
                //string local_file = dest_file;
                string signature_file = dest_file + ".sig";
                if (File.Exists(signature_file))
                {
                    File.Delete(signature_file);
                }
                RDiff rdiff = new RDiff();
                FileStream input = File.OpenRead(dest_file);
                FileStream output = File.OpenWrite(signature_file);
                rdiff.GetSignature(input, output);
                output.Close();
                string sig_hash = getHash(signature_file);
                //MessageBox.Show("Signature Created" + signature_file + "\nHash: " + sig_hash, "Info!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Here we are going to check if for the calculated signature, we already have a patch
                string URI_patch_exist = "http://armada-azteca.com/azteca/launcher/getPatch.php?hash=" + sig_hash;
                System.Net.WebRequest req = System.Net.WebRequest.Create(URI_patch_exist);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                if (response.Equals("---"))
                {
                    // Here, lets upload the signature File
                    WebClient client = new WebClient();
                    client = new WebClient();
                    client.UploadProgressChanged += client_UploadProgressChanged;
                    client.UploadFileCompleted += (sender, e) => client_UploadFileCompleted(sender, e, path, dest_file, zip_file, notify);
                    setPb2Visible(true);
                    setlblFilenameText("Enviando firma " + signature_file + "...");
                    setlblFilenameVisible(true);
                    setPb2Value(0);
                    client.UploadFileAsync(new Uri("http://armada-azteca.com/azteca/launcher/getPatch.php?signature=" + sig_hash + "&file=" + Path.GetFileName(dest_file) +"&id="+id ), "PUT", signature_file);
                    //setPb2Visible(false);
                    //setPb2Value(0);
                    //setlblFilenameVisible(false);
                    //notify.Set();
                }
                else
                    if (response.Contains("patches"))
                    {
                        //MessageBox.Show("Hash exist!!!");
                        File.Delete(signature_file);
                        string patch_uri_location = response;
                        string download_delta_url = "http://armada-azteca.com/azteca/launcher/" + patch_uri_location;
                        WebClient client = new WebClient();
                        client = new WebClient();
                        client.DownloadProgressChanged += client_DownloadProgressChanged;
                        client.DownloadFileCompleted += (sender, e) => client_DownloadPatchFileCompleted(sender, e, path, dest_file, patch_uri_location, notify);
                        setPb2Visible(true);
                        setlblFilenameText("Descargando delta " + dest_file + "...");
                        setlblFilenameVisible(true);
                        client.DownloadFileAsync(new Uri(download_delta_url), dest_file+".patch.gz");
                    }
                    else
                        return;
            }
            else
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);
                WebClient client = new WebClient();
                client = new WebClient();
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += (sender, e) => client_DownloadFileCompleted(sender, e, path, dest_file, zip_file, notify);
                setPb2Visible(true);
                setlblFilenameText("Descargando " + dest_file + "...");
                setlblFilenameVisible(true);
                client.DownloadFileAsync(new Uri(url), zip_file);
            }
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
                DownloadFile(id,url, path, dest_file, zip_file, notify);
                //NEW
            }
            catch (Exception e)
            {
                object[] parameters;
                parameters = (object[])value;
                string file_name = (string)parameters[2];

                MessageBox.Show("Error actualizando archivo: " + file_name + "\n" + e.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // **************       FUNCTION               ************
        private string getHash(string file_name)
        {
            try{
                if (!File.Exists(file_name))
                    return "";
                using (var md5 = MD5.Create()){
                    using (var stream = File.OpenRead(file_name)){
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    }
                }
            }
            catch (Exception e){
                MessageBox.Show("Error creando hash:\n" + e.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error Creating Hash\n"+e.Message;
            }
        }
        // **************       FUNCTION               ************
        public bool requires_update(string id,string file_name, string current_hash)
        {
            try{
                if (!File.Exists(file_name))
                    return true;
                if (launchSettings.disableUpdates == 1)
                    return false;
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
                string current_version = "-1";
                string manifest_filename = null;
                string latest_version = "1";
                string server_name = (string)e.Argument;
                foreach (XElement x in config.Elements("config").Elements("servers").Elements("server")){
                    if (x.Element("name").Value.Equals(server_name)){
                        var root_path = x.Element("path").Value;
                        latest_version = (string)x.Element("version");
                        if (latest_version != null)
                        {
                            manifest_filename = (string)x.Element("manifest");
                            if (File.Exists(root_path + manifest_filename))
                            {
                                current_version = File.ReadAllText(root_path + manifest_filename);
                            }
                        }
                        int total_files = x.Elements("files").Elements("filename").Count();
                        files_remaining = total_files;
                        int i = 1;
                        foreach (XElement y in x.Elements("files").Elements("filename"))
                        {
                            if (!current_version.Equals(latest_version) || !File.Exists(root_path + y.Attribute("name").Value) || always_update_flag)
                            {
                                if (requires_update(x.Element("id").Value, y.Attribute("name").Value, getHash(root_path + y.Attribute("name").Value)))
                                {
                                    notifier.Reset();
                                    ThreadPool.QueueUserWorkItem(new WaitCallback(update_file),
                                        new object[] { x.Element("id").Value, root_path, y.Attribute("name").Value, notifier });
                                    //update_file(x.Element("id").Value, root_path, y.Attribute("name").Value);
                                    notifier.WaitOne();
                                }
                            }
                            backgroundWorker1.ReportProgress((100 / total_files) * i);
                            i++;
                        }
                        if (manifest_filename!= null)
                        {
                            File.WriteAllText(root_path + manifest_filename, latest_version);
                        }
                    }
                }
                always_update_flag = false;
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
            this.btnUpdate.Enabled = true;
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            int indexe = cmbServers.SelectedIndex;
            try{
                var psi = new ProcessStartInfo(lstExe.Text);
                string working_dir = Path.GetDirectoryName(lstExe.Text) + "\\";
                if (this.chkGamemaster.Checked && this.chkGamemaster.Visible == true)
                    psi.Arguments = "gamemaster";

                if (cmbProfile.SelectedIndex > 0)
                {
                    psi.Arguments = psi.Arguments + " path \"" + carpeta_perfiles[cmbProfile.SelectedIndex - 1] + "\"";
                }
                psi.WindowStyle = ProcessWindowStyle.Maximized;
                psi.UseShellExecute = false;
                psi.WorkingDirectory = working_dir;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(520);
                this.Visible = false;
                
//                cliente.EnableRaisingEvents = true;

                ThreadPool.QueueUserWorkItem(delegate
                {
                    Process cliente = Process.Start(psi);
                    cliente.WaitForExit();
                    //this.Visible = true;
                    setFormVisible(true);
                    setNotifyVisible(false);
                    //notifyIcon1.Visible = false;
                 });

                //cliente.Exited += (Sender, even) => client_exited(sender, e);
                //cliente.Exited += delegate { this.Visible = false; notifyIcon1.Visible = false; };
                //cliente.Exited += client_exited;
                
                //cliente.WaitForExit();
                //client.DownloadFileCompleted += (sender, e) => client_DownloadFileCompleted(sender, e, path, dest_file, zip_file, notify);
                
                //MessageBox.Show(cliente.Exited);
                //this.Show();
                //Application.Exit();
            }
            catch (Exception ee){
                MessageBox.Show("Error ejecutando: " + lstExe.Text + "\n" + ee.Message, "Tomala!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void client_exited(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Sali");
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            frm_options options_form = new frm_options();
            options_form.ShowDialog();
            launchSettings.Reload();
            cargaPerfiles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
        
        private void chkGamemaster_CheckedChanged(object sender, EventArgs e)
        {
            launchSettings.gameMaster = this.chkGamemaster.Checked;
            launchSettings.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            launchSettings.defaultProfileIndex = cmbProfile.SelectedIndex;
            launchSettings.Save();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.Show();
            this.Visible = true;
            notifyIcon1.Visible = false;
            this.Show();
            this.Activate();
            //contextMenuTray.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void cargaPerfiles()
        {
            this.cmbProfile.Items.Clear();
            this.cmbProfile.Items.Add("Default");
            this.carpeta_perfiles.Clear();
            //            this.carpeta_perfiles = new List<string>();
            foreach (string profile in launchSettings.profileList) // Loop through List with foreach
            {
                string[] profile_data = profile.Split(',');
                this.cmbProfile.Items.Add(profile_data[0]);
                this.carpeta_perfiles.Add(profile_data[1]);
            }
            this.cmbProfile.SelectedIndex = launchSettings.defaultProfileIndex;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //cargaPerfiles();
            btnMinimize.FlatAppearance.BorderSize = 0;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mostrarLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMe();
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnPlay.Select();
        }

        private void jugarArmadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glassButton1_Click(sender, e);
        }

        private void opcionesStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnOptions_Click(sender, e);
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
            }
             * */
            //MessageBox.Show(e.Button.ToString());
            if (e.Button == MouseButtons.Right)
            {
                contextMenuTray.Show(Control.MousePosition, ToolStripDropDownDirection.AboveLeft);
            }
            else
            {
                this.Visible = true;
                notifyIcon1.Visible = false;
                this.Show();
                this.Activate();
            }
        }

        public static bool ToggleAllowUnsafeHeaderParsing(bool enable)
        {
            try
            {
                //Get the assembly that contains the internal class
                Assembly assembly;
                assembly = Assembly.GetAssembly(typeof(SettingsSection));
                //            Assembly assembly = Assembly.GetAssembly(typeof(SettingsSection));
                if (assembly != null)
                {
                    //Use the assembly in order to get the internal type for the internal class
                    Type settingsSectionType = assembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                    if (settingsSectionType != null)
                    {
                        //Use the internal static property to get an instance of the internal settings class.
                        //If the static instance isn't created already invoking the property will create it for us.
                        object anInstance = settingsSectionType.InvokeMember("Section",
                        BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
                        if (anInstance != null)
                        {
                            //Locate the private bool field that tells the framework if unsafe header parsing is allowed
                            FieldInfo aUseUnsafeHeaderParsing = settingsSectionType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                            //MessageBox.Show(aUseUnsafeHeaderParsing.ToString());
                            if (aUseUnsafeHeaderParsing != null)
                            {
                                aUseUnsafeHeaderParsing.SetValue(anInstance, enable);
                                return true;
                            }

                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            notifyIcon1.Visible = true;
            string text = notifyIcon1.BalloonTipText;
            notifyIcon1.BalloonTipText = "Armada Launcher sigue activo, para iniciarlo de nuevo dale click aqui";
            notifyIcon1.ShowBalloonTip(520);
            notifyIcon1.BalloonTipText = text;
            this.Visible = false;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = armadaLauncher.Properties.Resources.minimize_white_small_3;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = armadaLauncher.Properties.Resources.minimize_white_small;
        }

        private void btnMinimize_MouseDown(object sender, MouseEventArgs e)
        {
            btnMinimize.BackgroundImage = armadaLauncher.Properties.Resources.minimize_white_small_5;
        }

        private void btnMinimize_MouseUp(object sender, MouseEventArgs e)
        {
            btnMinimize.BackgroundImage = armadaLauncher.Properties.Resources.minimize_white_small_3;
        }

        private void contextMenuTray_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackgroundImage = armadaLauncher.Properties.Resources.reload_white_small_3;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackgroundImage = armadaLauncher.Properties.Resources.reload_white_small;
        }

        private void btnUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            btnUpdate.BackgroundImage = armadaLauncher.Properties.Resources.reload_white_small_5;
        }

        private void btnUpdate_MouseUp(object sender, MouseEventArgs e)
        {
            btnUpdate.BackgroundImage = armadaLauncher.Properties.Resources.reload_white_small_3;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (requires_update("001", "config.xml", getHash(".\\config.xml")))
            {
                //MessageBox.Show("Actualizando");
                update_sync_file("001", ".\\", "config.xml");
            }
            always_update_flag = true;
            cmbServers_SelectedIndexChanged(sender, e);
        }

    }


}
