using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WaferLineCommLib
{
    public class FactoryClient
    {
        string fip;
        int fport;
        public FactoryClient(string fip, int fport)
        {
            this.fip = fip;
            this.fport = fport;
        }

        public void SendMyInfo(string ip, int port)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_CF_ADDSI);
            bw.Write(ip);
            bw.Write(port);
            bw.Close();
            ms.Close();
            SendPacket(packet);
        }

        private void SendPacket(byte[] packet)
        {

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress addr = IPAddress.Parse(fip);
            IPEndPoint ep = new IPEndPoint(addr, fport);
            sock.Connect(ep);
            sock.Send(packet);
            sock.Close();
        }
    }
}
