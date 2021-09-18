using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using WaferLineCommLib;
using WaferLineLib;

namespace Central_Control
{
    public partial class CentralForm : Form
    {
        public CentralForm()
        {
            InitializeComponent();
        }

        private void CentralForm_Load(object sender, EventArgs e)
        {
            IPAddress defaddr = MyNetwork.Addresses[0];
            tbox_me_ip.Text = defaddr.ToString();
        }

        FactoryClient fc;

        private void btn_set_fac_Click(object sender, EventArgs e)
        {
            string fip = tbox_fac_ip.Text;
            int fport = int.Parse(tbox_fac_port.Text);
            fc = new FactoryClient(fip, fport);
        }

        private void btn_set_me_Click(object sender, EventArgs e)
        {
            string ip = tbox_me_ip.Text;
            int port = int.Parse(tbox_me_port.Text);
            ControlServer cs = new ControlServer(ip, port);
            cs.AddedLine += Cs_AddedLine;
            cs.AddedWafer += Cs_AddedWafer;
            cs.AsyncStart();
            fc.SendMyInfo(ip, port);
        }

        private void Cs_AddedWafer(object sender, AddWaferEventArgs e)
        {
            if(this.InvokeRequired)
            {
                AddWaferEventHandler dele = Cs_AddedWafer;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                ListViewItem lvi = lvi_dic[e.No];
                lvi.SubItems[1].Text = e.BWCnt.ToString();
                WaferLine wl = lvi.Tag as WaferLine;
                int gap = e.BWCnt - wl.BWCnt;
                wl.InWafer(gap);
            }
        }

        Dictionary<int, ListViewItem> lvi_dic = new Dictionary<int, ListViewItem>();
        private void Cs_AddedLine(object sender, AddLineEventArgs e)
        {
            if(this.InvokeRequired) // 크로스 스레드 문제 해결
            {
                AddLineEventHandler dele = Cs_AddedLine;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                string[] sitems = new string[] { e.No.ToString(), "0" };
                ListViewItem lvi = new ListViewItem(sitems);
                lv_line.Items.Add(lvi);
                lvi_dic[e.No] = lvi;
                WaferLine wl = new WaferLine(e.No);
                lvi.Tag = wl;
            }
        }
    }
}
