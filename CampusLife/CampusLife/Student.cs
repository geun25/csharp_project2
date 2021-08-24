using System;

namespace CampusLife
{
    class Student
    {
        int iq, hp, cp;

        public int Iq
        {
            get
            {
                return iq;
            }
            protected set
            {
                if (value < StudentValueDefine.MIN_IQ)
                    value = StudentValueDefine.MIN_IQ;
                if (value > StudentValueDefine.MAX_IQ)
                    value = StudentValueDefine.MAX_IQ;
                iq = value;
            }
        }

        public int Hp
        {
            get
            {
                return hp;
            }
            protected set
            {
                if (value < StudentValueDefine.MIN_HP)
                    value = StudentValueDefine.MIN_HP;
                if (value > StudentValueDefine.MAX_HP)
                    value = StudentValueDefine.MAX_HP;
                hp = value;
            }
        }

        public int Cp
        {
            get
            {
                return cp;
            }
            protected set
            {
                if (value < StudentValueDefine.MIN_CP)
                    value = StudentValueDefine.MIN_CP;
                if (value > StudentValueDefine.MAX_CP)
                    value = StudentValueDefine.MAX_CP;
                cp = value;
            }
        }

        internal string Name
        {
            get;
            private set;
        }

        internal int Num
        {
            get;
            private set;
        }

        internal Student(int num, string name)
        {
            Num = num;
            Name = name;
            Hp = StudentValueDefine.DEF_HP;
            Iq = StudentValueDefine.DEF_IQ;
            Cp = StudentValueDefine.DEF_CP;
        }


        public override string ToString()
        {
            return string.Format($"번호:{Num} 이름:{Name}");
        }

        internal void ListenLecture()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("강의를 듣다.");
            Iq += 5;
            Hp -= 4;
            Cp -= 1;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }

        internal void Announce()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("발표를 하다.");
            Hp -= 2;
            Cp += 3;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }

        internal void Discuss()
        {
            Console.WriteLine($"{this} 자유 토론을 하다.");
        }

        internal void ListenSeminar()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("세미나를 듣다.");
            Iq += 5;
            Hp -= 4;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }

        internal virtual void Reading()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("책을 읽다.");
            Iq += 2;
            Cp += 2;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }

        internal void Sleep()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("잠을 자다.");
            Hp += 2;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }

        internal virtual void WatchingTV()
        {
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
            Console.WriteLine("TV를 시청하다.");
            Hp -= 2;
            Console.WriteLine($"{this} 아이큐:{Iq}, 체력:{Hp}, 대화능력:{Cp}");
        }
    }
}
