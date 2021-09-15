using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WaferLineLib;

namespace WaferLineControlLib
{
    public partial class WaferLineControl: UserControl
    {
        WaferLine wl = null;
        public WaferLine Line
        {
            get
            {
                return wl;
            }
            set
            {
                wl = value;
            }
        }

        public WaferLineControl()
        {
            InitializeComponent();
        }

        private void tbar_wafer_Scroll(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            lb_wafer.Text = tbar_wafer.Value.ToString();
        }

        private void tbar_pr_Scroll(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            lb_pr.Text = tbar_pr.Value.ToString();
        }

        private void btn_wafer_Click(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            int bwcnt = tbar_wafer.Value;
            if (bwcnt > (tbar_wafer.Maximum - wl.BWCnt))
                bwcnt = tbar_wafer.Maximum - wl.BWCnt;

            wl.InWafer(bwcnt);
            tbar_wafer.Value = 0;
            lb_wafer.Text = "0";
            pn_wafer.Invalidate();
            ts_lb.Text = string.Format($"Wafer {bwcnt}개 투입, 현재 {wl.BWCnt}개");
            lb_wcnt.Text = wl.BWCnt.ToString();
        }

        private void btn_pr_Click(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            int pcnt = tbar_pr.Value;
            if (pcnt > (tbar_pr.Maximum - wl.PCnt))
                pcnt = tbar_pr.Maximum - wl.PCnt;

            wl.InWafer(pcnt);
            tbar_pr.Value = 0;
            lb_pr.Text = "0";
            pn_pr.Invalidate();
            ts_lb.Text = string.Format($"코팅액 {pcnt}병 투입, 현재 {wl.PCnt}개");
            lb_pcnt.Text = wl.PCnt.ToString();
        }

        private void tbar_spin_Scroll(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            lb_spin.Text = tbar_spin.Value.ToString();
            wl.SetSpin(tbar_spin.Value);
            ChangeInterval();
        }

        private void ChangeInterval()
        {
            if (wl == null)
                return;

            tm_coating.Interval = 6000000 / (wl.Spin * wl.Drop);
        }

        private void tbar_drop_Scroll(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            lb_drop.Text = tbar_drop.Value.ToString();
            wl.SetDrop(tbar_drop.Value);
            ChangeInterval();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            if (tm_coating.Enabled)
            {
                tm_coating.Enabled = false; // 다시 시작하지 못하게 함.
                btn_start.Text = "시작";
            }

            else
            {
                tm_coating.Enabled = true;
                btn_start.Text = "멈춤";
            }
        }

        private void cb_awafer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            pn_awafer.Wafer = wl.LastWafer;
            pn_awafer.Invalidate();
        }

        private void tm_coating_Tick(object sender, EventArgs e)
        {
            if (wl == null)
                return;

            if (wl.Coating() == false)
            {
                tm_coating.Enabled = false;
                btn_start.Text = "시작";
            }

            Wafer wafer = wl.Now; // 현재 코팅하는 wafer개체를 얻어옴
            pn_nwafer.Wafer = wafer;
            if (wafer != null)
            {
                int ccount = wafer.Now;
                if (ccount == 1)
                {
                    Wafer lwafer = wl.LastWafer;
                    if (lwafer != null)
                    {
                        cb_awafer.Items.Add(lwafer);
                        lb_awcnt.Text = wl.AWCnt.ToString();
                        ts_lb.Text = string.Format($"코팅완료{lwafer}");
                    }
                    lb_wcnt.Text = wl.BWCnt.ToString();
                }
            }

            if (wl.NPcnt == 999)
            {
                lb_pcnt.Text = wl.PCnt.ToString();
                ts_lb.Text = string.Format($"코팅액 교체: 남은 코팅액 {wl.PCnt}병");
            }
            Invalidate(true);
        }

        private void pn_wafer_Paint(object sender, PaintEventArgs e)
        {
            if (wl == null)
                return;

            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.DarkGray, 1);
            pen.DashStyle = DashStyle.Dot; // 점선
            int xu = pn_wafer.Width / 10;
            int yu = pn_wafer.Height / 20;
            int wcnt = wl.BWCnt;
            for (int x = 1; x < 10; x++) // 수직선
            {
                graphics.DrawLine(pen, new Point(x * xu, 0), new Point(x * xu, pn_wafer.Height));
            }
            for (int y = 1; y < 20; y++) // 수평선
            {
                graphics.DrawLine(pen, new Point(0, y * yu), new Point(pn_wafer.Width, y * yu));
            }
            for (int i = 0, ri = 200; i < 200; i++, ri--)
            {
                Brush brush;
                if (ri <= wcnt)
                {
                    brush = new HatchBrush(HatchStyle.DiagonalCross, Color.Goldenrod);
                }
                else
                {
                    brush = new SolidBrush(pn_wafer.BackColor);
                }
                int x = i % 10; //0 ~ 9
                int y = i / 10;
                graphics.FillRectangle(brush, new RectangleF(x * xu + 1, y * yu + 1, xu - 1, yu - 1));
            }
        }

        private void pn_pr_Paint(object sender, PaintEventArgs e)
        {
            if (wl == null)
                return;

            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.DarkGray, 1);
            pen.DashStyle = DashStyle.Dot; // 점선
            int yu = pn_pr.Height / 20;
            for (int y = 1; y < 20; y++)
            {
                graphics.DrawLine(pen, new Point(0, y * yu), new Point(pn_pr.Width, y * yu));
            }
            int pcnt = wl.PCnt;
            for (int i = 0, ri = 20; i < 20; i++, ri--)
            {
                Color color = pn_pr.BackColor;
                if (ri <= pcnt)
                    color = Color.DarkCyan;
                Brush brush = new SolidBrush(color);
                graphics.FillRectangle(brush, new Rectangle(0, i * yu + 1, pn_pr.Width, yu - 1));
            }
        }

        private void pn_npr_Paint(object sender, PaintEventArgs e)
        {
            if (wl == null)
                return;
            Graphics graphics = e.Graphics;
            int npcnt = wl.NPcnt;
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (npcnt < (1000 - y * 50 + x))
                        graphics.DrawLine(Pens.White, new Point(x, y), new Point(x + 1, y));
                    else
                        graphics.DrawLine(Pens.DarkCyan, new Point(x, y), new Point(x + 1, y));
                }
            }
        }
    }
}