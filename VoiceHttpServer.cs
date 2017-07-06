using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace VoiceRecorder
{

    public struct StatusVoice
    {
       public string point_id;
       public string voice_level;
       public string record_status;
       public string last_name;
       public string last_ftp_status;
    }

    public class VoiceHttpServer
    {
        private bool isListening = false;
        private HttpListener listener = new HttpListener();
        private HttpListenerContext context;
        private HttpListenerRequest request;
        private HttpListenerResponse response;
        private Thread bgThread;
        public StatusVoice status;

        public VoiceHttpServer()
        {
            
        }

        private void SendResponce(HttpListenerResponse responce, string file)
        {
            Console.WriteLine(file);
            bool isPing = false;

            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");

            if (file=="/ping")
            {
                isPing = true;
                string answer = "OK";
                byte[] ok = Encoding.ASCII.GetBytes(answer);
                responce.ContentType = "plain/text";
                responce.OutputStream.Write(ok, 0, ok.Length);                                

            }

            if (file=="/status")
            {
                isPing = true;
                string string_status = JsonConvert.SerializeObject(status);
                responce.ContentType = "application/json";
                byte[] string_bytes = Encoding.UTF8.GetBytes(string_status);
                responce.OutputStream.Write(string_bytes, 0, string_bytes.Length);
            }

            if (!isPing)
            {
                string ServerPath = AppDomain.CurrentDomain.BaseDirectory + @"\HttpContent\";
                string ContentType = "";
                if (File.Exists(ServerPath + file))
                {
                    string Extension = Path.GetExtension(file);
                    if (Extension == ".html")
                    {
                        ContentType = "text/html";
                    }
                    if (Extension == ".png")
                    {
                        ContentType = "png/image";
                    }

                    if (ContentType == "text/html")
                    {
                        string data = File.ReadAllText(ServerPath + file);
                        data = data.Replace("%point_id%", status.point_id);
                        data = data.Replace("%voice_level%", status.voice_level);
                        if (status.record_status.ToLower() == "true")
                        {
                            data = data.Replace("%record_status%", "<font color='green'>Активна</font>");
                        }
                        else
                        {
                            data = data.Replace("%record_status%", "<font color='red'>НЕ АКТИВНА</font>");
                        }

                        data = data.Replace("%last_filename%", status.last_name);

                        if (status.last_ftp_status == "1")
                        {
                            data = data.Replace("%last_ftp_status%", "<font color='green'>Успешна</font>");
                        }
                        else
                        {
                            data = data.Replace("%last_ftp_status%", "<font color='red'>ОШИБКА ПЕРЕДАЧИ ДАННЫХ</font>");
                        }

                        byte[] byteData = Encoding.UTF8.GetBytes(data);

                        responce.ContentType = ContentType;
                        responce.OutputStream.Write(byteData, 0, byteData.Length);
                    }
                    else
                    {
                        response.ContentType = ContentType;
                        byte[] buf = new byte[1024];
                        int Count = 0;
                        FileStream stream = new FileStream(ServerPath + file, FileMode.Open, FileAccess.Read);
                        while (stream.Position < stream.Length)
                        {
                            Count = stream.Read(buf, 0, buf.Length);
                            response.OutputStream.Write(buf, 0, Count);
                        }
                    }
                }
            }
        }

        public void Start()
        {
            listener.Prefixes.Add(string.Format("{0}:{1}/", "http://+", "62575"));
            listener.Start();
            isListening = true;
            while (isListening)
            {
                context = listener.GetContext();
                request = context.Request;
                response = context.Response;
                string requestBody;
                Stream inputStream = request.InputStream;
                Encoding encoding = request.ContentEncoding;
                StreamReader reader = new StreamReader(inputStream, encoding);
                requestBody = reader.ReadToEnd();

                if (request.RawUrl == "/")
                {
                    SendResponce(response, "index.html");
                } else
                {
                    SendResponce(response, request.RawUrl);
                }


                response.StatusCode = (int)HttpStatusCode.OK;
                using (Stream stream = response.OutputStream) { }
            }
        }

        public void StartListener()
        {
            bgThread = new Thread(new ThreadStart(Start));
            bgThread.IsBackground = true;
            bgThread.Name = "VoiceHttpServer";
            bgThread.Start();

        }
        public void StopListener()
        {
            listener.Stop();
            listener.Close();
            isListening = false;
        }

    }
}
