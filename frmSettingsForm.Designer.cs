namespace VoiceRecorder
{
    partial class frmSettingsForm
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
            this.lbTempFolder = new System.Windows.Forms.Label();
            this.tbTempFolder = new System.Windows.Forms.TextBox();
            this.tbOutputFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFtpServer = new System.Windows.Forms.TextBox();
            this.lbFtpServer = new System.Windows.Forms.Label();
            this.tbFtpUser = new System.Windows.Forms.TextBox();
            this.lbFtpUser = new System.Windows.Forms.Label();
            this.tbFtpPassword = new System.Windows.Forms.TextBox();
            this.lbFtpPassword = new System.Windows.Forms.Label();
            this.tbPointId = new System.Windows.Forms.TextBox();
            this.lbPointId = new System.Windows.Forms.Label();
            this.tbVoiceLevel = new System.Windows.Forms.TextBox();
            this.lbVoiceLevel = new System.Windows.Forms.Label();
            this.tbSilencePause = new System.Windows.Forms.TextBox();
            this.lbSilencePause = new System.Windows.Forms.Label();
            this.btnSelectTempFolder = new System.Windows.Forms.Button();
            this.btnSelectOutputFolder = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lbTempFolder
            // 
            this.lbTempFolder.AutoSize = true;
            this.lbTempFolder.Location = new System.Drawing.Point(13, 13);
            this.lbTempFolder.Name = "lbTempFolder";
            this.lbTempFolder.Size = new System.Drawing.Size(109, 13);
            this.lbTempFolder.TabIndex = 0;
            this.lbTempFolder.Text = "Временный каталог";
            // 
            // tbTempFolder
            // 
            this.tbTempFolder.Location = new System.Drawing.Point(12, 33);
            this.tbTempFolder.Name = "tbTempFolder";
            this.tbTempFolder.Size = new System.Drawing.Size(493, 20);
            this.tbTempFolder.TabIndex = 1;
            this.tbTempFolder.Text = "C:\\Voice\\Temp";
            // 
            // tbOutputFolder
            // 
            this.tbOutputFolder.Location = new System.Drawing.Point(12, 80);
            this.tbOutputFolder.Name = "tbOutputFolder";
            this.tbOutputFolder.Size = new System.Drawing.Size(493, 20);
            this.tbOutputFolder.TabIndex = 3;
            this.tbOutputFolder.Text = "C:\\Voice\\Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выходной каталог";
            // 
            // tbFtpServer
            // 
            this.tbFtpServer.Location = new System.Drawing.Point(12, 127);
            this.tbFtpServer.Name = "tbFtpServer";
            this.tbFtpServer.Size = new System.Drawing.Size(493, 20);
            this.tbFtpServer.TabIndex = 5;
            this.tbFtpServer.Text = "10.1.137.139";
            // 
            // lbFtpServer
            // 
            this.lbFtpServer.AutoSize = true;
            this.lbFtpServer.Location = new System.Drawing.Point(13, 107);
            this.lbFtpServer.Name = "lbFtpServer";
            this.lbFtpServer.Size = new System.Drawing.Size(66, 13);
            this.lbFtpServer.TabIndex = 4;
            this.lbFtpServer.Text = "FTP-сервер";
            // 
            // tbFtpUser
            // 
            this.tbFtpUser.Location = new System.Drawing.Point(12, 174);
            this.tbFtpUser.Name = "tbFtpUser";
            this.tbFtpUser.Size = new System.Drawing.Size(493, 20);
            this.tbFtpUser.TabIndex = 7;
            this.tbFtpUser.Text = "usr1";
            // 
            // lbFtpUser
            // 
            this.lbFtpUser.AutoSize = true;
            this.lbFtpUser.Location = new System.Drawing.Point(13, 154);
            this.lbFtpUser.Name = "lbFtpUser";
            this.lbFtpUser.Size = new System.Drawing.Size(59, 13);
            this.lbFtpUser.TabIndex = 6;
            this.lbFtpUser.Text = "FTP-логин";
            // 
            // tbFtpPassword
            // 
            this.tbFtpPassword.Location = new System.Drawing.Point(12, 221);
            this.tbFtpPassword.Name = "tbFtpPassword";
            this.tbFtpPassword.Size = new System.Drawing.Size(493, 20);
            this.tbFtpPassword.TabIndex = 9;
            this.tbFtpPassword.Text = "passw1";
            // 
            // lbFtpPassword
            // 
            this.lbFtpPassword.AutoSize = true;
            this.lbFtpPassword.Location = new System.Drawing.Point(13, 201);
            this.lbFtpPassword.Name = "lbFtpPassword";
            this.lbFtpPassword.Size = new System.Drawing.Size(66, 13);
            this.lbFtpPassword.TabIndex = 8;
            this.lbFtpPassword.Text = "FTP-пароль";
            // 
            // tbPointId
            // 
            this.tbPointId.Location = new System.Drawing.Point(12, 268);
            this.tbPointId.Name = "tbPointId";
            this.tbPointId.Size = new System.Drawing.Size(493, 20);
            this.tbPointId.TabIndex = 11;
            this.tbPointId.Text = "KassaTest";
            // 
            // lbPointId
            // 
            this.lbPointId.AutoSize = true;
            this.lbPointId.Location = new System.Drawing.Point(13, 248);
            this.lbPointId.Name = "lbPointId";
            this.lbPointId.Size = new System.Drawing.Size(118, 13);
            this.lbPointId.TabIndex = 10;
            this.lbPointId.Text = "Идентификатор точки";
            // 
            // tbVoiceLevel
            // 
            this.tbVoiceLevel.Location = new System.Drawing.Point(12, 315);
            this.tbVoiceLevel.Name = "tbVoiceLevel";
            this.tbVoiceLevel.Size = new System.Drawing.Size(493, 20);
            this.tbVoiceLevel.TabIndex = 13;
            this.tbVoiceLevel.Text = "0,1";
            // 
            // lbVoiceLevel
            // 
            this.lbVoiceLevel.AutoSize = true;
            this.lbVoiceLevel.Location = new System.Drawing.Point(13, 295);
            this.lbVoiceLevel.Name = "lbVoiceLevel";
            this.lbVoiceLevel.Size = new System.Drawing.Size(280, 13);
            this.lbVoiceLevel.TabIndex = 12;
            this.lbVoiceLevel.Text = "Порог громкости(при каком уровне начинать запись)";
            // 
            // tbSilencePause
            // 
            this.tbSilencePause.Location = new System.Drawing.Point(12, 362);
            this.tbSilencePause.Name = "tbSilencePause";
            this.tbSilencePause.Size = new System.Drawing.Size(493, 20);
            this.tbSilencePause.TabIndex = 15;
            this.tbSilencePause.Text = "500";
            // 
            // lbSilencePause
            // 
            this.lbSilencePause.AutoSize = true;
            this.lbSilencePause.Location = new System.Drawing.Point(13, 342);
            this.lbSilencePause.Name = "lbSilencePause";
            this.lbSilencePause.Size = new System.Drawing.Size(444, 13);
            this.lbSilencePause.TabIndex = 14;
            this.lbSilencePause.Text = "Пауза записи(количество секунд тишины, после которого запись будет остановлена)";
            // 
            // btnSelectTempFolder
            // 
            this.btnSelectTempFolder.Location = new System.Drawing.Point(511, 33);
            this.btnSelectTempFolder.Name = "btnSelectTempFolder";
            this.btnSelectTempFolder.Size = new System.Drawing.Size(35, 23);
            this.btnSelectTempFolder.TabIndex = 16;
            this.btnSelectTempFolder.Text = "...";
            this.btnSelectTempFolder.UseVisualStyleBackColor = true;
            this.btnSelectTempFolder.Click += new System.EventHandler(this.btnSelectTempFolder_Click);
            // 
            // btnSelectOutputFolder
            // 
            this.btnSelectOutputFolder.Location = new System.Drawing.Point(511, 77);
            this.btnSelectOutputFolder.Name = "btnSelectOutputFolder";
            this.btnSelectOutputFolder.Size = new System.Drawing.Size(35, 23);
            this.btnSelectOutputFolder.TabIndex = 17;
            this.btnSelectOutputFolder.Text = "...";
            this.btnSelectOutputFolder.UseVisualStyleBackColor = true;
            this.btnSelectOutputFolder.Click += new System.EventHandler(this.btnSelectOutputFolder_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Записать";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 437);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSelectOutputFolder);
            this.Controls.Add(this.btnSelectTempFolder);
            this.Controls.Add(this.tbSilencePause);
            this.Controls.Add(this.lbSilencePause);
            this.Controls.Add(this.tbVoiceLevel);
            this.Controls.Add(this.lbVoiceLevel);
            this.Controls.Add(this.tbPointId);
            this.Controls.Add(this.lbPointId);
            this.Controls.Add(this.tbFtpPassword);
            this.Controls.Add(this.lbFtpPassword);
            this.Controls.Add(this.tbFtpUser);
            this.Controls.Add(this.lbFtpUser);
            this.Controls.Add(this.tbFtpServer);
            this.Controls.Add(this.lbFtpServer);
            this.Controls.Add(this.tbOutputFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTempFolder);
            this.Controls.Add(this.lbTempFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTempFolder;
        private System.Windows.Forms.TextBox tbTempFolder;
        private System.Windows.Forms.TextBox tbOutputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFtpServer;
        private System.Windows.Forms.Label lbFtpServer;
        private System.Windows.Forms.TextBox tbFtpUser;
        private System.Windows.Forms.Label lbFtpUser;
        private System.Windows.Forms.TextBox tbFtpPassword;
        private System.Windows.Forms.Label lbFtpPassword;
        private System.Windows.Forms.TextBox tbPointId;
        private System.Windows.Forms.Label lbPointId;
        private System.Windows.Forms.TextBox tbVoiceLevel;
        private System.Windows.Forms.Label lbVoiceLevel;
        private System.Windows.Forms.TextBox tbSilencePause;
        private System.Windows.Forms.Label lbSilencePause;
        private System.Windows.Forms.Button btnSelectTempFolder;
        private System.Windows.Forms.Button btnSelectOutputFolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}