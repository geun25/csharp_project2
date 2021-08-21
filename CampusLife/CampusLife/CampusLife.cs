using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class CampusLife
    {
        static CampusLife singleton = null; // 유일한 개체 생성

        static CampusLife() // 유일한 개체에 접근하기 위한 속성
        {
            singleton = new CampusLife();
        }

        internal static CampusLife Singleton
        {
            get;
        }

        private CampusLife() // 개체 생성을 다른 형식에서 접근할 수 없게 private 접근 지정
        {

        }
    }
}
