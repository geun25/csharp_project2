using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;

namespace RemoteControl
{
    public static class SetUpClient
    {
        public static event EventHandler ConnectedEventHandler = null;
        public static event EventHandler ConnectFailedEventHandler = null;
        static Socket sock;

        public static void Setup(string ip, int port)
        {
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //sock.Connect(ep);
            sock.BeginConnect(ep, DoConnect, null);
        }

        static void DoConnect(IAsyncResult result)
        {
            AsyncResult ar = result as AsyncResult;
            try
            {
                sock.EndConnect(result);
                if (ConnectedEventHandler != null)
                    ConnectedEventHandler(null, new EventArgs());
            }
            catch
            {
                // 예외 처리를 위한 작업
                if (ConnectFailedEventHandler != null)
                    ConnectFailedEventHandler(null, new EventArgs());
            }
            sock.Close();
        }

    }
}
