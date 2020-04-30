using System;
using System.Xml.Serialization;

namespace Task1Library
{
    [Serializable, XmlRoot("book")]
    public class Book
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(elementName: "isbn")]
        public string Isbn { get; set; }
        [XmlElement(elementName: "author")]
        public string Author { get; set; }
        [XmlElement(elementName: "title")]
        public string Title { get; set; }
        [XmlElement(elementName: "genre")]
        public Genre Genre { get; set; }
        [XmlElement(elementName: "publisher")]
        public string Publisher { get; set; }
        [XmlElement(elementName: "publish_date")]
        public DateTime PublishDate { get; set; }
        [XmlElement(elementName: "description")]
        public string Description { get; set; }
        [XmlElement(elementName: "registration_date")]
        public DateTime RegistrationDate { get; set; }

        public Book()
        {
        }

        public Book(string id, string isbn, string author, string title, Genre genre, string publisher, DateTime publishDate, string description, DateTime registrationDate)
        {
            Id = id;
            Isbn = isbn;
            Author = author;
            Title = title;
            Genre = genre;
            Publisher = publisher;
            PublishDate = publishDate;
            Description = description;
            RegistrationDate = registrationDate;
        }
    }
}
