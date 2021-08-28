using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    public static class NetworkInfo
    {
        public static short ImgPort
        {
            get
            {
                return 20004;
            }
        }

        public static short SetupPort
        {
            get
            {
                return 20002;
            }
        }

        public static short EventPort
        {
            get
            {
                return 20010;
            }
        }

        public static string DefaultIP
        {
            get
            {
                string host_name = Dns.GetHostName();
                IPHostEntry host_entry = Dns.GetHostEntry(host_name);
                foreach(IPAddress ipaddr in host_entry.AddressList)
                {
                    if(ipaddr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ipaddr.ToString();
                    }
                }
                return "127.0.0.1";
            }          
        }
    }
}
