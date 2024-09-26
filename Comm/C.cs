using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermleCS.Comm
{
    internal class C
    {
        public const int ERRNO_SUCCESS = 0;
        public const int ERRNO_FAILED = -1;

        public const int ERRNO_CONNECT = 200;

        public const int ERRNO_EXCEPTION = 500;

        public const int DRILL_SHELF_COUNT = 3;
        public const int DRILL_COLUMN_COUNT = 12;
        public const int DRILL_POCKET_COUNT = 8;

        public const int HSK_SHELF_COUNT = 3;
        public const int HSK_COLUMN_COUNT = 12;
        public const int HSK_POCKET_COUNT = 8;

        public const int ROUND_SHELF_COUNT = 3;
        public const int ROUND_COLUMN_COUNT = 12;
        public const int ROUND_POCKET_COUNT = 8;

        public const int WORKPIECE_COUNT = 50;

        public static string ApplicationPath;

        public static void log(string msg)
        {
            Console.WriteLine(DateTime.Now + " : {msg}");
        }
    }
}
