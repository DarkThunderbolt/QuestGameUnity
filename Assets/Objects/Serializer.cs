using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Assets
{
    public class Serializer
	{
        public static void Serialize<T>(T obj, string fileName) where T : class
		{
            fileName +=  ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
			{
                serializer.Serialize(fStream, obj);
			}
		}

		public static T DeSerialize<T>(string fileName) where T : class
        {
            fileName += ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T newObj;
			using (Stream fStream = File.OpenRead(fileName))
			{
                newObj = (T)serializer.Deserialize(fStream);
			}
			return newObj;
		}
    }
}
