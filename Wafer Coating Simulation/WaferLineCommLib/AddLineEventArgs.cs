using System;

namespace WaferLineCommLib
{
    public delegate void AddLineEventHandler(object sender, AddLineEventArgs e);)
    public class AddLineEventArgs : EventArgs
    {
        public int No
        {
            get;
        }

        public AddLineEventArgs(int no)
        {
            No = no;
        }
    }
}
