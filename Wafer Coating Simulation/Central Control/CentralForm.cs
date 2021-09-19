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
            cs.AddedPr += Cs_AddedPr;
            cs.SettedSpeed += Cs_SettedSpeed;
            cs.SettedDrop += Cs_SettedDrop;
            cs.EndedPr += Cs_EndedPr;
            cs.EndedCoating += Cs_EndedCoating;
            cs.AsyncStart();
            fc.SendMyInfo(ip, port);
        }

        private void Cs_EndedCoating(object sender, EndCoatingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                EndCoatingEventHandler dele = Cs_EndedCoating;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                ListViewItem lvi = lvi_dic[e.No];
                WaferLine wl = lvi.Tag as WaferLine;
                wl.EndCoating(e.BWCnt, e.AWCnt);
                lvi.SubItems[1].Text = e.BWCnt.ToString();
                if (lvi.Selected)
                {
                    lb_awafer.Text = e.AWCnt.ToString();
                }
            }
        }

        private void Cs_EndedPr(object sender, EndPrEventArgs e)
        {
            if (this.InvokeRequired)
            {
                EndPrEventHandler dele = Cs_EndedPr;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                ListViewItem lvi = lvi_dic[e.No];
                WaferLine wl = lvi.Tag as WaferLine;
                wl.PCnt--;
                if (lvi.Selected)
                {
                    lb_npr.Text = wl.PCnt.ToString();
                }
            }
        }

        private void Cs_SettedDrop(object sender, SetDropEventArgs e)
        {
            if (this.InvokeRequired)
            {
                SetDropEventHandler dele = Cs_SettedDrop;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                ListViewItem lvi = lvi_dic[e.No];
                WaferLine wl = lvi.Tag as WaferLine;
                wl.Drop = e.Drop;
                if (lvi.Selected)
                {
                    lb_drop.Text = wl.Drop.ToString();
                    tbar_drop.Value = e.Drop;
                }
            }
        }

        private void Cs_SettedSpeed(object sender, SetSpinEventArgs e)
        {
            if (this.InvokeRequired)
            {
                SetSpinEventHandler dele = Cs_SettedSpeed;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                ListViewItem lvi = lvi_dic[e.No];
                WaferLine wl = lvi.Tag as WaferLine;
                wl.Spin = e.Spin;
                if (lvi.Selected)
                {
                    lb_spin.Text = wl.Spin.ToString();
                    tbar_spin.Value = e.Spin;
                }
            }
        }

        private void Cs_AddedPr(object sender, AddPrEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AddPrEventHandler dele = Cs_AddedPr;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                ListViewItem lvi = lvi_dic[e.No];
                WaferLine wl = lvi.Tag as WaferLine;
                int gap = e.PCnt - wl.PCnt;
                wl.InPr(gap);
                if (lv_line.SelectedItems.Count == 0)
                    return;
                if (lvi == lv_line.SelectedItems[0])
                {
                    lb_npr.Text = wl.PCnt.ToString();
                }
            }
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

        private void lv_line_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_line.SelectedItems.Count == 0)
            {
                SetLineControl(false);
                return;
            }
            SetLineControl(true);
            ListViewItem lvi = lv_line.SelectedItems[0];
            WaferLine wl = lvi.Tag as WaferLine;
            lb_npr.Text = wl.PCnt.ToString();
            tbar_spin.Value = wl.Spin;
            tbar_drop.Value = wl.Drop;
            lb_spin.Text = wl.Spin.ToString();
            lb_drop.Text = wl.Drop.ToString();
        }

        private void SetLineControl(bool flag)
        {
            tbar_wafer.Enabled = flag;
            tbar_pr.Enabled = flag;
            tbar_spin.Enabled = flag;
            tbar_drop.Enabled = flag;
            btn_wafer.Enabled = flag;
            btn_pr.Enabled = flag;
        }

        private void btn_wafer_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lv_line.SelectedItems[0];
            WaferLine wl = lvi.Tag as WaferLine;
            int wcnt = tbar_wafer.Value;
            fc.SendAddWafer(wl.No, wcnt);
            tbar_wafer.Value = 0;
        }

        private void btn_pr_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lv_line.SelectedItems[0];
            WaferLine wl = lvi.Tag as WaferLine;
            int pcnt = tbar_pr.Value;
            fc.SendAddPr(wl.No, pcnt);
            tbar_pr.Value = 0;
        }

        private void tbar_wafer_Scroll(object sender, EventArgs e)
        {
            lb_wafer.Text = tbar_wafer.Value.ToString();
        }

        private void tbar_pr_Scroll(object sender, EventArgs e)
        {
            lb_pr.Text = tbar_pr.Value.ToString();

        }

        private void tbar_spin_Scroll(object sender, EventArgs e)
        {
            ListViewItem lvi = lv_line.SelectedItems[0];
            WaferLine wl = lvi.Tag as WaferLine;
            int spin = tbar_spin.Value;
            lb_spin.Text = spin.ToString();
            fc.SendSetSpin(wl.No, spin);
        }

        private void tbar_drop_Scroll(object sender, EventArgs e)
        {
            ListViewItem lvi = lv_line.SelectedItems[0];
            WaferLine wl = lvi.Tag as WaferLine;
            int drop = tbar_drop.Value;
            lb_drop.Text = drop.ToString();
            fc.SendSetDrop(wl.No, drop);
        }
    }
}
