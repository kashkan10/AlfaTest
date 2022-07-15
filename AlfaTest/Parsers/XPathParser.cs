using System;
using System.Text;
using System.Xml;

namespace AlfaTest
{
    public class XPathParser : IParser
    {
        private readonly XmlDocument xDoc = new XmlDocument();

        public string Parse(string path)
        {
            try
            {
                xDoc.Load(path);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            var result = new StringBuilder();
            var items = xDoc.DocumentElement?.SelectNodes("//item");

            foreach (XmlNode item in items)
            {
                result.Append(item.SelectSingleNode("title")?.InnerText + "\r\n");
                result.Append(item.SelectSingleNode("link")?.InnerText + "\r\n");
                result.Append(item.SelectSingleNode("description")?.InnerText + "\r\n");
                result.Append(item.SelectSingleNode("category")?.InnerText + "\r\n");
                result.Append(item.SelectSingleNode("pubDate")?.InnerText + "\r\n");
                result.Append(new string('-', 25) + "\r\n");
            }

            return result.ToString();
        }
    }
}