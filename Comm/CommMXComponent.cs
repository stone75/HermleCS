using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ActUtlTypeLib;

namespace $safeprojectname$.Comm
{
    public class CommMXComponent : CommModule
    {
        private static readonly CommMXComponent instance = new CommMXComponent();
        private CommMXComponent() { }

        private ActUtlType plc;

        public static CommMXComponent Instance
        {
            get
            {
                return instance;
            }
        }

        public bool init(int number)
        {
            plc = new ActUtlType();
            plc.ActLogicalStationNumber = number;
            string hex = "0x";
            int result;

            Console.WriteLine("Init..............");

            try
            {
                if ( (result = plc.Open()) != 0 )
                {
                    hex += result.ToString("X8");
                    Console.WriteLine("Connection Failed..." + hex);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool destroy()
        {
            Console.WriteLine("Destroy..............");

            try
            {
                plc.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public override bool readMessage(string deviceid, int length, out string readVal)
        {
            Console.WriteLine("readMessage..............");

            int retCode;
            short rVal = -1;

            try
            {
                retCode = plc.ReadDeviceRandom2(deviceid, length, out rVal);
                readVal = "0x" + rVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                readVal = "Err : " + e.Message;
                return false;
            }

            return true;
        }

        public override bool sendMessage(string deviceid, int length, int[] val)
        {
            Console.WriteLine("sendMessage..............");

            int retCode;

            try
            {
                retCode = plc.WriteDeviceRandom(deviceid, length, ref val[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public override string test()
        {
            Console.WriteLine("Comm Module Test..........");

            string ret;
            int value;
            try
            {
                plc.GetDevice("D1010", out value);
                ret = "Device Read : " + value;
            }
            catch (Exception e)
            {
                ret = e.Message;
            }

            return ret;
        }
    }
}
