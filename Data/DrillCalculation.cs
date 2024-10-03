using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HermleCS.Comm;

namespace HermleCS.Data
{
    internal class DrillCalculation
    {
        D data;
        double[] g_RC = new double[C.DRILL_LOCATION_POCKET_COUNT];
        double[] g_H = new double[C.DRILL_LOCATION_POCKET_COUNT];

        double g_Delta_x, g_Delta_y;
        double g_c;
        double g_gamma_c;

        double[] g_s = new double[C.DRILL_LOCATION_COLUMN_COUNT];
        double g_alfa, g_alfa_1, g_d_alfa, g_d, g_gamma_1;
        double[] g_gamma = new double[C.DRILL_LOCATION_COLUMN_COUNT];
        double[] g_lambda = new double[C.DRILL_LOCATION_COLUMN_COUNT];

        public DrillCalculation() {
            data = D.Instance;
        }

        public void DrillLoadConsts()
        {
            g_RC[0] = 1173;
            g_RC[1] = 1156.5;
            g_RC[2] = 1137.5;
            g_RC[3] = 1115;
            g_RC[4] = 1183;
            g_RC[5] = 1157.5;
            g_RC[6] = 1126;
        }

        public void DrillCalcFirstDiameter(int shelf)
        {
            // 1. 이 함수는 첫 번째 포켓의 첫 번째 직경의 NAME, DISTANCE, ANGLE을 계산합니다.
            double x;
            double y;

            try
            {
                // name
                data.DrillLocations[shelf, 0, 0].name = shelf.ToString() + "01" + ".1";

                // distance
                x = data.DrillLocations[shelf, 0, 0].x;
                y = data.DrillLocations[shelf, 0, 0].y;

                data.DrillLocations[shelf, 0, 0].dist = Math.Sqrt(x * x + y * y);

                // Alfa - X축 기준 첫 번째 포켓의 각도를 계산합니다.
                if (data.DrillLocations[shelf, 0, 0].x >= 0)
                {
                    data.DrillLocations[shelf, 0, 0].alfa = Math.Atan(Math.Abs(data.DrillLocations[shelf, 0, 0].y) / data.DrillLocations[shelf, 0, 0].x) * 360 / (2 * Math.PI);
                }
                else if (data.DrillLocations[shelf, 0, 0].x < 0)
                {
                    data.DrillLocations[shelf, 0, 0].alfa = 180 - Math.Atan(data.DrillLocations[shelf, 0, 0].y / data.DrillLocations[shelf, 0, 0].x) * 360 / (2 * Math.PI);
                }

//                SaveArray("DrillLocations");
            }
            catch (Exception ex)
            {
                C.log("error in DrillCalcFirstDiameter() the error is: " + ex.Message);
            }
        }


        public void DrillCalcLastDiameter(int shelf)
        {
            // 1. 이 함수는 마지막 포켓(12)의 첫 번째 직경(1)에 대한 NAME, DISTANCE, ANGLE을 계산합니다.
            double x;
            double y;

            try
            {
                // name
                data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT-1), 0].name = shelf.ToString() + C.DRILL_LOCATION_COLUMN_COUNT + ".1";

                // distance
                x = data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].x;
                y = data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].y;
                data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].dist = Math.Sqrt(x * x + y * y);

                // Alfa - X축을 기준으로 12번째 포켓의 각도를 계산합니다.
                if (data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].x >= 0)
                {
                    data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].alfa = Math.Atan(Math.Abs(data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].y) / data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].x) * 360 / (2 * Math.PI);
                }
                else if (data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].x < 0)
                {
                    data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].alfa = (-1) * (180 - Math.Atan(Math.Abs(data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].y) / data.DrillLocations[shelf, (C.DRILL_LOCATION_COLUMN_COUNT - 1), 0].x) * 360 / (2 * Math.PI));
                }

