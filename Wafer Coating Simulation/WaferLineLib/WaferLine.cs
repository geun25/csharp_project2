﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace WaferLineLib
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
        List<Wafer> awafers = new List<Wafer>(); // 코팅 완료

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
                bwafers.RemoveAt(0); // 코팅전 컬렉션에서 해당 wafer 제거
            }
            while (awafers.Count < awcnt)
            {
                awafers.Add(null); // 코팅 완료 컬렉션에 wafer 추가
            }
        }

        Wafer nwafer;
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
            {
                wcnt = avail;
            }
            for (int i = 0; i < wcnt; i++)
            {
                bwafers.Add(new Wafer());
            }
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
        /// 코팅 가능한 cell 개수
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
            if (nowp == 0) // 현재 사용할 코팅액이 있는지 확인
            {
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
