using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermleCS.Comm
{
    public abstract class CommModule
    {
        public abstract string readMessage();
        public abstract void sendMessage();
        public abstract string test();
    }
}

