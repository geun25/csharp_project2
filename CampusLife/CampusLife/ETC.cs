using System;

namespace CampusLife
{
    enum PlaceType
    {
        PT_LECTUREROOM, PT_DORMITORY, PT_LIBRARY, MAX_PLACES
    }

    enum StuType
    {
        ST_CSTUDENT, ST_MSTUDENT, ST_PSTUDENT, MAX_STUTYPE
    }

    static class GameRule
    {
        internal const int min_students = 5;
        internal const int max_students = 100;
        static int user_max_students;
        internal static int MaxStudents
        {
            get
            {
                return user_max_students;
            }
            private set
            {
                if(value < min_students)
                {
                    value = min_students;
                }
                if(value > max_students)
                {
                    value = max_students;
                }
                user_max_students = value;
            }
        }

        static GameRule()
        {
            System.Console.WriteLine("최대 학생 수를 입력하세요.");
            System.Console.WriteLine($"{min_students}~{max_students}");
            MaxStudents = EHLib.GetNum();
            Console.WriteLine($"최대 학생 수는 {MaxStudents}로 결정");
        }

        internal const ConsoleKey ExitKey = ConsoleKey.Escape;
        internal const ConsoleKey MoveStuKey = ConsoleKey.F1;
        internal const ConsoleKey MoveFocusKey = ConsoleKey.F2;
        internal const ConsoleKey ViewKey = ConsoleKey.F3;

        internal const ConsoleKey LR_Forwarding = ConsoleKey.F1;
        internal const ConsoleKey LR_Announce = ConsoleKey.F2;

        internal const ConsoleKey LI_Seminar = ConsoleKey.F1;
        internal const ConsoleKey LI_Reading = ConsoleKey.F2;

        internal const ConsoleKey DO_Sleep = ConsoleKey.F1;
        internal const ConsoleKey DO_TV = ConsoleKey.F2;

        internal const int CMD_LR_Forwarding = (int)LR_Forwarding;
        internal const int CMD_LR_Announce = (int)LR_Announce;
        internal const int CMD_LI_Seminar = (int)LI_Seminar;
        internal const int CMD_LI_Reading = (int)LI_Reading;
        internal const int CMD_DO_Sleep = (int)DO_Sleep;
        internal const int CMD_DO_TV = (int)DO_TV;
    }

    static class EHLib
    {
        internal static int GetNum()
        {
            int num = 0;
            string str = Console.ReadLine();
            if(int.TryParse(str, out num))
            {
                return num;
            }
            return 0;
        }
    }

    static class StudentValueDefine
    {
        internal const int MIN_IQ = 60;
        internal const int MAX_IQ = 200;
        internal const int DEF_IQ = 80;

        internal const int MIN_HP = 0;
        internal const int MAX_HP = 100;
        internal const int DEF_HP = 50;

        internal const int MIN_CP = 0;
        internal const int MAX_CP = 100;
        internal const int DEF_CP = 0;
    }
}