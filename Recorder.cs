using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Lame;
using System.Threading;
using System.IO;
using System;

namespace VoiceRecorder
{
    class Recorder
    {
        private WaveIn wavein { get; }
        private LameMP3FileWriter writer = null;
        private MMDeviceEnumerator devEnum { get; }
        private MMDevice defaultDevice { get; }
        public string tempFolder = @"C:\Voice\Temp\";
        private string currentFileName = "";
        public bool recording = false;
        private Thread soundThread;
        public float voiceLevel = 0.01f;
        public int silence = 0;
        public int maxSilence = 500;
        public string outputFolder = @"C:\Voice\Output\";

        public Recorder()
        {
            wavein = new WaveIn();
            wavein.DeviceNumber = 0;
            wavein.WaveFormat = new WaveFormat();            
            devEnum = new MMDeviceEnumerator();
            defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
            wavein.DataAvailable += Wavein_DataAvailable;
            //checkFolders();
        }

        public void checkFolders()
        {
            string root = Environment.CurrentDirectory;

            if (!Directory.Exists(root + tempFolder))
            {
                Directory.CreateDirectory(root + tempFolder);
            }
            
            if (!Directory.Exists(root + outputFolder))
            {
                Directory.CreateDirectory(root + outputFolder);
            }
        }

        public string GetNextFileName()
        {
            var rand = new Random();
            return String.Format("{0:dd - MM - yyyy}_{1:HH-mm-ss}_({2}).mp3", DateTime.Now, DateTime.Now, rand.Next().ToString());
        }

        private void Wavein_DataAvailable(object sender, WaveInEventArgs e)
        {            
            float level = this.GetCurrentPeak();
            if (level > voiceLevel)
            {
                recording = true;
                silence = 0;
            }
            if (recording) { 
                if (writer != null)
                {
                    writer.Write(e.Buffer, 0, e.BytesRecorded);
                }
                else
                {
                    currentFileName = GetNextFileName();
                    writer = new LameMP3FileWriter(tempFolder+currentFileName, wavein.WaveFormat, LAMEPreset.MEDIUM_FAST);
                }
            }
        }

        public void Silence()
        {
            if (GetCurrentPeak() < voiceLevel)
            {
                silence++;
            }

            if (silence > maxSilence && writer != null)
            {
                writer.Dispose();
                writer = null;
                silence = 0;
                recording = false;
                File.Move(tempFolder + currentFileName, outputFolder + currentFileName);
            }
        }

        public int GetSilence()
        {
            return this.silence;
        }

        private void StartSilence()
        {

        }

        public void StartListener()
        {            
            soundThread = new Thread(wavein.StartRecording);
            soundThread.Priority = ThreadPriority.Normal;
            soundThread.Start();
        }

        public void StopListener()
        {
            //soundThread.Suspend();
            this.wavein.StopRecording();
        }

        public float GetCurrentPeak()
        {
            return this.defaultDevice.AudioMeterInformation.MasterPeakValue;
        }

    }
}
