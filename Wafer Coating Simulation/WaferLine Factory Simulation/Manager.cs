using System.Net;
using WaferLineCommLib;
using WaferLineLib;

namespace WaferLine_Factory_Simulation
{
    public class Manager
    {
        public event RecvStsEndPtEventHandler RecvStsEndPoint;
        public event AddWaferEventHandler AddedWafer;
        public event AddPrEventHandler AddedPr;
        public event SetSpinEventHandler SettedSpin;
        public event SetDropEventHandler SettedDrop;

        private Manager()
        {

        }

        static Manager manager = new Manager(); // 정적 멤버로 단일체 개체 생성

        static public Manager Singleton
        {
            get
            {
                return manager;
            }
        }

        public void StartServer(string ip, int port)
        {
            FactoryServer fs = new FactoryServer(ip, port);
            fs.RecvStsEndPoint += Fs_RecvStsEndPoint;
            fs.AddedWafer += Fs_AddedWafer;
            fs.AddedPr += Fs_AddedPr;
            fs.SettedSpin += Fs_SettedSpin;
            fs.SettedDrop += Fs_SettedDrop;
            fs.StartAsync(); // 비동기 실행 
        }

        private void Fs_SettedDrop(object sender, SetDropEventArgs e)
        {
            if (SettedDrop != null)
                SettedDrop(this, e);
        }

        private void Fs_SettedSpin(object sender, SetSpinEventArgs e)
        {
            if (SettedSpin != null)
                SettedSpin(this, e);
        }

        private void Fs_AddedPr(object sender, AddPrEventArgs e)
        {
            if (AddedPr != null)
                AddedPr(this, e);
        }

        private void Fs_AddedWafer(object sender, AddWaferEventArgs e)
        {
            if (AddedWafer != null)
                AddedWafer(this, e);
        }

        ControlClient cc;
        private void Fs_RecvStsEndPoint(object sender, RecvStsEndPtEventArgs e)
        {
            IPAddress cip = e.IPAddress;
            int cport = e.Port;
            cc = new ControlClient(cip, cport); // 중앙관제 정보 전달하기 위한 개체 생성
            if (RecvStsEndPoint != null)
                RecvStsEndPoint(this, e);
        }

        public void AddLine(int no)
        {
            if (cc == null)
                return;
            if (cc.SendAddLine(no) == false)
                cc = null;
        }

        public void AddWafer(int no, int bwcnt)
        {
            if (cc == null)
                return;
            if (cc.SendAddWafer(no, bwcnt) == false)
                cc = null;
        }

        public void AddPr(int no, int pcnt)
        {
            if (cc == null)
                return;
            if (cc.SendAddPr(no, pcnt) == false)
                cc = null;
        }

        public void SetSpeed(int no, int spin)
        {
            if (cc == null)
                return;
            if (cc.SendSetSpeed(no, spin) == false)
                cc = null;
        }

        public void SetDrop(int no, int drop)
        {
            if (cc == null)
                return;
            if (cc.SendSetDrop(no, drop) == false)
                cc = null;
        }

        public void EndedPr(int no)
        {
            if (cc == null)
                return;
            if (cc.SendEndPr(no) == false)
                cc = null;
        }

        public void EndedCoating(int no, int bwcnt, int awcnt)
        {
            if (cc == null)
                return;
            if (cc.SendEndedCoating(no, bwcnt, awcnt) == false)
                cc = null;
        }
    }
}
