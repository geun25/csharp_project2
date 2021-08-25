using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteControl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            string ip = tbox_ip.Text;
            SetUpClient.ConnectedEventHandler += SetUpClient_ConnectedEventHandler;
            SetUpClient.ConnectFailedEventHandler += SetUpClient_ConnectFailedEventHandler;
            SetUpClient.Setup(ip, 10200);

        }

        private void SetUpClient_ConnectFailedEventHandler(object sender, EventArgs e)
        {
            MessageBox.Show("연결 요청이 실패하였습니다.");

        }

        private void SetUpClient_ConnectedEventHandler(object sender, EventArgs e)
        {
            MessageBox.Show("연결 요청에 대한 처리를 완료하였습니다.");
        }
    }
}
