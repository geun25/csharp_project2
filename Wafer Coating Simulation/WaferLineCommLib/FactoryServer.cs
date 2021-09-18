using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WaferLineCommLib
{
    public class FactoryServer
    {
        public event RecvStsEndPtEventHandler RecvStsEndPoint;

        public string IP
        {
            get;
        }

        public int Port
        {
            get;
        }

        public FactoryServer(string ip, int port)
        {
            IP = ip;
            Port = port;
        }

        delegate void StartDele(); // blocking 방지
        public void StartAsync()
        {
            StartDele dele = Start;
            dele.BeginInvoke(null, null); // 비동기 실행
        }

        Socket sock;
        public void Start()
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress addr = IPAddress.Parse(IP);
            IPEndPoint endp = new IPEndPoint(addr, Port);
            sock.Bind(endp);
            sock.Listen(5); // 백로그 큐 설정 
            AcceptLoop(); // 서버가 끝날때까지 계속 수행
        }

        private void AcceptLoop()
        {
            while(true)
            {
                Socket dosock = sock.Accept();
                DoIt(dosock);
            }
        }

        private void DoIt(Socket dosock)
        {
            byte[] packet = new byte[128];
            dosock.Receive(packet);
            MemoryStream ms = new MemoryStream(packet);
            BinaryReader br = new BinaryReader(ms);
            MsgType msgtype = (MsgType)br.ReadInt32();
            switch(msgtype)
            { 
                case MsgType.MSG_CF_ADDSI: SetAddressProc(br);
                    break;
            }
            br.Close();
            ms.Close();
            dosock.Close();
        }

        private void SetAddressProc(BinaryReader br)
        {
            IPAddress ipaddr = IPAddress.Parse(br.ReadString());
            int port = br.ReadInt32();
            if(RecvStsEndPoint != null)
                RecvStsEndPoint(this, new RecvStsEndPtEventArgs(ipaddr, port));
        }
    }
}
