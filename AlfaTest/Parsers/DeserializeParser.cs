using System;
using System.IO;
using System.Xml.Serialization;

namespace AlfaTest
{
    public class DeserializeParser<T> : IParser where T : class
    {
        public string Parse(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    T channel = xmlSerializer.Deserialize(fs) as T;
                    return channel.ToString();
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
