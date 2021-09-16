using System;
using System.Windows.Forms;
using WaferLineLib;

namespace WaferLine_Factory_Simulation
{
    public partial class WaferLineForm : Form
    {
        public event AddWaferEventHandler AddedWafer;
        public event AddPrEventHandler AddedPr;
        public event SetSpinEventHandler SettedSpin;
        public event SetDropEventHandler SettedDrop;
        public event EndPrEventHandler EndedPr;
        public event EndCoatingEventHandler EndedCoating;

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
            WLine.AddedWafer += WLine_AddedWafer;
            WLine.AddedPr += WLine_AddedPr;
            WLine.EndedCoating += WLine_EndedCoating;
            WLine.EndedPr += WLine_EndedPr;
            WLine.SettedSpin += WLine_SettedSpin;
            WLine.SettedDrop += WLine_SettedDrop;
        }

        private void WLine_SettedDrop(object sender, SetDropEventArgs e)
        {
            if (SettedDrop != null)
                SettedDrop(this, e);
        }

        private void WLine_SettedSpin(object sender, SetSpinEventArgs e)
        {
            if (SettedSpin != null)
                SettedSpin(this, e);
        }

        private void WLine_EndedPr(object sender, EndPrEventArgs e)
        {
            if (EndedPr != null)
                EndedPr(this, e);
        }

        private void WLine_EndedCoating(object sender, EndCoatingEventArgs e)
        {
            if (EndedCoating != null)
                EndedCoating(this, e);
        }

        private void WLine_AddedPr(object sender, AddPrEventArgs e)
        {
            if (AddedPr != null)
                AddedPr(this, e);
        }

        private void WLine_AddedWafer(object sender, AddWaferEventArgs e)
        {
            if (AddedWafer != null)
                AddedWafer(this, e);
        }

        private void WaferLineForm_Load(object sender, EventArgs e)
        {
            lb_no.Text = No.ToString();
            wlc.Line = WLine;
        }

        private void WaferLineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
