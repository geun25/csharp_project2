using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WaferLineCommLib
{
    public class ControlClient
    {
        IPAddress cip;
        int cport;

        public ControlClient(IPAddress cip, int cport)
        {
            this.cip = cip;
            this.cport = cport;
        }

        public bool SendAddWafer(int no, int bwcnt)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_FC_ADDWF);
            bw.Write(no);
            bw.Write(bwcnt);
            bw.Close();
            ms.Close();
            return SendPacket(packet);
        }

        public bool SendAddLine(int no)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_FC_ADDLN);
            bw.Write(no);
            bw.Close();
            ms.Close();
            return SendPacket(packet);
        }

        bool SendPacket(byte[] packet)
        {
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(cip, cport);
                sock.Connect(ep);
                sock.Send(packet);
                sock.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendAddPr(int no, int pcnt)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_FC_ADDPR);
            bw.Write(no);
            bw.Write(pcnt);
            bw.Close();
            ms.Close();
            return SendPacket(packet);
        }

        public bool SendSetSpeed(int no, int speed)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_FC_SETSP);
            bw.Write(no);
            bw.Write(speed);
            bw.Close();
            ms.Close();
            return SendPacket(packet);
        }

        public bool SendSetDrop(int no, int drop)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_FC_SETDR);
            bw.Write(no);
            bw.Write(drop);
            bw.Close();
            ms.Close();
            return SendPacket(packet);
        }

        public bool SendEndPr(int no)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_FC_ENDPR);
            bw.Write(no);
            bw.Close();
            ms.Close();
            return SendPacket(packet);
        }

        public bool SendEndedCoating(int no, int bwcnt, int awcnt)
        {
            byte[] packet = new byte[128];
            MemoryStream ms = new MemoryStream(packet);
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write((int)MsgType.MSG_FC_ENDCO);
            bw.Write(no);
            bw.Write(bwcnt);
            bw.Write(awcnt);
            bw.Close();
            ms.Close();
            return SendPacket(packet);
        }
    }
}
