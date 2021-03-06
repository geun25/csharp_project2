using RCEventArgsLib;
using System;
using System.Net;
using System.Net.Sockets;

namespace RemoteControl
{
    class SetUpServer
    {
        static Socket lis_sock;
        static public event RecvRCInfoEventHandler RecvedRCInfoEventHandler = null;
        static string ip;
        static int port;

        public static void Start(string ip, int port)
        {
            SetUpServer.ip = ip;
            SetUpServer.port = port;
            SocketBooting();
        }

        private static void SocketBooting()
        {
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            lis_sock.Bind(ep);
            lis_sock.Listen(1);
            lis_sock.BeginAccept(DoAccept, null); // 비동기 처리
        }

        internal static void Start(object myIP, NetworkInfo networkInfo)
        {
            throw new NotImplementedException();
        }

        internal static void Start(object net)
        {
            throw new NotImplementedException();
        }

        static void DoAccept(IAsyncResult result)
        {
            if(lis_sock == null)
            {
                return;
            }
            try
            {
                Socket sock = lis_sock.EndAccept(result);
                DoIt(sock);
                lis_sock.BeginAccept(DoAccept, null);
            }
            catch
            {
                Close();
            }
        }

        static void DoIt(Socket dosock)
        {
            if(RecvedRCInfoEventHandler != null)
            {
                RecvRCInfoEventArgs e = new RecvRCInfoEventArgs(dosock.RemoteEndPoint);
                RecvedRCInfoEventHandler(null, e);
            }
            dosock.Close();
        }

        public static void Close()
        {
            if (lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null;
            }
        }
    }
}
