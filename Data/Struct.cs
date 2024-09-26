using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using HermleCS.Comm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace HermleCS.Data
{
    public struct Locations
    {
        public string name;
        public double x, y, z, rx, ry, rz, dist, alfa;
    }

    public enum PocketStatus
    {
        empty = 1,
        unmachined = 2,
        machined = 3,
        reserved = 4,
        Mask = 5,
        occupied = 6,
        Broken = 7,
        Disable = 8
    }

    public enum ToolType
    {
        other = 0,
        HSK = 1,
        Drill = 2,
        Round = 3
    }

    public struct PocketProperties
    {
        public string name;
        public int shelf, column, pocket, diameter;
        public ToolType currenttool;
        public PocketStatus status;
        public int workpiece;
        public double programnumber;
    }

    public struct WorkPiece
    {
        public int wpnumber;
        public double ncprogram;
        public int tooldiameter, toolamount, toolamountleft, linenumber;
        public string wptooltype;
        public PocketStatus wpstatus;
    }

/*

    public class WorkPieceData
    {
        public int SaveAllWP()
        {
            int writeline = 0;
            string CsvPath;
            int wp;
            string filePath;

            try
            {
                CsvPath = C.ApplicationPath + "\\WorkDirectory\\Data\\";
                filePath = Path.Combine(CsvPath, "ALLWorkPiece.csv");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Line Number, WorkPieceNumber, NCProgram, Tool Amount, ToolAmountLeft, ToolDiameter, WP ToolType");

                    for (wp = 0; wp <= C.WORKPIECE_COUNT; wp++)
                    {
                        var workpiece = D.allwp[wp];
                        writer.WriteLine($"{workpiece.linenumber},{workpiece.ncprogram},{workpiece.toolamount},{workpiece.toolamountleft},{workpiece.tooldiameter},{workpiece.wptooltype}");
                        writeline++;
                    }
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                C.log("SaveAllWP FileWrite Exception - " + ex.Message);
                return C.ERRNO_FAILED;
            }

            return writeline;
        }
    }
*/
}
