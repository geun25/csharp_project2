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
            throw new NotImplementedException();
        }

        internal override void DoIt(int cmd, int snum)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "기숙사";
        }
    }
}
