using System;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.IO;

namespace VoiceRecorder
{
    public partial class frmSettingsForm : Form
    {

        public frmMainForm linkform = null;

        public frmSettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {         
            if (File.Exists("settings.ini"))
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("settings.ini");
                tbTempFolder.Text = data["General"]["TempFolder"];
                tbOutputFolder.Text = data["General"]["OutputFolder"];
                tbFtpServer.Text = data["General"]["FtpServer"];
                tbFtpUser.Text = data["General"]["FtpUser"];
                tbFtpPassword.Text = data["General"]["FtpPassword"];
                tbPointId.Text = data["General"]["PointId"];
                tbVoiceLevel.Text = data["General"]["VoiceLevel"];
                tbSilencePause.Text = data["General"]["SilencePause"];                
            }
        }

        public bool Validate()
        {
            bool result = true;

            if (tbTempFolder.Text == "")
            {
                MessageBox.Show("Выберите каталог для временных файлов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            if (tbOutputFolder.Text == "")
            {
                MessageBox.Show("Выберите каталог для выходных файлов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (tbFtpServer.Text == "")
            {
                MessageBox.Show("Введите адрес FTP-сервера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (tbFtpUser.Text == "")
            {
                MessageBox.Show("Введите логин FTP-сервера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (tbFtpPassword.Text == "")
            {
                MessageBox.Show("Введите пароль FTP-сервера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (tbPointId.Text == "")
            {
                MessageBox.Show("Выберите идентификатор точки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (tbVoiceLevel.Text == "")
            {
                MessageBox.Show("Введите порог громкости!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (tbSilencePause.Text == "")
            {
                MessageBox.Show("Введите паузу записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            
            return result;
                 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                var parse = new FileIniDataParser();
                IniData data = new IniData();

                data["General"]["TempFolder"] = tbTempFolder.Text;
                data["General"]["OutputFolder"] = tbOutputFolder.Text;
                data["General"]["FtpServer"] = tbFtpServer.Text;
                data["General"]["FtpUser"] = tbFtpUser.Text;
                data["General"]["FtpPassword"] = tbFtpPassword.Text;
                data["General"]["PointId"] = tbPointId.Text;
                data["General"]["VoiceLevel"] = tbVoiceLevel.Text;
                data["General"]["SilencePause"] = tbSilencePause.Text;                
                parse.WriteFile("settings.ini", data);
                linkform.Start();
                
                this.Close();
            }
        }

        private void SelectFolder(string text)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (text == "temp")
                {
                    tbTempFolder.Text = folderBrowserDialog1.SelectedPath;
                }

                if (text == "output")
                {
                    tbOutputFolder.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void btnSelectTempFolder_Click(object sender, EventArgs e)
        {
            SelectFolder("temp");
        }

        private void btnSelectOutputFolder_Click(object sender, EventArgs e)
        {
            SelectFolder("output");
        }
    }
}
