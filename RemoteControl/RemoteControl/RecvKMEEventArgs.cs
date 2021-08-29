using System;
using System.Drawing;

// 키보드 마우스 이벤트 수신 정보를 처리할 이벤트 인자 클래스 및 대리자 구현
namespace RemoteControl
{
    public delegate void RecvKMEEventHandler(object sender, RecvKMEEventArgs e);

    public class RecvKMEEventArgs:EventArgs
    {
        public Meta Meta
        {
            get;
            private set;
        }

        public int Key
        {
            get
            {
                return Meta.Key;
            }
        }

        public Point Now
        {
            get
            {
                return Meta.Now;
            }
        }

        public MsgType MT
        {
            get
            {
                return Meta.MT;
            }
        }

        public RecvKMEEventArgs(Meta meta)
        {
            Meta = meta;
        }
    }
}
