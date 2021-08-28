using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

// 키보드 마우스 이벤트 수신 서버 구현
namespace RemoteControl
{
    public class RecvEventServer
    {
        Socket lis_sock;
        public event RecvKMEEventHandler RecvedKMEvent = null;

        public RecvEventServer(string ip, int port)
        {
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock.Bind(ep);
            lis_sock.Listen(5);
            lis_sock.BeginAccept(DoAccept, null);
        }

        void DoAccept(IAsyncResult result)
        {
            if(lis_sock != null)
            {
                Socket dosock = lis_sock.EndAccept(result);
                lis_sock.BeginAccept(DoAccept, null);
                Receive(dosock);
            }
        }

        private void Receive(Socket dosock)
        {
            byte[] buffer = new byte[9];
            int n = dosock.Receive(buffer);
            if(RecvedKMEvent != null)
            {
                RecvKMEEventArgs e = new RecvKMEEventArgs(new Meta(buffer));
                RecvedKMEvent(this, e);
            }
            dosock.Close();
        }

        public void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null;
            }
        }
    }
}
