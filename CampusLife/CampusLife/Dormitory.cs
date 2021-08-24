using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class Dormitory : Place
    {
        internal Dormitory()
        {
            Console.WriteLine("기숙사 생성");
        }

        internal override void DoIt(int cmd)
        {
           switch(cmd)
            {
                case GameRule.CMD_DO_Sleep: TurnOff(); break;
                case GameRule.CMD_DO_TV: StartTV(); break;
            }
        }

        private void StartTV()
        {
            int cnt = GetStuCount();
            Student student = null;            
            for (int i = 0; i < cnt; i++)
            {
                student = GetStudent(i);
                student.WatchingTV();               
            }
        }

        private void TurnOff()
        {
            int cnt = GetStuCount();
            Student student = null;
            PStudent pstu = null;
            for(int i=0; i<cnt; i++)
            {
                student = GetStudent(i);
                student.Sleep();
                pstu = student as PStudent;
                if(pstu != null)
                {
                    pstu.TalkingInSleep();
                }
            }
        }

        internal override void DoIt(int cmd, int snum)
        {           
        }

        public override string ToString()
        {
            return "기숙사";
        }
    }
}
