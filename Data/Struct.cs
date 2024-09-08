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
    public struct RobotPosition
    {
        public string name;
        public double x, y, z, rx, ry, rz, dist, alfa;
    }

    public struct RoundLocations
    {
        public RobotPosition[] diameter;
    }

    public enum PocketStatus
    {
        empty_ = 1,
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

    public class RoundData
    {
        public int SaveArray(string arrayname)
        {
            if (arrayname != "RoundLocations")
            {
                return C.ERRNO_FAILED;
            }

            int writeline = 0;
            string CsvPath;
            int shelf, column, pocket;
            string filePath;

            try
            {
                CsvPath = C.ApplicationPath + "\\WorkDirectory\\Data\\";
                filePath = Path.Combine(CsvPath, arrayname + ".csv");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Pocket Name,x,y,z,rx,ry,rz,distance,alfa");

                    for (shelf = 0; shelf <= C.SHELF_COUNT; shelf++)
                    {
                        for (column = 0; column <= C.COLUMN_COUNT; column++)
                        {
                            for (pocket = 0; pocket <= C.POCKET_COUNT; pocket++)
                            {
                                // RoundLocations의 데이터가 필요
                                var location = D.roundlocations[shelf, column].diameter[pocket];
                                writer.WriteLine($"{location.name},{location.x},{location.y},{location.z},{location.rx},{location.ry},{location.rz},{location.dist},{location.alfa}");
                                writeline++;
                            }
                        }
                    }
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                C.log("SaveArray Fie Write Exception - " + ex.Message);
                return C.ERRNO_FAILED;
            }

            return writeline;
        }


        public int SaveAutomation()
        {
            int writeline = 0;
            string CsvPath;
            int shelf, column, pocket;
            string filePath;

            try
            {
                CsvPath = C.ApplicationPath + "\\WorkDirectory\\Data\\";
                filePath = Path.Combine(CsvPath, "RoundStatus.csv");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Pocket Name, shelf, column, pocket, diameter, CurrentTool, Status, WorkPiece, programNumber");

                    for (shelf = 0; shelf <= C.SHELF_COUNT; shelf++)
                    {
                        for (column = 0; column <= C.COLUMN_COUNT; column++)
                        {
                            for (pocket = 0; pocket <= C.POCKET_COUNT; pocket++)
                            {
                                // RoundLocations의 데이터가 필요
                                var property = D.automationstatus[shelf, column];
                                writer.WriteLine($"{property.name},{property.shelf},{property.column},{property.pocket},{property.diameter},{property.currenttool},{property.status},{property.workpiece},{property.programnumber}");
                                writeline++;
                            }
                        }
                    }
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                C.log("SaveAutomation FileWrite Exception - " + ex.Message);
                return C.ERRNO_FAILED;
            }

            return writeline;
        }

        public int ReadPocketsLocations(string arrayname)
        {
            if (arrayname != "RoundLocations")
            {
                return C.ERRNO_FAILED;
            }

            string dummy;
            int shelf, column, diameter;
            string filePath, CsvPath;
            int lines = 0;

            try
            {
                filePath = Path.Combine(C.ApplicationPath, "WorkDirectory", "Data", arrayname, ".csv");

                using (StreamReader reader = new StreamReader(filePath))
                {
                    // 헤더 읽기
                    dummy = reader.ReadLine();

                    for (shelf = 0; shelf <= C.SHELF_COUNT; shelf++)
                    {
                        for (column = 0; column <= C.COLUMN_COUNT; column++)
                        {
                            dummy = reader.ReadLine();
                            string[] values = dummy.Split(',');

                            for (diameter = 0; diameter <= C.POCKET_COUNT; diameter++)
                            {
                                D.roundlocations[shelf, column].diameter[diameter].name = values[0];
                                D.roundlocations[shelf, column].diameter[diameter].x = double.Parse(values[1]);
                                D.roundlocations[shelf, column].diameter[diameter].y = double.Parse(values[2]);
                                D.roundlocations[shelf, column].diameter[diameter].z = double.Parse(values[3]);
                                D.roundlocations[shelf, column].diameter[diameter].rx = double.Parse(values[4]);
                                D.roundlocations[shelf, column].diameter[diameter].ry = double.Parse(values[5]);
                                D.roundlocations[shelf, column].diameter[diameter].rz = double.Parse(values[6]);
                                D.roundlocations[shelf, column].diameter[diameter].dist = double.Parse(values[7]);
                                D.roundlocations[shelf, column].diameter[diameter].alfa = double.Parse(values[8]);
                            }
                            lines++;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                C.log("ReadPocketsLocations Fie Read Exception - " + ex.Message);
                return C.ERRNO_FAILED;
            }

            return lines;
        }
    }

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
}
