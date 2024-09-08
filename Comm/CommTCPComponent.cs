using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private string buffer;
        private int errcode;
        private string errmsg;


        private static readonly CommTCPComponent instance = new CommTCPComponent();
        private CommTCPComponent() { }

        private Mitsubishi.Plc plc = null;

        public static CommTCPComponent Instance
        {
            get
            {
                return instance;
            }
        }

        public bool init(string ip, int port)
        //        public async void init(string ip, int port)
        {
            IP = ip;
            Port = port;

            try
            {
                plc = new Mitsubishi.McProtocolTcp(IP, Port, FrameType);

                if (plc.Connected == false)
                {
                    // await plc.Open();
                    plc.Open();
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

        private async void readBlock(string deviceid, int length)
        {
            buffer = null;
            errcode = 0;
            int[] value = new int[length];

            try
            {
                if (plc.Connected == true)
                {
                    await plc?.ReadDeviceBlock($"D{deviceid}", length, value);

                    foreach (int v in value)
                    {
                        // buffer += v.ToString() + ",";
                        buffer += v.ToString();
                    }
                    Console.WriteLine($"ReadBlock Read Value = {buffer}");
                }
                else
                {
                    errcode = C.ERRNO_CONNECT;
                    errmsg = "PLC Disconnected";
                    Console.WriteLine("PLC Disconnected!!");
                }

            }
            catch (Exception ex)
            {
                errcode = C.ERRNO_EXCEPTION;
                errmsg = ex.Message;
                Console.WriteLine(ex.ToString());
            }
        }

        public override bool readMessage(string deviceid, int length, out string readVal)
        {
            Console.WriteLine("readMessage..............");

            try
            {
                // retCode = plc.ReadDeviceRandom2(deviceid, 1, out rVal);
                readVal = null;
                readBlock(deviceid, length);
                if (errcode == C.ERRNO_SUCCESS)
                {
                    readVal = buffer;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                readVal = "Err : " + e.Message;
                return false;
            }

            return true;
        }

        private async void writeBlock(string deviceid, int length, )
        {
            buffer = null;
            errcode = 0;
            int[] value = new int[length];

            try
            {
                if (plc.Connected == true)
                {
                    await plc?.ReadDeviceBlock($"D{deviceid}", length, value);

                    foreach (int v in value)
                    {
                        // buffer += v.ToString() + ",";
                        buffer += v.ToString();
                    }
                    Console.WriteLine($"ReadBlock Read Value = {buffer}");
                }
                else
                {
                    errcode = C.ERRNO_CONNECT;
                    errmsg = "PLC Disconnected";
                    Console.WriteLine("PLC Disconnected!!");
                }

            }
            catch (Exception ex)
            {
                errcode = C.ERRNO_EXCEPTION;
                errmsg = ex.Message;
                Console.WriteLine(ex.ToString());
            }
        }

        public override bool sendMessage(string deviceid, int length, int[] val)
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