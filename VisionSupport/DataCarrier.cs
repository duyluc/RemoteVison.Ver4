using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionSupport;

namespace VisionSupport
{
    [Serializable]
    public class DataCarrier
    {
        //public enum Command
        public string ToolID { get; set; }
        public TerminalCollection TerminalCollection { get; set; }
        public DataCarrier(string toolid, TerminalCollection terminalcollection)
        {
            this.ToolID = toolid;
            this.TerminalCollection = terminalcollection;
        }
    }
}