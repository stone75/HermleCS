using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCProtocol;

namespace Raon.Lib.Plc
{
    public class MelsecConfig
    {
        public string IP    { get; set; }
        public int Port     { get; set; }
        public Mitsubishi.McFrame FrameType     { get; set; }
    }
}
