using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class Campus
    {
        Student[] students = null;
        internal Campus()
        {
            Console.WriteLine("캠퍼스 생성");
            students = new Student[GameRule.MaxStudents];
        }

        internal void InStudent(Student student)
        {
            int empty_index = FindEmptyIndex();
            students[empty_index] = student;
        }

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
            for(int i=0; i<students.Length; i++)
            {
                if (students[i] == student)
                    return i;               
            }
            return -1;
        }

        private int FindEmptyIndex()
        {
            int i = 0;
            for(i=0; i<students.Length; i++)
            {
                if (students[i] == null)
                    break;
            }
            return i;
        }

        internal int StuCount
        {
            get
            {
                return FindEmptyIndex();
            }
        }

        internal Student this[int num]
        {
            get
            {
                int max = FindEmptyIndex();
                for(int i=0; i<max; i++)
                {
                    if (students[i].Num == num)
                        return students[i];
                }
                return null;
            }
        }

        internal string GetStuInfo(int nth)
        {
            if ((nth >= 0) && (nth < FindEmptyIndex()))
            {
                return students[nth].ToString();
            }
            return "해당 학생 정보 없음.";
        }
    }
}
