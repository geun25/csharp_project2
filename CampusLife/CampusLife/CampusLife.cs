using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLife
{
    class CampusLife
    {
        static CampusLife singleton = null;

        static CampusLife()
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
