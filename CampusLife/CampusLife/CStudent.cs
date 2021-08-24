using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class CStudent : Student
    {
        internal CStudent(int num, string name):base(num, name)
        {

        }

        internal void Question()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("질문을 하다.");
            Iq += 1;
            Cp += 1;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }

        internal override void Reading()
        {
            base.Reading();
            Cp += 1;
            Console.WriteLine($"도전적인 학생은 추가로 대화 능력이 변함:{Cp}");
        }
    }
}
