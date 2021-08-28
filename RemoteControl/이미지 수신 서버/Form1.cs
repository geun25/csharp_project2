using RemoteControl;
using System;
using System.Windows.Forms;

namespace 이미지_수신_서버
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ImageServer ims;
        int imgcnt = 0;
        RecvEventServer res;

        private void Form1_Load(object sender, EventArgs e)
        {
            ims = new ImageServer(DefaultIP, 10200);
            ims.RecvedImage += Ims_RecvedImage;
            res = new RecvEventServer(DefaultIP, 10300);
            res.RecvedKMEvent += Res_RecvedKMEvent;
        }

        private void Res_RecvedKMEvent(object sender, RecvKMEEventArgs e)
        {
            string s = e.MT.ToString();
            switch(e.MT)
            {
                case MsgType.MT_KDOWN:               
                case MsgType.MT_KEYUP:
                    s += "" + e.Key.ToString(); break;
                case MsgType.MT_M_MOVE:
                    s+= "" + e.Now.X.ToString() + "" + e.Now.Y.ToString(); break;
            }
            lbox_km.Items.Add(s);
            lbox_km.SelectedIndex = lbox_km.Items.Count - 1;
        }

        private void Ims_RecvedImage(object sender, RecvImageEventArgs e)
        {
            imgcnt++;
            e.Image.Save(string.Format("{0}.bmp", imgcnt));
            listBox1.Items.Add(imgcnt);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            int icnt = (int)listBox1.SelectedItem;
            pictureBox1.ImageLocation = string.Format("{0}.bmp", imgcnt);
        }

        static string DefaultIP
        {
            get
            {
                return "127.0.0.1";
            }
        }
    }
}
