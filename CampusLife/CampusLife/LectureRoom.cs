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
            throw new NotImplementedException();
        }

        internal override void DoIt(int cmd, int snum)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "강의실";
        }
    }
}
