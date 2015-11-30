using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;

namespace VoiceRecorder
{
    public partial class frmMainForm : Form
    {
        private Recorder recorder = null;
        private FileSystemWatcher watcher = null;
        private string ftp_server = Properties.Settings.Default.ftp_server;
        private string ftp_login = Properties.Settings.Default.ftp_login;        
        private string ftp_password =  Properties.Settings.Default.ftp_password;
        private string point_id = Properties.Settings.Default.point_id;
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {            
            recorder = new Recorder();
            recorder.maxSilence = Properties.Settings.Default.maxSilence;
            recorder.voiceLevel = Properties.Settings.Default.minVoice;
            watcher = new FileSystemWatcher(recorder.outputFolder, "*.mp3");
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.EnableRaisingEvents = true;
            watcher.Created += Watcher_Created;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {

            new Thread(() =>
            {
                Ftp ftp = new Ftp(ftp_server, ftp_login, ftp_password, point_id);
                ftp.SendFile(e.FullPath);
            }
                ).Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(recorder.GetCurrentPeak() * 100);
            label1.Text = recorder.GetCurrentPeak().ToString();
        }
    }
}
