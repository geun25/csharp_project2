using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class Student
    {
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
        }


        public override string ToString()
        {
            return string.Format($"번호:{Num} 이름:{Name}");
        }

        internal void ListenLecture()
        {

        }

        internal void Announce()
        {

        }

        internal void Discuss()
        {

        }

        internal void ListenSeminar()
        {

        }

        internal void Reading()
        {

        }

        internal void Sleep()
        {

        }

        internal void WatchingTV()
        {

        }
    }
}
