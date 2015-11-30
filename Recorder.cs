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
        private string tempFolder = @"\write\";
        private string currentFileName = "";
        private Thread soundThread;
        public float voiceLevel = 0.04f;
        public int silence = 0;
        public int maxSilence = 15000;
        public string outputFolder = @"\ready\";

        public Recorder()
        {
            wavein = new WaveIn();
            wavein.DeviceNumber = 0;
            wavein.WaveFormat = new WaveFormat();
            devEnum = new MMDeviceEnumerator();
            defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
            wavein.DataAvailable += Wavein_DataAvailable;
            checkFolders();
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
            return String.Format("{0:dd - MM - yyyy}{1:HH-mm-ss}({2}).mp3", DateTime.Now, DateTime.Now, rand.Next().ToString());
        }

        private void Wavein_DataAvailable(object sender, WaveInEventArgs e)
        {
            float level = this.GetCurrentPeak();
            if (level > voiceLevel)
            {
                if (writer != null)
                {
                    writer.Write(e.Buffer, 0, e.BytesRecorded);
                }
                else
                {
                    currentFileName = GetNextFileName();
                    writer = new LameMP3FileWriter(currentFileName, wavein.WaveFormat, LAMEPreset.MEDIUM_FAST);
                }
            }
        }

        private void Silence()
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
                File.Move(tempFolder + currentFileName, this.outputFolder + currentFileName);
            }
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
            soundThread.Suspend();
            this.wavein.StopRecording();
        }

        public float GetCurrentPeak()
        {
            return this.defaultDevice.AudioMeterInformation.MasterPeakValue;
        }

    }
}
