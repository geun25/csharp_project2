using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemoteControl
{
    public partial class VirtualCursorForm : Form
    {
        public VirtualCursorForm()
        {
            InitializeComponent();
        }

        private void VirtualCursorForm_Load(object sender, EventArgs e)
        {
            Size = new Size(10, 10);
            Remote.Singleton.RecvedKMEvent += Singleton_RecvedKMEvent;
        }

        delegate void ChangeLocationDele(Point now, MsgType mt);

        void ChangeLocation(Point now, MsgType mt)
        {
            if(mt == MsgType.MT_M_MOVE)
            {
                Location = new Point(now.X + 3, now.Y + 3);
            }
        }

        private void Singleton_RecvedKMEvent(object sender, RecvKMEEventArgs e)
        {
            if(this.InvokeRequired)
            {
                object[] objs = new object[] { e.Now, e.MT };
                this.Invoke(new ChangeLocationDele(ChangeLocation), objs);
            }
            else
            {
                ChangeLocation(e.Now, e.MT);
            }
        }
    }
}
