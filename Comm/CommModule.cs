using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermleCS.Comm
{
    public abstract class CommModule
    {
        public abstract bool readMessage(string deviceid, int length, out string readVal);
        public abstract bool sendMessage(string deviceid, int length, int[] val);
        public abstract string test();
    }
}

