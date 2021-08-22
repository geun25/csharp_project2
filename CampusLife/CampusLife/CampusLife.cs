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

        internal void Run()
        {
            ConsoleKey key;
            while((key = SelectMenu()) != GameRule.ExitKey)
            {
                switch(key)
                {
                    case GameRule.MoveStuKey: MoveStudent(); break;
                    case GameRule.MoveFocusKey: MoveFocus(); break;
                    case GameRule.ViewKey: View(); break;
                    default: Console.WriteLine("잘못 선택하였습니다."); break;
                }
                Console.WriteLine("아무키나 누르세요.");
                Console.ReadKey(true); // 아무키나 누르기 전까지는 화면이 멈춤.
            }
        }

        private void View()
        {
            throw new NotImplementedException();
        }

        private void MoveFocus()
        {
            throw new NotImplementedException();
        }

        private void MoveStudent()
        {
            ViewStuInfoInCampus();
            Console.WriteLine("이동할 학생 번호를 입력하세요.");
            int num = EHLib.GetNum();

            Student student = campus[num];
            if(student == null)
            {
                Console.WriteLine("잘못 선택하였습니다.");
                return;
            }

            Place place = SelectPlace();
            if(place == null)
            {
                Console.WriteLine("잘못 선택하였습니다.");
                return;
            }

            campus.OutStudent(student); // 캠퍼스에서 학생이 나옴.
            place.InStudent(student); // 해당 장소로 학생이 들어감.
        }

        private Place SelectPlace()
        {
            for(int i=0; i<places.Length; i++)
            {
                Console.WriteLine($"{i+1}:{places[i]}");
            }

            Console.WriteLine("장소를 선택하세요.");
            int num = EHLib.GetNum();

            if((num>0) && (num<=places.Length))
            {
                return places[num - 1];
            }
            return null;
        }

        private void ViewStuInfoInCampus()
        {
            int scnt = campus.StuCount;
            for(int i=0; i<scnt; i++)
            {
                Console.WriteLine(campus.GetStuInfo(i));
            }
        }

        private ConsoleKey SelectMenu()
        {

            Console.Clear();
            Console.WriteLine("캠퍼스 생활 메뉴");
            Console.WriteLine($"{GameRule.MoveStuKey} 학생 이동");
            Console.WriteLine($"{GameRule.MoveFocusKey} 포커스 이동");
            Console.WriteLine($"{GameRule.ViewKey} 전체 보기");
            Console.WriteLine($"{GameRule.ExitKey} 종료");
            return Console.ReadKey(true).Key;
        }

        internal void Init()
        {
            MakePlace();
            MakeStudents();
        }

        private void MakeStudents()
        {
            int max_students = GameRule.MaxStudents;
            Student student = null;
            for(int i=0; i<max_students; i++)
            {
                student = MakeStudent(i + 1);
                campus.InStudent(student);
            }
        }

        private Student MakeStudent(int nth)
        {
            Console.WriteLine($"{nth}번째 생성할 학생 정보 입력===");

            StuType stype = SelectStuType();
            Console.WriteLine("학생 이름을 입력하세요.");
            string name = Console.ReadLine();
            switch(stype)
            {
                case StuType.ST_CSTUDENT: return new CStudent(nth, name);
                case StuType.ST_MSTUDENT: return new MStudent(nth, name);
                case StuType.ST_PSTUDENT: return new PStudent(nth, name);
            }
            return null;
        }

        private StuType SelectStuType()
        {
            Console.WriteLine("생성할 학생 유형을 선택하세요.");
            Console.WriteLine("{0}도전적(디폴트) {1}보수적 {2}수동적",
                (int)StuType.ST_CSTUDENT, (int)StuType.ST_MSTUDENT, (int)StuType.ST_PSTUDENT);
            switch(EHLib.GetNum())
            {
                case (int)StuType.ST_CSTUDENT: return StuType.ST_CSTUDENT;
                case (int)StuType.ST_MSTUDENT: return StuType.ST_MSTUDENT;
                case (int)StuType.ST_PSTUDENT: return StuType.ST_PSTUDENT;
                default: return StuType.ST_CSTUDENT;
            }
        }

        Campus campus = null;
        Place[] places = new Place[(int)PlaceType.MAX_PLACES];

        private void MakePlace()
        {
            campus = new Campus();
            places[(int)PlaceType.PT_LECTUREROOM] = new LectureRoom();
            places[(int)PlaceType.PT_DORMITORY] = new Dormitory();
            places[(int)PlaceType.PT_LIBRARY] = new Library();
        }

        private CampusLife() // 개체 생성을 다른 형식에서 접근할 수 없게 private 접근 지정
        {

        }

        
    }
}
