using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wind32_Migration
{
    //    WINUSERAPI
    //VOID
    //WINAPI
    //keybd_event(
    //    _In_ BYTE bVk,
    //    _In_ BYTE bScan,
    //    _In_ DWORD dwFlags,
    //    _In_ ULONG_PTR dwExtraInfo);
    class Program
    {
        [DllImport("User32.dll")]

        static extern void keybd_event(byte vk, byte scan, int flag, int extra);

        public static void KeyDown(int keycode)
        {
            keybd_event((byte)keycode, 0, 0, 0);
        }

        public static void KeyUp(int keycode)
        {
            keybd_event((byte)keycode, 0, 2, 0);
        }

        static void Main(string[] args)
        {
            Thread.Sleep(5000);
            KeyDown('T');
            Thread.Sleep(300);
            KeyUp('T');
            Thread.Sleep(300);
            KeyDown('I');
            Thread.Sleep(300);
            KeyUp('I');
            Thread.Sleep(300);
            KeyDown('Q');
            Thread.Sleep(300);
            KeyUp('Q');
            Thread.Sleep(300);
        }
    }
}
