using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class LectureRoom : Place
    {
        internal LectureRoom()
        {
            Console.WriteLine("강의실 생성");
        }

        internal override void DoIt(int cmd)
        {
            switch(cmd)
            {
                case GameRule.CMD_LR_Forwarding: StartForwarding(); break;
                default: return;
            }
        }

        private void StartForwarding()
        {
            int cnt = GetStuCount();
            Student student = null;
            CStudent cstudent = null;

            for (int i = 0; i < cnt; i++)
            {
                student = GetStudent(i);
                student.ListenLecture();
                cstudent = student as CStudent;
                if (cstudent != null)
                    cstudent.Question();
            }
        }

        internal override void DoIt(int cmd, int snum)
        {
            Student student = this[snum];
            if(student == null)
            {
                Console.WriteLine($"{snum}번 학생은 없습니다.");
                return;
            }
            switch(cmd)
            {
                case GameRule.CMD_LR_Announce: StartAnnounce(student); break;
                default: return;
            }
        }

        private void StartAnnounce(Student student)
        {
            student.Announce();
            int cnt = GetStuCount();
            Student stu = null;

            for(int i=0; i<cnt; i++)
            {
                stu = GetStudent(i);
                if (stu != student) // 나머지 학생은 자유토론
                    stu.Discuss();
            }
        }

        public override string ToString()
        {
            return "강의실";
        }
    }
}
