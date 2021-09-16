using System;

namespace WaferLineLib
{
    public delegate void EndPrEventHandler(object sender, EndPrEventArgs e);
    public class EndPrEventArgs : EventArgs
    {
        public int No
        {
            get;
        }

        public EndPrEventArgs(int no)
        {
            No = no;
        }
    }
}
