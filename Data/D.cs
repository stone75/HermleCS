﻿using HermleCS.Comm;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HermleCS.Data
{
    public class D
    {
        private static readonly D instance = new D();

        public static Locations[,,] DrillLocations = new Locations[C.DRILL_SHELF_COUNT, C.DRILL_COLUMN_COUNT, C.DRILL_POCKET_COUNT];
        public static Locations[,,] HSKLocations = new Locations[C.HSK_SHELF_COUNT, C.HSK_COLUMN_COUNT, C.HSK_POCKET_COUNT];
        public static Locations[,,] RoundLocations = new Locations[C.ROUND_SHELF_COUNT, C.ROUND_COLUMN_COUNT, C.ROUND_POCKET_COUNT];

        /*
        public static PocketProperties[,] automationstatus = new PocketProperties[C.SHELF_COUNT, C.COLUMN_COUNT];
        public static WorkPiece[] allwp = new WorkPiece[C.WORKPIECE_COUNT];
        public static ToolType apptooltype;
        */

        private D() { }

        public static D Instance
        {
            get
            {
                return instance;
            }
        }

        /*
        public void init()
        {
            int shelf, column, pocket;

            for (shelf = 0; shelf <= C.SHELF_COUNT; shelf++)
            {
                for (column = 0; column <= C.COLUMN_COUNT; column++)
                {
                    for (pocket = 0; pocket <= C.POCKET_COUNT; pocket++)
                    {
                        Console.WriteLine("Init...");
                        roundlocations[shelf, column, pocket] = new RobotPosition();
                    }
                }
            }
        }
        */

        public int ReadLocations(String toolname)
        {
            var target;
            String targetfile;

            if ( toolname.Equals("DRILL") || toolname.Equals("drill") )
            {
                target = DrillLocations;
                targetfile = "Drill";
            }
            else if (toolname.Equals("HSK") || toolname.Equals("hsk"))
            {
                target = HSKLocations;
                targetfile = "HSK";
            }
            else if (toolname.Equals("ROUND") || toolname.Equals("round"))
            {
                target = RoundLocations;
                targetfile = "Round";
            }
            else
            {
                return C.ERRNO_FAILED;
            }



            String dummy;
            int shelf, column, pocket;
            String filePath;
            int lines = 0;

            try
            {
                //                filePath = Path.Combine(C.ApplicationPath, "WorkDirectory", "Data", arrayname, ".csv");
                filePath = Path.Combine(C.ApplicationPath, "CSV", targetfile, "Locations.csv");

                using (StreamReader reader = new StreamReader(filePath))
                {
                    // 헤더 읽기
                    dummy = reader.ReadLine();

                    for (shelf = 0; shelf <= C.SHELF_COUNT; shelf++)
                    {
                        for (column = 0; column <= C.COLUMN_COUNT; column++)
                        {
                            for (pocket = 0; pocket <= C.POCKET_COUNT; pocket++)
                            {
                                dummy = reader.ReadLine();
                                string[] values = dummy.Split(',');
                                target[shelf, column, pocket].name = values[0];
                                target[shelf, column, pocket].x = double.Parse(values[1]);
                                target[shelf, column, pocket].y = double.Parse(values[2]);
                                target[shelf, column, pocket].z = double.Parse(values[3]);
                                target[shelf, column, pocket].rx = double.Parse(values[4]);
                                target[shelf, column, pocket].ry = double.Parse(values[5]);
                                target[shelf, column, pocket].rx = double.Parse(values[6]);
                                target[shelf, column, pocket].dist = double.Parse(values[7]);
                                target[shelf, column, pocket].alfa = double.Parse(values[8]);

                                lines++;
                            }
                        }
                    }

                    C.log($"Reading : {lines}");
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                C.log("Read Locations Exception ; " + ex.Message);
                return C.ERRNO_FAILED;
            }

            return lines;
        }


        public int WriteLocations(String toolname)
        {
            var target;
            String targetfile;
            int shelf_count, column_count, pocket_count;

            if (toolname.Equals("DRILL") || toolname.Equals("drill"))
            {
                target = DrillLocations;
                targetfile = "Drill";
                shelf_count = C.DRILL_SHELF_COUNT;
                column_count = C.DRILL_COLUMN_COUNT;
                pocket_count = C.DRILL_POCKET_COUNT;
            }
            else if (toolname.Equals("HSK") || toolname.Equals("hsk"))
            {
                target = HSKLocations;
                targetfile = "HSK";
                shelf_count = C.HSK_SHELF_COUNT;
                column_count = C.HSK_COLUMN_COUNT;
                pocket_count = C.HSK_POCKET_COUNT;
            }
            else if (toolname.Equals("ROUND") || toolname.Equals("round"))
            {
                target = RoundLocations;
                targetfile = "Round";
                shelf_count = C.ROUND_SHELF_COUNT;
                column_count = C.ROUND_COLUMN_COUNT;
                pocket_count = C.ROUND_POCKET_COUNT;
            }
            else
            {
                return C.ERRNO_FAILED;
            }

            String dummy;
            int shelf, column, pocket;
            String filePath;
            int lines = 0;

            try
            {
                //                filePath = Path.Combine(C.ApplicationPath, "WorkDirectory", "Data", arrayname, ".csv");
                filePath = Path.Combine(C.ApplicationPath, "CSV", targetfile, "Locations.csv");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Pocket Name , x , y , z , Rx , Ry , Rz , Distance , Alfa");

                    for (shelf = 0; shelf <= shelf_count; shelf++)
                    {
                        for (column = 0; column <= column_count; column++)
                        {
                            for (pocket = 0; pocket <= pocket_count; pocket++)
                            {
                                var name = target[shelf, column, pocket].name;
                                var x = target[shelf, column, pocket].x;
                                var y = target[shelf, column, pocket].y;
                                var z = target[shelf, column, pocket].z;
                                var rx = target[shelf, column, pocket].rx;
                                var ry = target[shelf, column, pocket].ry;
                                var rz = target[shelf, column, pocket].rz;
                                var dist = target[shelf, column, pocket].dist;
                                var alfa = target[shelf, column, pocket].alfa;
                                writer.WriteLine($"{name} , {x} , {y} , {z} , {rx} , {ry} , {rz} , {dist}, {alfa}");

                                lines++;
                            }
                        }
                    }
                    C.log($"Writer Locations : {lines}");
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                C.log("Write Locations Exception ; " + ex.Message);
                return C.ERRNO_FAILED;
            }

            return lines;
        }
    }

    public class RoundData
    {
        /*
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
                                var location = roundlocations[shelf, column, pocket];
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

        */
    }
}
