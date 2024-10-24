using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;
using MCProtocol;
using Raon.Lib.Plc;

namespace HermleCS.Comm
{
    public class CommTCPComponent : CommModule
    {
        private string IP;
        private int Port;
        private Mitsubishi.McFrame FrameType = Mitsubishi.McFrame.MC3E;

        // private string buffer;
        private int[] buffer;
        private int errcode;
        private string errmsg;


        private static readonly CommTCPComponent instance = new CommTCPComponent();
        private CommTCPComponent() { }

        private Mitsubishi.Plc plc = null;
        // private Mitsubishi __melsec = null;

        public static CommTCPComponent Instance
        {
            get
            {
                return instance;
            }
        }

        public bool init(string ip, int port)
        // public async void init(string ip, int port)
        {
            C.log("McProtocol Init...");
            IP = ip;
            Port = port;

            try
            {
                plc = new Mitsubishi.McProtocolTcp(IP, Port, FrameType);

                if (plc.Connected == false)
                {
                    // await plc.Open();
                    plc.Open();
                    C.log("PLC TCP Connection Open Success");
               }
            }
            catch (Exception ex)
            {
                C.log("PLC TCP Connection Open Failed : " + ex.ToString());
                return false;
            }

            return true;
        }

        public bool destroy()
        {
            C.log("PLC TCP Connection Destroy...");

            try
            {
                plc?.Close();
            }
            catch (Exception ex)
            {
                C.log("PLC TCP Connection Close Exception : " + ex.ToString());
                return false;
            }

            return true;
        }

        private async void readBlock(string addr, int length)
        {
            // string addr = txtAddress.Text.ToString();
            // string data = txtValue.Text.ToString();
            // int[] value = new int[length];

            if (buffer != null)
            {
                buffer = null;
            }

            buffer = new int[length];
            try
            {
                if (plc.Connected == true)
                {
                    await plc?.ReadDeviceBlock($"D{addr}", length, buffer);

                    // txtValue.Text = "";
                    string readString = "";
                    foreach (int v in buffer)
                    {
                        readString += v.ToString() + ",";
                        C.log($"Read Value =  {v}");
                    }
                    C.log($"TCP Read Value {readString}");
                    // txtValue.Text = readString;
                }
                else
                {
                    C.log("PLC Disconnected!!");
                }
                return;
            }
            catch (Exception ex)
            {
                C.log("PLC Read Block Exception : " + ex.ToString());
            }

            /*
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
                    C.log($"ReadBlock Read Value = {buffer}");
                }
                else
                {
                    errcode = C.ERRNO_CONNECT;
                    errmsg = "PLC Disconnected";
                    C.log($"PLC Disconnected...");
                }
            }
            catch (Exception ex)
            {
                errcode = C.ERRNO_EXCEPTION;
                errmsg = ex.Message;

                C.log("McProtocol Close Exception : " + ex.ToString());
            }
            */
        }

        private async void writeBlock(string addr, int[] block)
        {
            // buffer = null;
            errcode = C.ERRNO_SUCCESS;
            // int[] value = new int[length];

            try
            {
                if (plc.Connected == true)
                {
                    await plc?.WriteDeviceBlock($"D{addr}", block.Length, block);
                    // ReadDeviceBlock($"D{deviceid}", length, value);

                    //foreach (int v in value)
                    //{
                    //    // buffer += v.ToString() + ",";
                    //    buffer += v.ToString();
                    //}
                    string writeString = "";
                    foreach (int v in block)
                    {
                        writeString += v.ToString() + ",";
                        C.log($"Write Value =  {v}");
                    }
                    C.log($"TCP Write Value {writeString}");

                    //Console.WriteLine($"WriteBlock Read Value = {buffer}");
                }
                else
                {
                    errcode = C.ERRNO_CONNECT;
                    errmsg = "Write Block : PLC Disconnected";
                    C.log("Write Block : PLC Disconnected!!");
                }
            }
            catch (Exception ex)
            {
                errcode = C.ERRNO_EXCEPTION;
                errmsg = ex.Message;
                C.log(ex.ToString());
            }
        }

        public override bool readMessage(string deviceid, int length, out string readVal)
        {
            C.log("PLC ReadMessage..............Start");

            try
            {
                // retCode = plc.ReadDeviceRandom2(deviceid, 1, out rVal);
                // readVal = null;
                readBlock(deviceid, length);

                string readString = "";
                foreach (int v in buffer)
                {
                    readString += v.ToString() + ",";
                }
                readVal = readString;

                //if (errcode == C.ERRNO_SUCCESS)
                //{
                //    readVal = buffer;
                //}
            }
            catch (Exception e)
            {
                C.log(e.Message);
                readVal = "PLC ReadMessage Exception : " + e.Message;
                return false;
            }

            C.log("PLC ReadMessage..............End");

            return true;
        }

        public override bool sendMessage(string deviceid, int length, int[] val)
        {
            C.log("PLC sendMessage..............Start");

            try
            {
                writeBlock(deviceid, val);
            }
            catch (Exception e)
            {
                C.log(e.Message);
                return false;
            }

            C.log("PLC sendMessage..............End");
            return true;
        }

        public override string test()
        {
            /*
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
            */
            return "";
        }
    }
}