using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace VoiceRecorder
{
    class Ftp
    {
        private FtpWebRequest _ftp = null;
        private Uri fullpath = null;

        public string server;
        public string login;
        public string password;
        public string point_id;

        public Ftp(string server,string login,string password,string point_id)
        {
            this.server = server;
            this.login = login;
            this.password = password;
            this.point_id = point_id;
        }

        public Uri CreateShortURI()
        {
            return fullpath = new Uri(String.Format("{0}\\{1}\\", server, DateTime.Now.ToString("dd.MM.yyyy")));
        }


        public Uri CreateFullURI()
        {
            return fullpath = new Uri(String.Format("{0}\\{1}\\{2}\\", server, DateTime.Now.ToString("dd.MM.yyyy"), this.point_id));
        }

        private FtpWebRequest getConnect(Uri uri)
        {
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(uri);
            ftp.Credentials = new NetworkCredential(login, password);
            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.Proxy = null;
            return ftp;
        }

        public void CreateFolder(Uri uri)
        {            
            _ftp = getConnect(uri);
            _ftp.Method = WebRequestMethods.Ftp.ListDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)_ftp.GetResponse();
                response.Close();
            }catch
            {
                _ftp = getConnect(uri);
                _ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)_ftp.GetResponse();
                response.Close();
            }
        }

        public void CheckFolder()
        {
            CreateFolder(CreateShortURI());
            CreateFolder(CreateFullURI());
        }

        public void SendFile(string filename)
        {
            CheckFolder();
            fullpath = new Uri(String.Format("{0}\\{1}\\{2}\\{3}", server, DateTime.Now.ToString("dd.MM.yyyy"), point_id, Path.GetFileName(filename)));
            _ftp = getConnect(fullpath);
            _ftp.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream source = new FileStream(filename, FileMode.Open);
            byte[] content = new byte[source.Length];
            source.Read(content, 0, content.Length);
            source.Close();
            _ftp.ContentLength = content.Length;
            Stream requestStream = _ftp.GetRequestStream();
            requestStream.Write(content, 0, content.Length);
            requestStream.Close();
        }
    }
}
