using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using VisionSupport;

namespace Serialize
{
    public static class Serialize
    {
        public static byte[] SerialObject(object ob,out long takttime)
        {
            takttime = 0;
            if (ob == null) return null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BinaryFormatter bf = new BinaryFormatter();
            using(MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, ob);
                sw.Stop();
                takttime = sw.ElapsedMilliseconds;
                return ms.ToArray();
            }
        }
        public static object DeserializeObject(byte[] arrByte, out long takttime)
        {
            takttime = 0;
            if(arrByte == null) return null;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arrByte, 0, arrByte.Length);
            ms.Seek(0,SeekOrigin.Begin);
            object ob = bf.Deserialize(ms);

            sw.Stop();
            takttime = sw.ElapsedMilliseconds;
            return ob;
        }
        public static byte[] SerializeTerminalCollection(TerminalCollection terminals,out long takttime)
        {
            takttime = 0;
            if (terminals == null) return null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, terminals);
                sw.Stop();
                takttime = sw.ElapsedMilliseconds;
                return ms.ToArray();
            }
        }
        public static TerminalCollection DeserializeTerminalCollection(byte[] arrByte, out long takttime)
        {
            takttime = 0;
            if (arrByte == null) return null;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arrByte, 0, arrByte.Length);
            ms.Seek(0, SeekOrigin.Begin);
            TerminalCollection ob = bf.Deserialize(ms) as TerminalCollection;

            sw.Stop();
            takttime = sw.ElapsedMilliseconds;
            return ob;
        }
    }
}
