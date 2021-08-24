using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class PStudent : Student
    {
        internal PStudent(int num, string name) : base(num, name)
        {

        }

        internal void TalkingInSleep()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("잠꼬대를 한다.");
            Hp -= 1;
            Iq += 1;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }
    }
}
