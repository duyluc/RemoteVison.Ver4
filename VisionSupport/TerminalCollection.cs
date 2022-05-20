using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace VisionSupport
{
    [Serializable]
    public class TerminalCollection:Dictionary<string, Terminal>
    {
        public TerminalCollection():base()
        {

        }
        public TerminalCollection(TerminalCollection cloneob) : base()
        {
            foreach(KeyValuePair<string,Terminal> kvp in cloneob)
            {
                Terminal ob = DeepCopy.DeepCopyObject(kvp.Value);
                this.Add(kvp.Key, ob);
            }
        }
        
        public void Add(Terminal terminal)
        {
            if (terminal == null) throw new ArgumentNullException(terminal.Name);
            this.Add(terminal.Name,terminal);
        }
    }
}