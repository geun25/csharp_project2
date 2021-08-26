using System;
using System.Net;

namespace RCEventArgsLib
{
    public delegate void RecvRCInfoEventHandler(object sender, RecvRCInfoEventArgs e);

    public class RecvRCInfoEventArgs : EventArgs
    {
        public IPEndPoint IPEndPoint
        {
            get;
            private set;
        }

        public string IPAddressStr
        {
            get
            {
                return IPEndPoint.Address.ToString();
            }
        }

        public int Port
        {
            get
            {
                return IPEndPoint.Port;
            }
        }

        public RecvRCInfoEventArgs(EndPoint RemoteEndPoint)
        {
            IPEndPoint = RemoteEndPoint as IPEndPoint;
        }
    }
}
