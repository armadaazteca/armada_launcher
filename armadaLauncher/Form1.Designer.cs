namespace armadaLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFilename2 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lstExe = new System.Windows.Forms.ListBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.chkGamemaster = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jugarArmadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSalir = new EnhancedGlassButton.GlassButton();
            this.btnOptions = new EnhancedGlassButton.GlassButton();
            this.btnPlay = new EnhancedGlassButton.GlassButton();
            this.toolTipArmada = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.contextMenuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblFilename2);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(215, 476);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 85);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblFilename2
            // 
            this.lblFilename2.AutoSize = true;
            this.lblFilename2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename2.ForeColor = System.Drawing.Color.White;
            this.lblFilename2.Location = new System.Drawing.Point(6, 37);
            this.lblFilename2.Name = "lblFilename2";
            this.lblFilename2.Size = new System.Drawing.Size(44, 18);
            this.lblFilename2.TabIndex = 20;
            this.lblFilename2.Text = "label1";
            this.lblFilename2.Visible = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(7, 59);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(525, 11);
            this.progressBar2.TabIndex = 19;
            this.progressBar2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(148)))), ((int)(((byte)(3)))));
            this.progressBar1.Location = new System.Drawing.Point(7, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(524, 11);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // lstExe
            // 
            this.lstExe.FormattingEnabled = true;
            this.lstExe.Location = new System.Drawing.Point(603, 178);
            this.lstExe.Name = "lstExe";
            this.lstExe.Size = new System.Drawing.Size(10, 17);
            this.lstExe.TabIndex = 15;
            this.lstExe.Visible = false;
            // 
            // chkGamemaster
            // 
            this.chkGamemaster.AutoSize = true;
            this.chkGamemaster.BackColor = System.Drawing.Color.Transparent;
            this.chkGamemaster.ForeColor = System.Drawing.Color.White;
            this.chkGamemaster.Location = new System.Drawing.Point(768, 544);
            this.chkGamemaster.Name = "chkGamemaster";
            this.chkGamemaster.Size = new System.Drawing.Size(89, 17);
            this.chkGamemaster.TabIndex = 17;
            this.chkGamemaster.Text = "Game Master";
            this.chkGamemaster.UseVisualStyleBackColor = false;
            this.chkGamemaster.CheckedChanged += new System.EventHandler(this.chkGamemaster_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "El cliente se inicio, dale click en este icono cuando quieras abrir el launcher d" +
    "e nuevo.";
            this.notifyIcon1.BalloonTipTitle = "Cliente Iniciado";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuTray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Armada Launcher";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // contextMenuTray
            // 
            this.contextMenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jugarArmadaToolStripMenuItem,
            this.mostrarLauncherToolStripMenuItem,
            this.opcionesStripMenuItem1,
            this.toolStripSeparator1,
            this.menu_exit});
            this.contextMenuTray.Name = "contextMenuTray";
            this.contextMenuTray.ShowImageMargin = false;
            this.contextMenuTray.Size = new System.Drawing.Size(134, 98);
            this.contextMenuTray.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuTray_Opening);
            // 
            // jugarArmadaToolStripMenuItem
            // 
            this.jugarArmadaToolStripMenuItem.Name = "jugarArmadaToolStripMenuItem";
            this.jugarArmadaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.jugarArmadaToolStripMenuItem.Text = "Jugar Armada";
            this.jugarArmadaToolStripMenuItem.Click += new System.EventHandler(this.jugarArmadaToolStripMenuItem_Click);
            // 
            // mostrarLauncherToolStripMenuItem
            // 
            this.mostrarLauncherToolStripMenuItem.Name = "mostrarLauncherToolStripMenuItem";
            this.mostrarLauncherToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.mostrarLauncherToolStripMenuItem.Text = "Mostrar Launcher";
            this.mostrarLauncherToolStripMenuItem.Click += new System.EventHandler(this.mostrarLauncherToolStripMenuItem_Click);
            // 
            // opcionesStripMenuItem1
            // 
            this.opcionesStripMenuItem1.Name = "opcionesStripMenuItem1";
            this.opcionesStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.opcionesStripMenuItem1.Text = "Opciones";
            this.opcionesStripMenuItem1.Click += new System.EventHandler(this.opcionesStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // menu_exit
            // 
            this.menu_exit.Name = "menu_exit";
            this.menu_exit.Size = new System.Drawing.Size(133, 22);
            this.menu_exit.Text = "Cerrar Launcher";
            this.menu_exit.Click += new System.EventHandler(this.menu_exit_Click);
            // 
            // cmbServers
            // 
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(677, 381);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(186, 21);
            this.cmbServers.TabIndex = 1;
            this.cmbServers.SelectedIndexChanged += new System.EventHandler(this.cmbServers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(674, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cliente:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(674, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Perfil:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbProfile
            // 
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(677, 439);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(186, 21);
            this.cmbProfile.TabIndex = 23;
            this.cmbProfile.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(111, 590);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Version: 1.3.1";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = global::armadaLauncher.Properties.Resources.minimize_white_small;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Location = new System.Drawing.Point(824, 129);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 35);
            this.btnMinimize.TabIndex = 25;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMinimize_MouseDown);
            this.btnMinimize.MouseEnter += new System.EventHandler(this.btnMinimize_MouseEnter);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.btnMinimize_MouseLeave);
            this.btnMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMinimize_MouseUp);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BackgroundImage = global::armadaLauncher.Properties.Resources.reload_white_small;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Location = new System.Drawing.Point(637, 372);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(34, 43);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.TabStop = false;
            this.toolTipArmada.SetToolTip(this.btnUpdate, "Forzar actualización del cliente seleccionado");
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUpdate_MouseDown);
            this.btnUpdate.MouseEnter += new System.EventHandler(this.btnUpdate_MouseEnter);
            this.btnUpdate.MouseLeave += new System.EventHandler(this.btnUpdate_MouseLeave);
            this.btnUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUpdate_MouseUp);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSalir.Location = new System.Drawing.Point(103, 516);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(106, 34);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.Red;
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptions.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOptions.Location = new System.Drawing.Point(103, 476);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(106, 34);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.Text = "Opciones";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Red;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPlay.Location = new System.Drawing.Point(757, 490);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(106, 48);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Jugar";
            this.btnPlay.Click += new System.EventHandler(this.glassButton1_Click);
            // 
            // Form1
            // 
            this.BackgroundImage = global::armadaLauncher.Properties.Resources.Image11;
            this.ClientSize = new System.Drawing.Size(902, 648);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbProfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkGamemaster);
            this.Controls.Add(this.cmbServers);
            this.Controls.Add(this.lstExe);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Armada Launcher";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private EnhancedGlassButton.GlassButton btnPlay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private EnhancedGlassButton.GlassButton btnOptions;
        private EnhancedGlassButton.GlassButton btnSalir;
        private System.Windows.Forms.Label lblFilename2;
        private System.Windows.Forms.ListBox lstExe;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.CheckBox chkGamemaster;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuTray;
        private System.Windows.Forms.ToolStripMenuItem menu_exit;
        private System.Windows.Forms.ToolStripMenuItem mostrarLauncherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jugarArmadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem opcionesStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolTip toolTipArmada;
    }
}

