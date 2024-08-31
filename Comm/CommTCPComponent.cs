using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// using ActUtlTypeLib;
using MCProtocol;

namespace HermleCS.Comm
{
    public class CommTCPComponent : CommModule
    {
        private string IP;
        private int Port;
        private Mitsubishi.McFrame FrameType = Mitsubishi.McFrame.MC3E;

        private static readonly CommTCPComponent instance = new CommTCPComponent();
        private CommTCPComponent() { }

//        private ActUtlType plc;
        private Mitsubishi.Plc plc = null;

        public static CommTCPComponent Instance
        {
            get
            {
                return instance;
            }
        }

        public await bool init(string ip, sint port)
        {
            IP = ip;
            Port = port;

            try
            {
                plc = new Mitsubishi.McProtocolTcp(IP, Port, FrameType);

                if (plc.Connected == false)
                {
                    await plc.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }

            return true;
        }

        public bool destroy()
        {
            Console.WriteLine("Destroy..............");

            try
            {
                plc?.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public override bool readMessage(string deviceid, out string readVal)
        {
            Console.WriteLine("readMessage..............");

            int retCode;
            short rVal = -1;

            try
            {
                retCode = plc.ReadDeviceRandom2(deviceid, 1, out rVal);
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

        public override bool sendMessage(string deviceid, short val)
        {
            Console.WriteLine("sendMessage..............");

            int retCode;

            try
            {
                retCode = plc.WriteDeviceRandom2(deviceid, 1, ref val);
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