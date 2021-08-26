using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    public class ImageClient
    {
        Socket sock;
        public void Connect(string ip, int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            sock.Connect(ep);
        }

       
        public bool SendImage(Image img)
        {
            if(sock == null)
            {
                return false;
            }
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            byte[] data = ms.GetBuffer();
            try
            {
                int trans = 0;
                byte[] Ibuf = BitConverter.GetBytes(data.Length);
                sock.Send(Ibuf); // 전송할 이미지 길이를 먼저 전송

                while(trans < data.Length)
                {
                    //sock.Send(data, SocketFlags.None);
                    trans += sock.Send(data, trans, data.Length - trans, SocketFlags.None);
                }
                sock.Close();
                sock = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SendImageAsync(Image img, AsyncCallback callback)
        {
            SendImageDele dele = SendImage;
            dele.BeginInvoke(img, callback, this);
        }

        public void Close()
        {
            if(sock != null)
            {
                sock.Close();
                sock = null;
            }
        }
    }
    public delegate bool SendImageDele(Image img);
}