//                SaveArray("DrillLocations");
            }
            catch (Exception ex)
            {
                C.log("error in DrillCalcLastDiameter() the error is: " + ex.Message);
            }
        }


        public void DrillSetGeometric(int shelf)
        {
            // 1. 이 함수는 전체 선반의 공통 기하학을 계산합니다.
            // C        - 101.1에서 112.1 사이의 문자열 길이
            // Gamma_c  - 이론적 반경 R1과 R12 사이의 각도
            // S(jj)    - 직경(jj)과 직경(1) 사이의 문자열
            // Alfa, Alfa_1, D_Alfa, D, Gamma_1, Gamma(jj), Lambda(jj)

            int jj;
            double Rconst;
            double R1;
            double R12;
            double delta_x, delta_y, c, gamma_c, alfa, alfa_1, d_Alfa, d, gamma_1;
            double[] s = new double[C.DRILL_LOCATION_COLUMN_COUNT];
            double[] Gamma = new double[C.DRILL_LOCATION_COLUMN_COUNT];
            double[] Lambda = new double[C.DRILL_LOCATION_COLUMN_COUNT];

            try
            {
                delta_x = Math.Abs(data.DrillLocations[shelf, 0, 0].x) + Math.Abs(data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT, 0].x);
                delta_y = Math.Abs(Math.Abs(data.DrillLocations[shelf, 0, 0].y) - Math.Abs(data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT, 0].y));
                c = Math.Sqrt(delta_x * delta_x + delta_y * delta_y);
                Rconst = g_RC[0];
                R1 = data.DrillLocations[shelf, 0, 0].dist;
                R12 = data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT, 0].dist;

                gamma_c = Math.Acos((-c * c + Rconst * Rconst + Rconst * Rconst) / (2 * Rconst * Rconst)) / (2 * Math.PI) * 360;  // 실제 값 계산

                for (jj = 0; jj < C.DRILL_LOCATION_COLUMN_COUNT; jj++)
                {
                    // s[jj] = 2 * Rconst * Math.Sin(0.5 * (gamma_c / (C.DRILL_STATUS_POCKET_COUNT - 1)) * (jj - 1) / 360 * (2 * Math.PI));
                    s[jj] = 2 * Rconst * Math.Sin(0.5 * (gamma_c / (C.DRILL_STATUS_POCKET_COUNT - 1)) * jj / 360 * (2 * Math.PI));
                }

                alfa = (180 - gamma_c) / 2;
                alfa_1 = Math.Acos((R1 * R1 + s[12] * s[12] - R12 * R12) / (2 * R1 * s[12])) / (2 * Math.PI) * 360;
                d_Alfa = alfa - alfa_1;
                d = Math.Sqrt(Rconst * Rconst + R1 * R1 - 2 * Rconst * R1 * Math.Cos(d_Alfa / 360 * 2 * Math.PI));
                gamma_1 = Math.Acos((Rconst * Rconst + d * d - R1 * R1) / (2 * Rconst * d)) / (2 * Math.PI) * 360;

                for (jj = 2; jj <= 12; jj++)
                {
                    Gamma[jj] = Math.Acos((-s[jj] * s[jj] + Rconst * Rconst + Rconst * Rconst) / (2 * Rconst * Rconst)) / (2 * Math.PI) * 360;
                }

                for (jj = 2; jj <= 12; jj++)
                {
                    if (((R1 < Rconst) && (R12 < Rconst)) || ((R1 > Rconst) && (R12 < Rconst)))
                    {
                        Lambda[jj] = gamma_1 - Gamma[jj];
                    }
                    else if (((R1 < Rconst) && (R12 > Rconst)) || ((R1 > Rconst) && (R12 > Rconst)))
                    {
                        Lambda[jj] = gamma_1 + Gamma[jj];
                    }
                }
            }
            catch (Exception ex)
            {
                C.log("error in DrillSetGeometric() the error is: " + ex.Message);
            }
        }


        public void DrillCalculateAllIndex_1(int shelf, int diameter, int Rc)
        {
            // 1. 이 함수는 전체 선반에 대해 직경 1의 매개변수를 계산합니다.
            int column;
            int[] Sign = new int[C.DRILL_LOCATION_COLUMN_COUNT];
            int Sign_2;
            double[] R = new double[C.DRILL_LOCATION_COLUMN_COUNT];
            double[] Betta = new double[C.DRILL_LOCATION_COLUMN_COUNT];
            double[] Tetta = new double[C.DRILL_LOCATION_COLUMN_COUNT];
            double dZ;
            double dRx;
            double dRy;
            double R1;
            string digit;

            R1 = data.DrillLocations[shelf, 0, 0].dist;

            // 계산 부분
            for (column = 1; column < 11; column++)
            {
                R[column] = Math.Sqrt(Math.Pow(g_d, 2) + Math.Pow(Rc, 2) - 2 * g_d * Rc * Math.Cos(g_lambda[column] / 360 * 2 * Math.PI));
                Betta[column] = Math.Acos((Math.Pow(R1, 2) + Math.Pow(R[column], 2) - Math.Pow(g_s[column], 2)) / (2 * R1 * R[column])) / (2 * Math.PI) * 360;
            }

            // 이름 할당
            for (column = 1; column < 11; column++)
            {
                digit = column < 10 ? "0" : "";
                data.DrillLocations[shelf, column, 0].name = shelf.ToString() + digit + column.ToString() + "." + "1";
            }

            // 거리 할당
            for (column = 1; column < 11; column++)
            {
                data.DrillLocations[shelf, column, 0].dist = R[column];
            }

            // 알파 계산
            for (column = 1; column < 11; column++)
            {
                data.DrillLocations[shelf, column, 0].alfa = Betta[column] + data.DrillLocations[shelf, 0, 0].alfa;
            }

            // dZ 계산
            dZ = Math.Abs(data.DrillLocations[shelf, 0, 0].z - data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT-1, 0].z) / (C.DRILL_STATUS_POCKET_COUNT - 1);

            // Z 좌표 계산
            if (data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].z > data.DrillLocations[shelf, 0, 0].z)
            {
                for (column = 1; column < 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].z = data.DrillLocations[shelf, column - 1, 0].z + dZ;
                }
            }
            else if (data.DrillLocations[shelf, 0, 0].z > data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].z)
            {
                for (column = 1; column < 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].z = data.DrillLocations[shelf, column - 1, 0].z - dZ;
                }
            }
            else if (data.DrillLocations[shelf, 0, 0].z == data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].z)
            {
                for (column = 1; column < 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].z = data.DrillLocations[shelf, column - 1, 0].z;
                }
            }

            // X 좌표 계산
            for (column = 1; column < 11; column++)
            {
                if (data.DrillLocations[shelf, column, 0].alfa > -90)
                {
                    data.DrillLocations[shelf, column, 0].x = data.DrillLocations[shelf, column, 0].dist * Math.Cos(data.DrillLocations[shelf, column, 0].alfa * (2 * Math.PI / 360));
                }
                else if (data.DrillLocations[shelf, column, 0].alfa == -90)
                {
                    data.DrillLocations[shelf, column, 0].x = data.DrillLocations[shelf, column, 0].dist;
                }
                else if (data.DrillLocations[shelf, column, 0].alfa < -90)
                {
                    data.DrillLocations[shelf, column, 0].x = -1 * data.DrillLocations[shelf, column, 0].dist * Math.Cos((180 - data.DrillLocations[shelf, column, 0].alfa) * (2 * Math.PI / 360));
                }
            }

            // Y 좌표 계산
            for (column = 2; column <= 11; column++)
            {
                if (data.DrillLocations[shelf, column, 0].alfa < 90)
                {
                    data.DrillLocations[shelf, column, 0].y = -1 * data.DrillLocations[shelf, column, 0].dist * Math.Sin(data.DrillLocations[shelf, column, 0].alfa * (2 * Math.PI / 360));
                }
                else if (data.DrillLocations[shelf, column, 0].alfa == 90)
                {
                    data.DrillLocations[shelf, column, 0].y = -1 * data.DrillLocations[shelf, column, 0].dist;
                }
                else if (data.DrillLocations[shelf, column, 0].alfa > 90)
                {
                    data.DrillLocations[shelf, column, 0].y = -1 * data.DrillLocations[shelf, column, 0].dist * Math.Sin(data.DrillLocations[shelf, column, 0].alfa * (2 * Math.PI / 360));
                }
            }

            // dRx 계산
            dRx = Math.Abs(data.DrillLocations[shelf, 0, 0].rx - data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT-1, 0].rx) / (C.DRILL_STATUS_POCKET_COUNT - 1);

            // Rx 계산
            if (data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].rx > data.DrillLocations[shelf, 0, 0].rx)
            {
                for (column = 2; column <= 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].rx = data.DrillLocations[shelf, column - 1, 0].rx + dRx;
                }
            }
            else if (data.DrillLocations[shelf, 0, 0].rx > data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].rx)
            {
                for (column = 2; column <= 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].rx = data.DrillLocations[shelf, column - 1, 0].rx - dRx;
                }
            }
            else if (data.DrillLocations[shelf, 0, 0].rx == data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].rx)
            {
                for (column = 2; column <= 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].rx = data.DrillLocations[shelf, column - 1, 0].rx;
                }
            }

            // dRy 계산
            dRy = Math.Abs(data.DrillLocations[shelf, 0, 0].ry - data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].ry) / (C.DRILL_STATUS_POCKET_COUNT - 1);

            // Ry 계산
            if (data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].ry > data.DrillLocations[shelf, 0, 0].ry)
            {
                for (column = 1; column < 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].ry = data.DrillLocations[shelf, column - 1, 0].ry + dRy;
                }
            }
            else if (data.DrillLocations[shelf, 0, 0].ry > data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].ry)
            {
                for (column = 1; column < 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].ry = data.DrillLocations[shelf, column - 1, 0].ry - dRy;
                }
            }
            else if (data.DrillLocations[shelf, 0, 0].ry == data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT - 1, 0].ry)
            {
                for (column = 1; column < 11; column++)
                {
                    data.DrillLocations[shelf, column, 0].ry = data.DrillLocations[shelf, column - 1, 0].ry;
                }
            }

            // 테타 계산
            for (column = 1; column < 11; column++)
            {
                Tetta[column] = Math.Acos((-Math.Pow(g_d, 2) + Math.Pow(R[column], 2) + Math.Pow(Rc, 2)) / (2 * R[column] * Rc)) / (2 * Math.PI) * 360;
            }

            // 테타에 대한 부호 계산
            if ((R[1] > Rc) && (R[12] < Rc))
            {
                for (column = 0; column < 6; column++)
                {
                    Sign[column] = 1;
                }
                for (column = 6; column < 12; column++)
                {
                    Sign[column] = 1;
                }
                Sign_2 = 1;
            }
            else if ((R[1] < Rc) && (R[12] < Rc))
            {
                for (column = 0; column < 6; column++)
                {
                    Sign[column] = 1;
                }
                for (column = 6; column < 12; column++)
                {
                    Sign[column] = -1;
                }
                Sign_2 = 1;
            }
            else if ((R[1] < Rc) && (R[12] > Rc))
            {
                for (column = 0; column < 6; column++)
                {
                    Sign[column] = -1;
                }
                for (column = 6; column < 12; column++)
                {
                    Sign[column] = -1;
                }
                Sign_2 = -1;
            }
