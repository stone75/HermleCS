using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermleCS.Comm
{
    public abstract class CommModule
    {
        public abstract bool readMessage(string deviceid, out string readVal);
        public abstract bool sendMessage(string deviceid, short val);
        public abstract string test();
    }
}

