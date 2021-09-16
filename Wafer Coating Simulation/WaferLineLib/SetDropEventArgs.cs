using System;

namespace WaferLineLib
{
    public delegate void SetDropEventHandler(object sender, SetDropEventArgs e);
    public class SetDropEventArgs : EventArgs
    {
        public int No
        {
            get;
        }

        public int Drop
        {
            get;
        }

        public SetDropEventArgs(int no, int drop)
        {
            No = no;
            Drop = drop;
        }
    }
}
