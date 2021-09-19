using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WaferLineCommLib;
using WaferLineLib;

namespace WaferLine_Factory_Simulation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int next_lineno = 1;
        Dictionary<int, WaferLineForm> wdic = new Dictionary<int, WaferLineForm>();

        private void btn_add_Click(object sender, EventArgs e)
        {
            int no = next_lineno;
            next_lineno++;
            WaferLine wl = new WaferLine(no);
            string[] sitems = new string[] { no.ToString(), "0", "0" };
            ListViewItem lvi = new ListViewItem(sitems);
            lvi.Tag = wl; // wafer No를 보관
            lv_line.Items.Add(lvi);
            cb_line.Items.Add(wl);
            lb_next_no.Text = next_lineno.ToString();

            WaferLineForm wlf = new WaferLineForm(wl);

            #region 이벤트 핸들러 추가
            wlf.EndedCoating += Wlf_EndedCoating;
            wlf.AddedWafer += Wlf_AddedWafer;
            wlf.AddedPr += Wlf_AddedPr;
            wlf.SettedSpin += Wlf_SettedSpin;
            wlf.SettedDrop += Wlf_SettedDrop;
            wlf.EndedPr += Wlf_EndedPr;
            #endregion

            wdic.Add(no, wlf);
        }

        private void Wlf_EndedPr(object sender, EndPrEventArgs e)
        {
            ListViewItem lvi = lv_line.Items[e.No - 1];
            if (lvi.Selected)
            {
                WaferLine wl = lvi.Tag as WaferLine;
                lb_pr.Text = wl.PCnt.ToString();
            }
        }

        private void Wlf_SettedDrop(object sender, SetDropEventArgs e)
        {
            ChangeStatusSelectedWaferLine(e.No);
        }
       
        private void Wlf_SettedSpin(object sender, SetSpinEventArgs e)
        {
            ChangeStatusSelectedWaferLine(e.No);
        }

        private void Wlf_AddedPr(object sender, AddPrEventArgs e)
        {
            ChangeStatusSelectedWaferLine(e.No);
        }

        private void ChangeStatusSelectedWaferLine(int no)
        {
            ListViewItem lvi = lv_line.Items[no - 1];
            if (lvi.Selected)
            {
                WaferLine wl = lvi.Tag as WaferLine;
                lb_spin.Text = wl.Spin.ToString();
                lb_drop.Text = wl.Drop.ToString();
                lb_pr.Text = wl.PCnt.ToString();
            }
        }

        private void Wlf_AddedWafer(object sender, AddWaferEventArgs e)
        {
            ChangeStatusWaferLine(e.No);
        }

        void ChangeStatusWaferLine(int no) // 리스트뷰에서 선택되지 않아도 값이 바뀜
        {
            ListViewItem lvi = lv_line.Items[no - 1];
            WaferLine wl = lvi.Tag as WaferLine;
            lvi.SubItems[1].Text = wl.BWCnt.ToString();
            lvi.SubItems[2].Text = wl.AWCnt.ToString();
            cb_line.Items[no - 1] = wl;
        }

        private void Wlf_EndedCoating(object sender, EndCoatingEventArgs e)
        {
            ChangeStatusWaferLine(e.No);
            ListViewItem lvi = lv_line.Items[e.No - 1];
            if (lvi.Selected)
            {
                WaferLine wl = lvi.Tag as WaferLine;
                cb_awafer.Items.Add(wl.LastWafer);
                lb_pr.Text = wl.PCnt.ToString();
            }
        }

        private void btn_manage_Click(object sender, EventArgs e)
        {
            if (cb_line.SelectedIndex == -1)
                return;
            WaferLine wl = cb_line.SelectedItem as WaferLine;
            if(wdic[wl.No].Visible == false)
            {
                wdic[wl.No].Show(); // 시각화
            }
        }

        private void cb_awafer_SelectedIndexChanged(object sender, EventArgs e)
        {
            pn_awafer.Wafer = cb_awafer.SelectedItem as Wafer;
            pn_awafer.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cb_ip.DataSource = MyNetwork.Addresses;
            Manager manager = Manager.Singleton; // 단일체 참조
            manager.RecvStsEndPoint += Manager_RecvStsEndPoint;
        }

        private void Manager_RecvStsEndPoint(object sender, RecvStsEndPtEventArgs e)
        {
            if(this.InvokeRequired) // 크로스 스레드 문제 해결
            {
                RecvStsEndPtEventHandler dele = Manager_RecvStsEndPoint;
                this.Invoke(dele, new object[] { sender, e });
            }
            else
            {
                Manager manager = Manager.Singleton;
                foreach(ListViewItem lvi in lv_line.Items)
                {
                    int no = int.Parse(lvi.SubItems[0].Text);
                    manager.AddLine(no);
                    manager.AddWafer(no, int.Parse(lvi.SubItems[1].Text));
                }
                ts_lb.Text = string.Format($"{e.IPAddress}:{e.Port}연결");
            }
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            int port = int.Parse(tb_port.Text);
            string ip = cb_ip.Text;
            Manager manager = Manager.Singleton;
            manager.StartServer(ip, port);
        }
    }
}
