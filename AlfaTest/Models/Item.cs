using System.Xml.Serialization;

namespace AlfaTest
{
    [XmlRoot("item")]
    public class Item
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("pubDate")]
        public string PubDate { get; set; }
    }
}
