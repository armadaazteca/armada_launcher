namespace armadaLauncher
{
    partial class frm_options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_options));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Servers = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstServers = new System.Windows.Forms.ListBox();
            this.reparar = new System.Windows.Forms.TabPage();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Servers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.reparar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Servers);
            this.tabControl1.Controls.Add(this.reparar);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 323);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Servers
            // 
            this.Servers.Controls.Add(this.label1);
            this.Servers.Controls.Add(this.groupBox1);
            this.Servers.Location = new System.Drawing.Point(4, 22);
            this.Servers.Name = "Servers";
            this.Servers.Padding = new System.Windows.Forms.Padding(3);
            this.Servers.Size = new System.Drawing.Size(367, 297);
            this.Servers.TabIndex = 0;
            this.Servers.Text = "Servers";
            this.Servers.UseVisualStyleBackColor = true;
            this.Servers.Click += new System.EventHandler(this.Servers_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 67);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecciona el server que \r\nmas usas, este es el server \r\nque se seleccionara y \r\n" +
    "actualizara cada \r\nque abras el launcher.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstServers);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 188);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server de Inicio";
            // 
            // lstServers
            // 
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(6, 19);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(158, 160);
            this.lstServers.TabIndex = 1;
            this.lstServers.SelectedIndexChanged += new System.EventHandler(this.lstServers_SelectedIndexChanged);
            // 
            // reparar
            // 
            this.reparar.Controls.Add(this.groupBox3);
            this.reparar.Controls.Add(this.groupBox2);
            this.reparar.Location = new System.Drawing.Point(4, 22);
            this.reparar.Name = "reparar";
            this.reparar.Padding = new System.Windows.Forms.Padding(3);
            this.reparar.Size = new System.Drawing.Size(367, 297);
            this.reparar.TabIndex = 1;
            this.reparar.Text = "Reparar";
            this.reparar.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(30, 34);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "Abrir Carpeta";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenFolder);
            this.groupBox2.Location = new System.Drawing.Point(23, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carpeta Principal";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOpenConfig);
            this.groupBox3.Location = new System.Drawing.Point(204, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 85);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Archivo de Configuracion";
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(38, 34);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(79, 23);
            this.btnOpenConfig.TabIndex = 0;
            this.btnOpenConfig.Text = "Abrir";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // frm_options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 347);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_options";
            this.Text = "Opciones";
            this.Load += new System.EventHandler(this.frm_options_Load);
            this.tabControl1.ResumeLayout(false);
            this.Servers.ResumeLayout(false);
            this.Servers.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.reparar.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Servers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstServers;
        private System.Windows.Forms.TabPage reparar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenConfig;
        private System.Windows.Forms.GroupBox groupBox2;


    }
}