using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ActUtlTypeLib;

namespace HermleCS.Comm
{
    public class PLCCommModule : CommModule
    {
        private static readonly PLCCommModule instance = new PLCCommModule();
        private PLCCommModule() { }

        private ActUtlType plc;

        public static PLCCommModule Instance
        {
            get
            {
                return instance;
            }
        }

        public bool init()
        {
            plc = new ActUtlType();
            plc.ActLogicalStationNumber = 1;
            string hex = "0x";
            int result;

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

        public override string readMessage()
        {
            Console.WriteLine("readMessage..............");
            MessageBox.Show("readMessage");

            return "";
            // throw new NotImplementedException();
        }

        public override void sendMessage()
        {
            Console.WriteLine("sendMessage..............");
            MessageBox.Show("sendMessage");
            // throw new NotImplementedException();
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
