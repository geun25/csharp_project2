using System;
using System.Collections;
using System.Collections.Generic;
using WaferLineLib;

namespace WaferLine_예광탄
{
    public class WaferLine : IEnumerable<Wafer>
    {
        /// <summary>
        /// Wafer 구분자
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

        List<Wafer> bwafers = new List<Wafer>(); // 코팅전
        List<Wafer> awafers = new List<Wafer>(); // 코팅후

        public Wafer LastWafer
        {
            get
            {
                if (awafers.Count == 0)
                    return null;
                return awafers[awafers.Count - 1];  // 가장 최근에 코팅을 완료한 Wafer 반환
            }
        }

        public void EndCoating(int bwcnt, int awcnt)
        {
            while (bwafers.Count > bwcnt)
            {
                bwafers.RemoveAt(0);
            }
            while (awafers.Count < awcnt)
            {
                awafers.Add(null);
            }
        }

        Wafer nwafer;
        int nowp; // 1병은 1000cell 코팅가능
        public Wafer Now
        {
            get
            {
                return nwafer;
            }
        }

        public int BWCnt
        {
            get
            {
                return bwafers.Count;
            }
        }

        public int InWafer(int wcnt)
        {
            int avail = 200 - BWCnt;
            if (wcnt > avail)
            {
                wcnt = avail;
            }
            for (int i = 0; i < wcnt; i++)
            {
                bwafers.Add(new Wafer());
            }
            return bwafers.Count;
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
        /// 코팅할 수 있는 cell 개수
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
            int avail = 20 - PCnt;
            if (avail > avail)
                pcnt = avail;
            PCnt += pcnt;
            return PCnt;
        }

        public void SetSpin(int spin)
        {
            Spin = spin;
        }

        public void SetDrop(int drop)
        {
            Drop = drop;
        }

        Random rand = new Random();
        public bool Coating()
        {
            if(nowp == 0) // 현재 코팅액이 있는지 확인
            {
                if (PCnt == 0)
                    return false;
                nowp = 1000;
                PCnt--;
            }
            if(nwafer == null)
            {
                if(bwafers.Count == 0)
                    return false;
                nwafer = bwafers[0];
                bwafers.RemoveAt(0);
            }
            nwafer.Coating(rand.Next(70, 100));
            nowp--;
            if(nwafer.Increment() == false) // 코팅완료
            {
                awafers.Add(nwafer);
                nwafer = null;
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
