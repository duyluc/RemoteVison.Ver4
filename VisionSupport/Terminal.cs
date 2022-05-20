using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionSupport
{
    [Serializable]
    public class Terminal
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }
        public Terminal(string name, object value, Type type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
    }
}
