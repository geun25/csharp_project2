using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace RemoteControl
{
    public class ImageServer
    {
        Socket lis_sock;
        public event RecvImageEventHandler RecvedImage = null;

        public ImageServer(string ip, int port)
        {
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock.Bind(ep);
            lis_sock.Listen(5); // 연결 요청 허용수
            lis_sock.BeginAccept(DoAccept, null);
        }

        void DoAccept(IAsyncResult result)
        {
            if (lis_sock == null)
            {
                return;
            }
            try
            {
                Socket dosock = lis_sock.EndAccept(result);
                Receive(dosock);
                lis_sock.BeginAccept(DoAccept, null);
            }
            catch
            {
                Close();
            }
        }

        public void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null;
            }
        }

        private void Receive(Socket dosock)
        {
            byte[] Ibuf = new byte[4];
            dosock.Receive(Ibuf);

            int len = BitConverter.ToInt32(Ibuf, 0);
            byte[] buffer = new byte[len];
            int trans = 0;
            //dosock.Receive(buffer, 0, len, SocketFlags.None);
            while(trans<len)
            {
                trans += dosock.Receive(buffer, trans, len - trans, SocketFlags.None);
            }

            if(RecvedImage != null)
            {
                IPEndPoint ep = dosock.RemoteEndPoint as IPEndPoint;
                RecvImageEventArgs e = new RecvImageEventArgs(ep, ConvertBitmap(buffer));
                RecvedImage(this, e);
            }
        }

        public Bitmap ConvertBitmap(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, (int)data.Length);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }
    }
}
