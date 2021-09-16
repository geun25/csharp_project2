using System;

namespace WaferLineLib
{
    public delegate void EndCoatingEventHandler(object sender, EndCoatingEventArgs e);
    public class EndCoatingEventArgs : EventArgs
    {
        public int No
        {
            get;
        }

        public int BWCnt
        {
            get;
        }

        public int AWCnt
        {
            get;
        }

        public EndCoatingEventArgs(int no, int bwcnt, int awcnt)
        {
            No = no;
            BWCnt = bwcnt;
            AWCnt = awcnt;
        }
    }
}
