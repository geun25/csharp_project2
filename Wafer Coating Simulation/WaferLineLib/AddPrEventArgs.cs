using System;

namespace WaferLineLib
{
    public delegate void AddPrEventHandler(object sender, AddPrEventArgs e);
    public class AddPrEventArgs : EventArgs
    {
        public int No
        {
            get;
        }

        public int PCnt
        {
            get;
        }

        public AddPrEventArgs(int no, int pcnt)
        {
            No = no;
            PCnt = pcnt;
        }
    }
}
