using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class Library : Place
    {
        internal Library()
        {
            Console.WriteLine("도서관 생성");
        }

        internal override void DoIt(int cmd)
        {
            switch(cmd)
            {
                case GameRule.CMD_LI_Seminar: StartSeminar(); break;
            }
        }

        private void StartSeminar()
        {
            int cnt = GetStuCount();
            Student student;
            for(int i=0; i<cnt; i++)
            {
                student = GetStudent(i);
                student.ListenSeminar();
            }
        }

        internal override void DoIt(int cmd, int snum)
        {
            Student student = this[snum];
            if(student == null)
            {
                Console.WriteLine("${snum}번 학생은 없습니다.");
                return;
            }

            switch(cmd)
            {
                case GameRule.CMD_LI_Reading: StartReading(student); break;
                default: return;
            }
        }

        private void StartReading(Student student)
        {
            student.Reading();
        }

        public override string ToString()
        {
            return "도서관";
        }

    }
}