//            else if ((R[1] > Rc) && (R[12] > Rc))
            else
            {
                for (column = 0; column < 6; column++)
                {
                    Sign[column] = -1;
                }
                for (column = 6; column < 12; column++)
                {
                    Sign[column] = 1;
                }
                Sign_2 = -1;
            }

            // Rz 계산
            for (column = 2; column <= 11; column++)
            {
                data.DrillLocations[shelf, column, 0].rz = 180 - data.DrillLocations[shelf, 0, 0].alfa - Betta[column] + Sign[column] * Tetta[column] + Sign_2 * g_d_alfa;
            }

            // 저장 함수 호출
//            SaveArray("DrillLocations");
        }



        public void DrillCalcDiameter(int shelf, int index, double H)
        {
            double Tetta;
            double? R1;
            double? R12;
            double CurrRad;
            double Omega;
            int Sign;

            try
            {
                R1 = data.DrillLocations[shelf, 0, 0].dist;
                R12 = data.DrillLocations[shelf, C.DRILL_LOCATION_COLUMN_COUNT-1, 0].dist;

                Tetta = Math.Acos((D * D - R1 * R1 - Rc(1) * Rc(1)) / (-2 * R1 * Rc(1))) / (2 * Math.PI) * 360;
                CurrRad = Math.Sqrt(R1 * R1 + H * H - 2 * R1 * H * Math.Cos(Tetta / 360 * (2 * Math.PI)));
                Omega = Math.Acos((H * H - R1 * R1 - CurrRad * CurrRad) / (-2 * R1 * CurrRad)) / (2 * Math.PI) * 360;

                // name
                DrillLocations[shelf, 1].diameter[Index].name = $"{shelf}01.{Index}";

                // distance
                DrillLocations[shelf, 1].diameter[Index].Dist = CurrRad;

                // sign
                if (R1 < Rc(1) && R12 < Rc(1))
                {
                    Sign = -1;
                }
                else if (R1 < Rc(1) && R12 > Rc(1))
                {
                    Sign = 1;
                }
                else if (R1 > Rc(1) && R12 < Rc(1))
                {
                    Sign = 1;
                }
                else
                {
                    Sign = -1;
                }

                // alfa
                DrillLocations[shelf, 1].diameter[Index].Alfa = DrillLocations[shelf, 1].diameter[1].Alfa + Omega;

                // X coordinate calculation
                if (DrillLocations[shelf, 1].diameter[Index].Alfa > -90)
                {
                    DrillLocations[shelf, 1].diameter[Index].X = DrillLocations[shelf, 1].diameter[Index].Dist * Math.Cos(DrillLocations[shelf, 1].diameter[Index].Alfa * (2 * Math.PI / 360));
                }
                else if (DrillLocations[shelf, 1].diameter[Index].Alfa == -90)
                {
                    DrillLocations[shelf, 1].diameter[Index].X = DrillLocations[shelf, 1].diameter[Index].Dist;
                }
                else
                {
                    DrillLocations[shelf, 1].diameter[Index].X = -1 * DrillLocations[shelf, 1].diameter[Index].Dist * Math.Cos((180 - DrillLocations[shelf, 1].diameter[Index].Alfa) * (2 * Math.PI / 360));
                }

                // Y coordinate calculation
                if (DrillLocations[shelf, 1].diameter[Index].Alfa < 90)
                {
                    DrillLocations[shelf, 1].diameter[Index].Y = -1 * DrillLocations[shelf, 1].diameter[Index].Dist * Math.Sin(DrillLocations[shelf, 1].diameter[Index].Alfa * (2 * Math.PI / 360));
                }
                else if (DrillLocations[shelf, 1].diameter[Index].Alfa == 90)
                {
                    DrillLocations[shelf, 1].diameter[Index].Y = -1 * DrillLocations[shelf, 1].diameter[Index].Dist;
                }
                else
                {
                    DrillLocations[shelf, 1].diameter[Index].Y = -1 * DrillLocations[shelf, 1].diameter[Index].Dist * Math.Sin(DrillLocations[shelf, 1].diameter[Index].Alfa * (2 * Math.PI / 360));
                }

                // Z coordinate
                DrillLocations[shelf, 1].diameter[Index].z = DrillLocations[shelf, 1].diameter[1].z;

                // Rx, Ry, Rz coordinates
                DrillLocations[shelf, 1].diameter[Index].Rx = DrillLocations[shelf, 1].diameter[1].Rx;
                DrillLocations[shelf, 1].diameter[Index].Ry = DrillLocations[shelf, 1].diameter[1].Ry;
                DrillLocations[shelf, 1].diameter[Index].Rz = DrillLocations[shelf, 1].diameter[1].Rz;
            }
            catch (Exception ex)
            {
                C.log("error in DrillCalcDiameter() error is : " + ex.Message);
            }
        }


        public int DrillShelfCalculation(int shelf)
        {
            int rval = C.ERRNO_SUCCESS;

            DrillLoadConsts();

            return rval;
        }
    }
}
