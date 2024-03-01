using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Unit2
{
    internal static class CopyClass
    {
        public static T DeepCopy<T>(this T self)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);

                object copy = bf.Deserialize(stream);

                return (T)copy;
            }
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));

                s.Serialize(stream, self);
                stream.Position = 0;
                return (T)s.Deserialize(stream);
            }
        }
    }
}
