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
            this.perfiles = new System.Windows.Forms.TabPage();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.chkAutomatica = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCarpeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstPerfiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reparar = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnBorrarTodo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.gmOptions = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDisableUpdates = new System.Windows.Forms.CheckBox();
            this.chkActivateGameMaster = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fbdCarpetaPerfil = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.Servers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.perfiles.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.reparar.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gmOptions.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Servers);
            this.tabControl1.Controls.Add(this.perfiles);
            this.tabControl1.Controls.Add(this.reparar);
            this.tabControl1.Controls.Add(this.gmOptions);
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
            // perfiles
            // 
            this.perfiles.Controls.Add(this.grpDetails);
            this.perfiles.Controls.Add(this.groupBox4);
            this.perfiles.Controls.Add(this.label2);
            this.perfiles.Location = new System.Drawing.Point(4, 22);
            this.perfiles.Name = "perfiles";
            this.perfiles.Size = new System.Drawing.Size(367, 297);
            this.perfiles.TabIndex = 2;
            this.perfiles.Text = "Perfiles";
            this.perfiles.UseVisualStyleBackColor = true;
            this.perfiles.Click += new System.EventHandler(this.perfiles_Click);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.chkAutomatica);
            this.grpDetails.Controls.Add(this.button2);
            this.grpDetails.Controls.Add(this.button1);
            this.grpDetails.Controls.Add(this.txtCarpeta);
            this.grpDetails.Controls.Add(this.label4);
            this.grpDetails.Controls.Add(this.txtNombre);
            this.grpDetails.Controls.Add(this.label3);
            this.grpDetails.Enabled = false;
            this.grpDetails.Location = new System.Drawing.Point(3, 187);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(356, 100);
            this.grpDetails.TabIndex = 5;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Detalles del Perfil";
            this.grpDetails.Enter += new System.EventHandler(this.grpDetails_Enter);
            // 
            // chkAutomatica
            // 
            this.chkAutomatica.AutoSize = true;
            this.chkAutomatica.Checked = true;
            this.chkAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutomatica.Location = new System.Drawing.Point(254, 13);
            this.chkAutomatica.Name = "chkAutomatica";
            this.chkAutomatica.Size = new System.Drawing.Size(79, 43);
            this.chkAutomatica.TabIndex = 10;
            this.chkAutomatica.Text = "Elegir\r\nCarpeta\r\nAutomatica";
            this.chkAutomatica.UseVisualStyleBackColor = true;
            this.chkAutomatica.CheckedChanged += new System.EventHandler(this.chkAutomatica_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::armadaLauncher.Properties.Resources.Folder_icon;
            this.button1.Location = new System.Drawing.Point(236, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 20);
            this.button1.TabIndex = 8;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // txtCarpeta
            // 
            this.txtCarpeta.Enabled = false;
            this.txtCarpeta.Location = new System.Drawing.Point(53, 65);
            this.txtCarpeta.Name = "txtCarpeta";
            this.txtCarpeta.Size = new System.Drawing.Size(177, 20);
            this.txtCarpeta.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Carpeta:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(53, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnEdit);
            this.groupBox4.Controls.Add(this.btnRemove);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.lstPerfiles);
            this.groupBox4.Location = new System.Drawing.Point(3, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(155, 171);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Perfiles";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.Transparent;
            this.btnEdit.Image = global::armadaLauncher.Properties.Resources.edit1;
            this.btnEdit.Location = new System.Drawing.Point(109, 133);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(28, 29);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemove.Image = global::armadaLauncher.Properties.Resources.delete1;
            this.btnRemove.Location = new System.Drawing.Point(58, 133);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 29);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.Transparent;
            this.btnAdd.Image = global::armadaLauncher.Properties.Resources.add1;
            this.btnAdd.Location = new System.Drawing.Point(6, 133);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lstPerfiles
            // 
            this.lstPerfiles.FormattingEnabled = true;
            this.lstPerfiles.Location = new System.Drawing.Point(6, 19);
            this.lstPerfiles.Name = "lstPerfiles";
            this.lstPerfiles.Size = new System.Drawing.Size(131, 108);
            this.lstPerfiles.TabIndex = 1;
            this.lstPerfiles.SelectedIndexChanged += new System.EventHandler(this.lstPerfiles_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 119);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // reparar
            // 
            this.reparar.Controls.Add(this.groupBox6);
            this.reparar.Controls.Add(this.groupBox3);
            this.reparar.Controls.Add(this.groupBox2);
            this.reparar.Location = new System.Drawing.Point(4, 22);
            this.reparar.Name = "reparar";
            this.reparar.Padding = new System.Windows.Forms.Padding(3);
            this.reparar.Size = new System.Drawing.Size(367, 297);
            this.reparar.TabIndex = 1;
            this.reparar.Text = "Reparar";
            this.reparar.UseVisualStyleBackColor = true;
            this.reparar.Click += new System.EventHandler(this.reparar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnBorrarTodo);
            this.groupBox6.Location = new System.Drawing.Point(23, 109);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(138, 85);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Borrar Todo y Cerrar";
            // 
            // btnBorrarTodo
            // 
            this.btnBorrarTodo.Location = new System.Drawing.Point(30, 34);
            this.btnBorrarTodo.Name = "btnBorrarTodo";
            this.btnBorrarTodo.Size = new System.Drawing.Size(75, 25);
            this.btnBorrarTodo.TabIndex = 0;
            this.btnBorrarTodo.Text = "Borrar";
            this.btnBorrarTodo.UseVisualStyleBackColor = true;
            this.btnBorrarTodo.Click += new System.EventHandler(this.btnBorrarTodo_Click);
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
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(30, 34);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "Abrir";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // gmOptions
            // 
            this.gmOptions.Controls.Add(this.groupBox5);
            this.gmOptions.Controls.Add(this.label6);
            this.gmOptions.Location = new System.Drawing.Point(4, 22);
            this.gmOptions.Name = "gmOptions";
            this.gmOptions.Size = new System.Drawing.Size(367, 297);
            this.gmOptions.TabIndex = 3;
            this.gmOptions.Text = "GM Options";
            this.gmOptions.UseVisualStyleBackColor = true;
            this.gmOptions.Click += new System.EventHandler(this.gmOptions_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.chkDisableUpdates);
            this.groupBox5.Controls.Add(this.chkActivateGameMaster);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(361, 153);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Opciones del Cliente";
            this.groupBox5.Visible = false;
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 41);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cualquier cambio que hagas en esta pestaña\r\npara que tenga efecto tienes que rein" +
    "iciar el\r\nArmada Azteca Launcher.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDisableUpdates
            // 
            this.chkDisableUpdates.AutoSize = true;
            this.chkDisableUpdates.Location = new System.Drawing.Point(6, 42);
            this.chkDisableUpdates.Name = "chkDisableUpdates";
            this.chkDisableUpdates.Size = new System.Drawing.Size(215, 17);
            this.chkDisableUpdates.TabIndex = 2;
            this.chkDisableUpdates.Text = "Desactivar Actualizaciones Automáticas";
            this.chkDisableUpdates.UseVisualStyleBackColor = true;
            this.chkDisableUpdates.CheckedChanged += new System.EventHandler(this.chkDisableUpdates_CheckedChanged);
            // 
            // chkActivateGameMaster
            // 
            this.chkActivateGameMaster.AutoSize = true;
            this.chkActivateGameMaster.Location = new System.Drawing.Point(6, 19);
            this.chkActivateGameMaster.Name = "chkActivateGameMaster";
            this.chkActivateGameMaster.Size = new System.Drawing.Size(215, 17);
            this.chkActivateGameMaster.TabIndex = 1;
            this.chkActivateGameMaster.Text = "Mostrar Opción de GameMaster al Inicio";
            this.chkActivateGameMaster.UseVisualStyleBackColor = true;
            this.chkActivateGameMaster.CheckedChanged += new System.EventHandler(this.chkActivateGameMaster_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Esta Pestaña Ocupa un Password.\r\nSolo los GMs la Pueden Usar.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // fbdCarpetaPerfil
            // 
            this.fbdCarpetaPerfil.RootFolder = System.Environment.SpecialFolder.CommonAdminTools;
            this.fbdCarpetaPerfil.HelpRequest += new System.EventHandler(this.fbdCarpetaPerfil_HelpRequest);
            // 
            // frm_options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 347);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_options";
            this.Text = "Opciones";
            this.Load += new System.EventHandler(this.frm_options_Load);
            this.tabControl1.ResumeLayout(false);
            this.Servers.ResumeLayout(false);
            this.Servers.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.perfiles.ResumeLayout(false);
            this.perfiles.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.reparar.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gmOptions.ResumeLayout(false);
            this.gmOptions.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.TabPage perfiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstPerfiles;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCarpeta;
        private System.Windows.Forms.FolderBrowserDialog fbdCarpetaPerfil;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkAutomatica;
        private System.Windows.Forms.TabPage gmOptions;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkDisableUpdates;
        private System.Windows.Forms.CheckBox chkActivateGameMaster;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnBorrarTodo;


    }
}