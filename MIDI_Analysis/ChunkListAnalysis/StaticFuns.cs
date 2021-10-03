using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChunkListAnalysis
{
    public static class StaticFuns
    {
        public static string GetString(int magic)
        {
            byte[] data = BitConverter.GetBytes(magic);
            ASCIIEncoding en = new ASCIIEncoding();
            return en.GetString(data);
        }

        // byte order = big / little endian
        public static int ConvertHostorder(int data)
        {
            return IPAddress.NetworkToHostOrder(data);
        }
    }
}
