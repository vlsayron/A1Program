using System.IO;
using System.Xml.Serialization;

namespace Task1Library
{
    public class XmlFileSerializer
    {
        public void SaveToXmlFile(Catalog catalog, string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                // var formatter = new XmlSerializer(typeof(Catalog));
                // formatter.Serialize(fs, catalog);

                //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //ns.Add("", "");
                //XmlSerializer s = new XmlSerializer(typeof(Catalog));
                //s.Serialize(fs, catalog, ns);

                var ns = new XmlSerializerNamespaces();
                ns.Add("", "http://library.by/catalog");
                XmlSerializer s = new XmlSerializer(catalog.GetType(), "http://library.by/catalog");
                s.Serialize(fs, catalog, ns);

            }
        }

        public Catalog GetXmlFile(string fileName)
        {
            Catalog catalog;

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var formatter = new XmlSerializer(typeof(Catalog));
                catalog = (Catalog)formatter.Deserialize(fs);
            }

            return catalog;
        }
    }
}
