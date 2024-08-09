using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HermleCS.Comm
{
    public class PLCCommModule : CommModule
    {
        private static readonly PLCCommModule instance = new PLCCommModule();
        private PLCCommModule() { }

        public static PLCCommModule Instance
        {
            get
            {
                return instance;
            }
        }

        public bool init()
        {
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
    }
}
