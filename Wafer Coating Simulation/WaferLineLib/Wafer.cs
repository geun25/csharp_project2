namespace WaferLineLib
{
    /// <summary>
    /// Wafer 클래스
    /// </summary>
    public class Wafer
    {
        static int last_wn; // 가장 최근에 부여한 wafer number
        readonly int wn;
        int[] cells = new int[100];
        int now; // 현재 코팅하고 있는 부분

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Wafer()
        {
            last_wn++;
            wn = last_wn; // wafer number 자동증분
        }

        /// <summary>
        /// 현재 코팅할 cell 번호 - 가져오기
        /// </summary>
        public int Now
        {
            get
            {
                return now;
            }
        }

        /// <summary>
        /// 코팅할 cell 번호 증가
        /// </summary>
        /// <returns>증가 성공 여부</returns>
        public bool Increment()
        {
            if (now < 100)
            {
                now++;
                if (now == 100)
                    return false;
                return true;
            }
            return false;
        }

        /// <summary>
        ///  코팅 메서드
        /// </summary>
        /// <param name="quality">품질 수준</param>
        public void Coating(int quality)
        {
            if (Now < 100)
            {
                cells[Now] = quality;
            }
        }

        /// <summary>
        /// 특정 cell의 품질 수준 인덱서 - 가져오기
        /// </summary>
        /// <param name="index">cell의 인덱스</param>
        /// <returns>특정 cell의 품질</returns>
        public int this[int index]
        {
            get
            {
                if ((index < 0) || (index >= 100))
                    return 0;
                return cells[index];
            }
        }

        /// <summary>
        /// 평균 품질 - 가져오기
        /// </summary>
        public double Quality
        {
            get
            {
                int sum = 0;
                foreach (int elem in cells)
                {
                    sum += elem;
                }
                return sum / 100.0;
            }
        }

        /// <summary>
        /// ToString 메서드 재정의
        /// </summary>
        /// <returns>Wafer 번호와 평균 품질</returns>
        public override string ToString()
        {
            return string.Format($"NO-{wn} Quality-{Quality}");
        }
    }
}
