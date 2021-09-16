using System;

namespace WaferLineLib
{
    public delegate void SetSpinEventHandler(object sender, SetSpinEventArgs e);
    public class SetSpinEventArgs : EventArgs
    {
        public int No
        {
            get;
        }

        public int Spin
        {
            get;
        }

        public SetSpinEventArgs(int no, int spin)
        {
            No = no;
            Spin = spin;
        }
    }
}
