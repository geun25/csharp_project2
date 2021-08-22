using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for(i=0; i<students.Length; i++)
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
                return null;
            }
        }

        internal int GetStuCount()
        {
            return 0;
        }

        internal string GetStuInfo(int nth)
        {
            return string.Empty;
        }

        internal abstract void DoIt(int cmd); 

        internal abstract void DoIt(int cmd, int snum); 
    }
}
