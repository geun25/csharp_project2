using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class MStudent : Student
    {
        internal MStudent(int num, string name) : base(num, name)
        {

        }

        internal override void WatchingTV()
        {
            base.WatchingTV();
            Cp -= 1;
            Console.WriteLine($"보수적인 학생, 추가로 대화능력에 변화:{Cp}");
        }
    }
}
