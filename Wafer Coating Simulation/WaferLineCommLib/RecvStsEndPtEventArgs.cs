using System;
using System.Net;

namespace WaferLineCommLib
{
    public delegate void RecvStsEndPtEventHandler(object sender, RecvStsEndPtEventArgs e);
    public class RecvStsEndPtEventArgs : EventArgs
    {
        public IPAddress IPAddress
        {
            get;
        }

        public int Port
        {
            get;
        }

        public RecvStsEndPtEventArgs(IPAddress ipaddr, int port)
        {
            IPAddress = ipaddr;
            Port = port;
        }
    }
}
