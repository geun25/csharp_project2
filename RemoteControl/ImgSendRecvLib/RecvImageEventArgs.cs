using System;
using System.Drawing;
using System.Net;

namespace RemoteControl
{
    public delegate void RecvImageEventHandler(object sender, RecvImageEventArgs e);

    public class RecvImageEventArgs:EventArgs
    {
        public IPEndPoint IPEndPoint
        {
            get;
            private set;
        }

        public IPAddress IPAddress
        {
            get
            {
                return IPEndPoint.Address;
            }
        }

        public string IPAddressStr
        {
            get
            {
                return IPAddress.ToString();
            }
        }

        public int Port
        {
            get
            {
                return IPEndPoint.Port;
            }
        }

        public Image Image
        {
            get;
            private set;
        }

        public Size Size
        {
            get
            {
                return Image.Size;
            }
        }

        public int Width
        {
            get
            {
                return Image.Width;
            }
        }

        public int Height
        {
            get
            {
                return Image.Height;
            }
        }

        public RecvImageEventArgs(IPEndPoint ep, Image image)
        {
            IPEndPoint = ep;
            Image = image;
        }

        public override string ToString()
        {
            return string.Format($"IP:{IPAddressStr} Width:{Width} Height:{Height}");
        }
    }
}
