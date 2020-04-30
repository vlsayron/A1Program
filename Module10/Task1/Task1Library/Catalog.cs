using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Task1Library
{
    [XmlRoot(ElementName = "catalog", Namespace = "http://library.by/catalog")]
    public class Catalog
    {
        [XmlElement(elementName: "book")]
        public List<Book> Books { get; set; }

        [XmlAttribute(attributeName: "date")]
        public DateTime Date { get; set; }
        
        public void AddBooks(params Book[] books)
        {
            Books.AddRange(books);
        }

        public Catalog()
        {
            Books = new List<Book>();
        }
    }
}
