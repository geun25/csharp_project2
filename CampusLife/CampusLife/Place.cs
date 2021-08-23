namespace CampusLife
{
    abstract class Place
    {
        Student[] students = null;
        internal Place()
        {
            students = new Student[GameRule.MaxStudents];
        }

        internal void InStudent(Student student)
        {
            int ei = FindEmptyIndex();
            students[ei] = student;
        }

        private int FindEmptyIndex()
        {
            int i = 0;
            for (i = 0; i < students.Length; i++)
            {
                if (students[i] == null)
                    break;
            }
            return i;
        }

        public override string ToString()
        {
            return string.Empty;
        }

        internal Student this[int num]
        {
            get
            {
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i] == null)
                        return null;
                    if (students[i].Num == num)
                        return students[i];
                }
                return null;
            }
        }

        internal int GetStuCount()
        {
            int cnt = 0;
            while (students[cnt] != null)
            {
                cnt++;
            }
            return cnt;
        }

        internal string GetStuInfo(int nth)
        {
            int cnt = GetStuCount();
            if ((nth >= 0) && (nth < cnt))
                return students[nth].ToString();
            return "해당 학생 정보 없음";
        }

        internal abstract void DoIt(int cmd);

        internal abstract void DoIt(int cmd, int snum);

        internal void OutStudent(Student student)
        {
            int index = FindStudent(student);
            if (index == -1)
                return;
            int ei = FindEmptyIndex();
            if (ei == 0)
                return;
            students[index] = students[ei - 1];
            students[ei - 1] = null;
        }

        private int FindStudent(Student student)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] == student)
                    return i;
            }
            return -1;
        }
    }
}
