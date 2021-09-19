using System.IO;
using System.Net;
using System.Net.Sockets;
using WaferLineLib;

namespace WaferLineCommLib
{
    public class ControlServer
    {
        public event AddLineEventHandler AddedLine;
        public event AddWaferEventHandler AddedWafer;

        string ip;
        int port;

        public ControlServer(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        delegate void StartDele();
        public void AsyncStart()
        {
            StartDele dele = Start;
            dele.BeginInvoke(null, null); // 비동기 실행
        }

        public void Start()
        {
            // 소켓생성
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 소켓을 네트워크 인터페이스와 결합
            IPAddress addr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(addr, port);
            sock.Bind(ep);

            // 백로그 큐 크기 설정
            sock.Listen(5);

            // 클라이언트 연결 요청 대기 및 수랑 Loop
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
                case MsgType.MSG_FC_ADDLN: AddLineProc(br); break;
                case MsgType.MSG_FC_ADDWF: AddWaferProc(br); break;
            }
            br.Close();
            ms.Close();
            dosock.Close();
        }

        private void AddWaferProc(BinaryReader br)
        {
            int no = br.ReadInt32();
            int bwcnt = br.ReadInt32();
            if(AddedWafer != null)
                AddedWafer(this, new AddWaferEventArgs(no, bwcnt));
        }

        private void AddLineProc(BinaryReader br)
        {
            int no = br.ReadInt32();
            if (AddedLine != null)
                AddedLine(this, new AddLineEventArgs(no));
        }
    }
}
