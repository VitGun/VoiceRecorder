using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using FluentFTP;
using IniParser;
using IniParser.Model;
using System.Net;
using System.Security.AccessControl;

namespace VoiceRecorder
{
    public partial class frmMainForm : Form
    {
        private Recorder recorder = null;
        private VoiceHttpServer server = null;
        private FileSystemWatcher watcher = null;
        public bool HttpStatus = false;
        private string last_file_name = "";
        private string last_ftp_status = "";
        private string ftp_server = "";// Properties.Settings.Default.ftp_server;
        private string ftp_login = "";// Properties.Settings.Default.ftp_login;        
        private string ftp_password = "";// Properties.Settings.Default.ftp_password;
        private string point_id = "";// Properties.Settings.Default.point_id;
        public frmMainForm()
        {
            InitializeComponent();
        }

        private int sendToFtp()
        {
            int result = -1;
            string[] files = Directory.GetFiles(recorder.outputFolder);
            string dateFolder = DateTime.Now.ToString("dd.MM.yyyy");

            FtpClient client = new FtpClient(ftp_server);
            client.Credentials = new NetworkCredential(ftp_login, ftp_password);
            client.Connect();
            if (client.IsConnected)
            {
                if (!client.DirectoryExists(dateFolder))
                {
                    client.CreateDirectory(dateFolder);
                }

                if (!client.DirectoryExists(dateFolder + "\\" + point_id))
                {
                    client.CreateDirectory(dateFolder + "\\" + point_id);
                }
                result = client.UploadFiles(files, dateFolder + "\\" + point_id);
                
                foreach (string file in files)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                        
                    }
                    
                }
            }

            return result;

        }

        public bool Start()
        {
            if (recorder != null)
            {
                recorder.StopListener();
            }

            if (File.Exists("settings.ini"))
            {
                var parse = new FileIniDataParser();
                IniData data = parse.ReadFile("settings.ini");
                recorder = new Recorder();
                recorder.maxSilence = Int32.Parse(data["General"]["SilencePause"]);
                recorder.voiceLevel = float.Parse(data["General"]["VoiceLevel"]);
                recorder.tempFolder = data["General"]["TempFolder"].Replace(@"\", "\\") + "\\";
                recorder.outputFolder = data["General"]["OutputFolder"].Replace(@"\", "\\") + "\\";

                ftp_server = data["General"]["FtpServer"];
                ftp_login = data["General"]["FtpUser"];
                ftp_password = data["General"]["FtpPassword"];
                point_id = data["General"]["PointId"];
                recorder.StartListener();

                try
                {
                    server = new VoiceHttpServer();
                    server.StartListener();
                    HttpStatus = true;

                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                timer1.Enabled = true;
                return true;
            }

            return false;

        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            if (Start())
            {
                watcher = new FileSystemWatcher(recorder.outputFolder, "*.mp3");
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.EnableRaisingEvents = true;
                watcher.Created += Watcher_Created;

                string[] files = Directory.GetFiles(recorder.tempFolder);
                foreach (string file in files)
                {
                    File.Move(file, recorder.outputFolder + "\\" + Path.GetFileName(file));
                }
                last_ftp_status = sendToFtp().ToString();
                
            }
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            new Thread(() =>
            {
                if (ftp_server != "")
                {
                    last_file_name = e.Name;
                    last_ftp_status = sendToFtp().ToString();
                }
            }).Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            recorder.Silence();            
            this.Text = recorder.GetCurrentPeak().ToString();
            progressBar1.Value = Convert.ToInt32(recorder.GetCurrentPeak() * 100);
            label1.Text = recorder.GetCurrentPeak().ToString();
            label2.Text = "Silence: " + recorder.GetSilence().ToString();
            server.status.point_id = point_id;
            server.status.voice_level = recorder.GetCurrentPeak().ToString();
            server.status.last_name = last_file_name;
            server.status.last_ftp_status = last_ftp_status;
            server.status.record_status = recorder.recording.ToString();
            
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void показатьФормуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void msSettings_Click(object sender, EventArgs e)
        {
            frmSettingsForm settingForm = new frmSettingsForm();
            settingForm.linkform = this;
            settingForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
