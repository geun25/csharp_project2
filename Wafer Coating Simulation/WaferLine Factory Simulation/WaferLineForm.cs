using System;
using System.Windows.Forms;
using WaferLineLib;

namespace WaferLine_Factory_Simulation
{
    public partial class WaferLineForm : Form
    {
        #region 이벤트 정의
        public event AddWaferEventHandler AddedWafer;
        public event AddPrEventHandler AddedPr;
        public event SetSpinEventHandler SettedSpin;
        public event SetDropEventHandler SettedDrop;
        public event EndPrEventHandler EndedPr;
        public event EndCoatingEventHandler EndedCoating;
        #endregion

        public WaferLine WLine
        {
            get;
        }

        public int No
        {
            get
            {
                return WLine.No;
            }
        }
        public WaferLineForm(WaferLine wl)
        {
            InitializeComponent();
            WLine = wl;

            #region 이벤트 핸들러 추가
            WLine.AddedWafer += WLine_AddedWafer;
            WLine.AddedPr += WLine_AddedPr;
            WLine.EndedCoating += WLine_EndedCoating;
            WLine.EndedPr += WLine_EndedPr;
            WLine.SettedSpin += WLine_SettedSpin;
            WLine.SettedDrop += WLine_SettedDrop;
            #endregion
        }

        private void WLine_SettedDrop(object sender, SetDropEventArgs e)
        {
            Manager manager = Manager.Singleton;
            manager.SetDrop(e.No, e.Drop);
            if (SettedDrop != null)
                SettedDrop(this, e);
        }

        private void WLine_SettedSpin(object sender, SetSpinEventArgs e)
        {
            Manager manager = Manager.Singleton;
            manager.SetSpeed(e.No, e.Spin);
            if (SettedSpin != null)
                SettedSpin(this, e);
        }

        private void WLine_EndedPr(object sender, EndPrEventArgs e)
        {
            Manager manager = Manager.Singleton;
            manager.EndedPr(e.No);
            if (EndedPr != null)
                EndedPr(this, e);
        }

        private void WLine_EndedCoating(object sender, EndCoatingEventArgs e)
        {
            Manager manager = Manager.Singleton;
            manager.EndedCoating(e.No, e.BWCnt, e.AWCnt);
            if (EndedCoating != null)
                EndedCoating(this, e);
        }

        private void WLine_AddedPr(object sender, AddPrEventArgs e)
        {
            Manager manager = Manager.Singleton;
            manager.AddPr(e.No, e.PCnt);
            if (AddedPr != null)
                AddedPr(this, e);
        }

        private void WLine_AddedWafer(object sender, AddWaferEventArgs e)
        {
            Manager manager = Manager.Singleton;
            manager.AddWafer(e.No, e.BWCnt);
            if (AddedWafer != null)
                AddedWafer(this, e);
        }

        private void WaferLineForm_Load(object sender, EventArgs e)
        {
            lb_no.Text = No.ToString();
            wlc.Line = WLine; // 어느 WaferLine과 관련있는지 설정
        }

        private void WaferLineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide(); // 창을 숨기는 역할   
            e.Cancel = true; // 프로그램이 완전히 끝나지 않고 백그라운드에서 실행되게 함.
        }

        internal void SetStatus()
        {
            wlc.SetStatus();
        }
    }
}
