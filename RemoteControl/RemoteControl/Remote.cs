using RCEventArgsLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace RemoteControl
{
    public class Remote
    {
        static Remote singleton;
        public static Remote Singleton
        {
            get
            {
                return singleton;
            }
        }

        static Remote()
        {
            singleton = new Remote();
        }

        private Remote() // 외부에서 개체생성을 못하게 함.
        {
            AutomationElement ae = AutomationElement.RootElement;
            System.Windows.Rect rt = ae.Current.BoundingRectangle;
            Rect = new Rectangle((int)rt.Left,(int)rt.Top,(int)rt.Width,(int)rt.Height);

            SetUpServer.RecvedRCInfoEventHandler += SetUpServer_RecvedRCInfoEventHandler;
            SetUpServer.Start(MyIP, NetworkInfo.SetupPort);
        }

        public string MyIP
        {
            get
            {
                return NetworkInfo.DefaultIP;
            }
        }

        private void SetUpServer_RecvedRCInfoEventHandler(object sender, RecvRCInfoEventArgs e)
        {
            RecvedRCInfo(this, e);
        }

        public event RecvRCInfoEventHandler RecvedRCInfo = null;
        public event RecvKMEEventHandler RecvedKMEvent = null;
        RecvEventServer res = null;
        
        public Rectangle Rect
        {
            get;
            private set;
        }

        public void RecvEventStart()
        {
            res = new RecvEventServer(MyIP, NetworkInfo.EventPort);
            res.RecvedKMEvent += Res_RecvedKMEvent;
        }

        private void Res_RecvedKMEvent(object sender, RecvKMEEventArgs e)
        {
            if(RecvedKMEvent != null)
            {
                RecvedKMEvent(this, e);
            }
            switch(e.MT)
            {
                case MsgType.MT_KDOWN: WrapNative.KeyDown(e.Key); break;
                case MsgType.MT_KEYUP: WrapNative.KeyUp(e.Key); break;
                case MsgType.MT_M_LEFTDOWN: WrapNative.LeftDown(); break;
                case MsgType.MT_M_LEFTUP: WrapNative.LeftUp(); break;
                case MsgType.MT_M_MOVE: WrapNative.Move(e.Now); break;
            }
        }

        public void Stop()
        {
            SetUpServer.Close();
            if(res != null)
            {
                res.Close();
                res = null;
            }
        }
    }
}
