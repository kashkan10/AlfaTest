using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AlfaTest
{
    [XmlRoot("channel")]
    public class Channel
    {
        [XmlElement("item")]
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach(var item in Items)
            {
                result.Append(item.Title + "\r\n");
                result.Append(item.Link + "\r\n");
                result.Append(item.Description + "\r\n");
                result.Append(item.Category + "\r\n");
                result.Append(item.PubDate+ "\r\n");
                result.Append(new string('-', 25) + "\r\n");
            }

            return result.ToString();
        }
    }
}
