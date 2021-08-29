using RCEventArgsLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemoteControl
{
    public partial class MainForm : Form
    {
        string sip;
        int sport;
        RemoteClientForm rcf = null;
        VirtualCursorForm vcf = null;

        public MainForm()
        {
            InitializeComponent();           
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            //string ip = tbox_ip.Text;
            //SetUpClient.ConnectedEventHandler += SetUpClient_ConnectedEventHandler;
            //SetUpClient.ConnectFailedEventHandler += SetUpClient_ConnectFailedEventHandler;
            //SetUpClient.Setup(ip, 10200);
            if(tbox_ip.Text == NetworkInfo.DefaultIP)
            {
                MessageBox.Show("같은 호스트를 원격 제어할 수 없습니다.");
                tbox_ip.Text = string.Empty;
                return;
            }
            string host_ip = tbox_ip.Text;
            Rectangle rect = Remote.Singleton.Rect;
            Controller.Singleton.Start(host_ip);

            rcf.ClientSize = new Size(rect.Width - 40, rect.Height - 80);
            rcf.Show();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
            Remote.Singleton.RecvEventStart();
            timer_send_image.Start();
            vcf.Show();
        }

        private void SetUpClient_ConnectFailedEventHandler(object sender, EventArgs e)
        {
            //MessageBox.Show("연결 요청이 실패하였습니다.");

        }

        private void SetUpClient_ConnectedEventHandler(object sender, EventArgs e)
        {
            //MessageBox.Show("연결 요청에 대한 처리를 완료하였습니다.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //SetUpServer.RecvedRCInfoEventHandler += SetUpServer_RecvedRCInfoEventHandler;
            //SetUpServer.Start("127.0.0.1", 10200);
            Text += "" + NetworkInfo.DefaultIP;
            vcf = new VirtualCursorForm();
            rcf = new RemoteClientForm();
            Remote.Singleton.RecvedRCInfo += Singleton_RecvedRCInfo;
        }

        //private void SetUpServer_RecvedRCInfoEventHandler(object sender, RecvRCInfoEventArgs e)
        //{
        //    tbox_contoller_ip.Text = e.IPAddressStr;
        //}

        delegate void Remote_Dele(object sender, RecvRCInfoEventArgs e);

        private void Singleton_RecvedRCInfo(object sender, RecvRCInfoEventArgs e)
        {
            if(this.InvokeRequired)
            {
                object[] objs = new object[2] { sender, e };
                this.Invoke(new Remote_Dele(Singleton_RecvedRCInfo), objs);
            }
            else
            {
                tbox_contoller_ip.Text = e.IPAddressStr;
                sip = e.IPAddressStr;
                sport = e.Port;
                btn_ok.Enabled = true;
            }
        }

        private void timer_send_image_Tick(object sender, EventArgs e)
        {
            Rectangle rect = Remote.Singleton.Rect;
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            Size size2 = new Size(rect.Width, rect.Height);
            graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), size2);
            graphics.Dispose();

            try
            {
                ImageClient ic = new ImageClient();
                ic.Connect(sip, NetworkInfo.ImgPort);
                ic.SendImageAsync(bitmap, null);
            }
            catch
            {
                timer_send_image.Stop();
                MessageBox.Show("서버에 문제가 있는것 같아요.");
                this.Close();
            }
        }

        private void noti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Remote.Singleton.Stop();
            Controller.Singleton.Stop();
            Application.Exit();
        }
    }
}
