using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
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
        public static byte[] SerializeDataCarrerier(DataCarrier datacarrier, out long takttime)
        {
            takttime = 0;
            if (datacarrier == null) return null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, datacarrier);
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
        public static DataCarrier DeserializeDataCarrerier(byte[] arrByte, out long takttime)
        {
            takttime = 0;
            if (arrByte == null) return null;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arrByte, 0, arrByte.Length);
            ms.Seek(0, SeekOrigin.Begin);
            DataCarrier ob = bf.Deserialize(ms) as DataCarrier;

            sw.Stop();
            takttime = sw.ElapsedMilliseconds;
            return ob;
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        static public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }
    }
}
