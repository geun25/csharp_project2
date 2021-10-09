using System;
using System.Collections;
using System.Collections.Generic;

namespace WaferLineLib
{
    public class WaferLine : IEnumerable<Wafer>
    {
        #region 이벤트 정의
        public event AddWaferEventHandler AddedWafer;
        public event AddPrEventHandler AddedPr;
        public event SetSpinEventHandler SettedSpin;
        public event SetDropEventHandler SettedDrop;
        public event EndPrEventHandler EndedPr;
        public event EndCoatingEventHandler EndedCoating;
        #endregion

        /// <summary>
        /// 생산라인번호
        /// </summary>
        public int No
        {
            get;
        }

        public int Spin
        {
            get;
            set;
        }

        public int Drop
        {
            get;
            set;
        }

        public WaferLine(int no)
        {
            No = no;
            Spin = 1000;
            Drop = 20;
        }

        List<Wafer> bwafers = new List<Wafer>(); // 코팅전 wafers
        List<Wafer> awafers = new List<Wafer>(); // 코팅 완료 wafers

        public Wafer LastWafer
        {
            get
            {
                if (awafers.Count == 0)
                    return null;
                return awafers[awafers.Count - 1];  // 가장 최근에 코팅을 완료한 Wafer 반환
            }
        }

        public void EndCoating(int bwcnt, int awcnt) // 갯수 매핑 작업
        {
            while (bwafers.Count > bwcnt)
            {
                bwafers.RemoveAt(0); // 코팅전 컬렉션에서 해당 wafer 제거
            }
            while (awafers.Count < awcnt)
            {
                awafers.Add(null); // 코팅 완료 컬렉션에 wafer 추가
            }
        }

        Wafer nwafer; //현재 코팅하고 있는 Wafer
        int nowp; // 1병은 1000cell 코팅가능

        /// <summary>
        /// 현재 코팅하고 있는 wafer
        /// </summary>
        public Wafer Now
        {
            get
            {
                return nwafer;
            }
        }

        /// <summary>
        /// 코팅하지 않은 Wafer 개수
        /// </summary>
        public int BWCnt
        {
            get
            {
                return bwafers.Count;
            }
        }

        /// <summary>
        /// 원하는 만큼 wafer 투입
        /// </summary>
        /// <param name="wcnt"></param>
        /// <returns></returns>
        public int InWafer(int wcnt)
        {
            int avail = 200 - BWCnt; // 추가 가능한 wafer 개수
            if (wcnt > avail)
                wcnt = avail;
            for (int i = 0; i < wcnt; i++)
            {
                bwafers.Add(new Wafer());
            }
            if(AddedWafer != null)
                AddedWafer(this, new AddWaferEventArgs(No, BWCnt));
            return bwafers.Count; // 추가한 후 wafer 개수
        }

        public int AWCnt
        {
            get
            {
                return awafers.Count;
            }
        }

        /// <summary>
        /// 현재 코딩액의 개수
        /// </summary>
        public int PCnt
        {
            get;
            set;
        }

        /// <summary>
        /// 현재 코팅에 사용하고 있는 코팅액의 남은 양
        /// </summary>
        public int NPcnt
        {
            get
            {
                return nowp;
            }
        }

        public int InPr(int pcnt)
        {
            int avail = 20 - PCnt;// 추가 가능한 코팅액 개수
            if (pcnt > avail)
                pcnt = avail;
            PCnt += pcnt;
            if(AddedPr != null)
                AddedPr(this, new AddPrEventArgs(No, PCnt));
            return PCnt;
        }

        public void SetSpin(int spin)
        {
            Spin = spin;
            if(SettedSpin != null)
                SettedSpin(this, new SetSpinEventArgs(No, spin));
        }

        public void SetDrop(int drop)
        {
            Drop = drop;
            if(SettedDrop != null)
                SettedDrop(this, new SetDropEventArgs(No, drop));
        }

        Random rand = new Random();
        public bool Coating()
        {
            if (nowp == 0) // 현재 사용할 코팅액이 있는지 확인
            {
                if (EndedPr != null)
                    EndedPr(this, new EndPrEventArgs(No));
                if (PCnt == 0) // 남은 코팅액이 있는지 확인
                    return false;
                nowp = 1000;
                PCnt--;
            }
            if (nwafer == null)
            {
                if (bwafers.Count == 0)
                    return false;
                nwafer = bwafers[0];
                bwafers.RemoveAt(0);
            }
            nwafer.Coating(rand.Next(70, 100)); // 70~100%사이 랜덤 코팅
            nowp--;
            if (nwafer.Increment() == false) // 코팅완료
            {
                awafers.Add(nwafer);
                nwafer = null;
                if (EndedCoating != null)
                    EndedCoating(this, new EndCoatingEventArgs(No, BWCnt, AWCnt));
            }
            return true;
        }

        public override string ToString()
        {
            return string.Format($"WaferLine No:{No}");
        }

        public IEnumerator<Wafer> GetEnumerator()
        {
            return awafers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return awafers.GetEnumerator();
        }
    }
}
