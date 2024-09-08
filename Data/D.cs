using HermleCS.Comm;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HermleCS.Data
{
    public class D
    {
        public static RoundLocations[,] roundlocations = new RoundLocations[C.SHELF_COUNT, C.COLUMN_COUNT];
        public static PocketProperties[,] automationstatus = new PocketProperties[C.SHELF_COUNT, C.COLUMN_COUNT];
        public static WorkPiece[] allwp = new WorkPiece[C.WORKPIECE_COUNT];
        public static ToolType apptooltype;

        public static void init()
        {
            int shelf, column, pocket;

            for (shelf = 0; shelf <= C.SHELF_COUNT; shelf++)
            {
                for (column = 0; column <= C.COLUMN_COUNT; column++)
                {
                    for (pocket = 0; pocket <= C.POCKET_COUNT; pocket++)
                    {
                        D.roundlocations[shelf, column].diameter = new RobotPosition[C.POCKET_COUNT];
                    }
                }
            }
        }
    }
}
