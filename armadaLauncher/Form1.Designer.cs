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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnPlay = new EnhancedGlassButton.GlassButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFilename2 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnOptions = new EnhancedGlassButton.GlassButton();
            this.btnSalir = new EnhancedGlassButton.GlassButton();
            this.lstExe = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.chkGamemaster = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbServers
            // 
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(677, 434);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(186, 21);
            this.cmbServers.TabIndex = 1;
            this.cmbServers.SelectedIndexChanged += new System.EventHandler(this.cmbServers_SelectedIndexChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblFilename2);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(215, 472);
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
            // lstExe
            // 
            this.lstExe.FormattingEnabled = true;
            this.lstExe.Location = new System.Drawing.Point(603, 178);
            this.lstExe.Name = "lstExe";
            this.lstExe.Size = new System.Drawing.Size(10, 17);
            this.lstExe.TabIndex = 15;
            this.lstExe.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::armadaLauncher.Properties.Resources.closeButton;
            this.pictureBox1.Location = new System.Drawing.Point(843, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
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
            // Form1
            // 
            this.BackgroundImage = global::armadaLauncher.Properties.Resources.Image11;
            this.ClientSize = new System.Drawing.Size(902, 648);
            this.Controls.Add(this.chkGamemaster);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstExe);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.cmbServers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Armada Launcher";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbServers;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private EnhancedGlassButton.GlassButton btnPlay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private EnhancedGlassButton.GlassButton btnOptions;
        private EnhancedGlassButton.GlassButton btnSalir;
        private System.Windows.Forms.Label lblFilename2;
        private System.Windows.Forms.ListBox lstExe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.CheckBox chkGamemaster;
    }
}

