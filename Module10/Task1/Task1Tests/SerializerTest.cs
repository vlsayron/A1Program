using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Library;

namespace Task1Tests
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void TestMentoringTaskFile()
        {
            //Testing the file from mentoring task
            var fileName = @"..\..\books.xml";
            var catalog = GetCatalogFromFile(fileName);
            PrintCatalog(catalog);
        }

        [TestMethod]
        public void TestMentoringTaskFile_SerializeDeSerialize()
        {
            //Read source mentoring task file, serialize and deserialize
            var sourceFileName = @"..\..\books.xml";
            var targetFileName = "XmlCatalogTest.xml";
            var sourceCatalog = GetCatalogFromFile(sourceFileName);
            SaveToXmlFile(sourceCatalog, targetFileName);
            var readCatalog = GetCatalogFromFile(targetFileName);

            PrintCatalog(readCatalog);
        }


        [TestMethod]
        public void SerializeCatalog()
        {
            //Custom test( serialize and deserialize)

            var book1 = new Book("bk101",
                "0-596-00103-7",
                "Löwy, Juval",
                "COM and .NET Component Services",
                Genre.Computer,
                "O'Reilly",
                DateTime.Now,
                "COM &amp; .NET Component Services provides both traditional COM programmers and new .NET component developers with the information they need to begin developing applications that take full advantage of COM + services. This book focuses on COM + services, including support for transactions, queued components, events, concurrency management, and security",
                DateTime.Now);
            var book2 = new Book("bk102",
                null,
                "Ralls, Kim",
                "Midnight Rain",
                Genre.Fantasy,
                "R & D",
                DateTime.Now,
                "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world.",
                DateTime.Now);
            var book3 = new Book("bk103",
                null,
                "Corets, Eva",
                "Maeve Ascendant",
                Genre.Fantasy,
                "R & D",
                DateTime.Now,
                "After the collapse of a nanotechnology society in England, the young survivors lay the foundation for a new society.",
                DateTime.Now);

            var catalog = new Catalog {Date = new DateTime(2016, 2, 5)};
            catalog.AddBooks(book1, book2, book2);


            var fileName = "XmlCatalog.xml";
            SaveToXmlFile(catalog, fileName);

            var catalogFromFile = GetCatalogFromFile(fileName);
            PrintCatalog(catalogFromFile);
        }


        private void SaveToXmlFile(Catalog catalog, string fileName)
        {
            var fileSerializer = new XmlFileSerializer();

            fileSerializer.SaveToXmlFile(catalog, fileName);
        }

        private Catalog GetCatalogFromFile(string fileName)
        {
            var fileSerializer = new XmlFileSerializer();

            var catalog = fileSerializer.GetXmlFile(fileName);

            return catalog;
        }

        private void PrintCatalog(Catalog catalog)
        {
            Console.WriteLine("Catalog: ");
            foreach (var book in catalog.Books)
            {
                Console.WriteLine(
                    $"Desirialized book:\n " +
                    $"ISBN: {book.Isbn},\n " +
                    $"Author: {book.Author},\n " +
                    $"Title: {book.Title},\n " +
                    $"Genre: {book.Genre},\n " +
                    $"Publisher: {book.Publisher},\n " +
                    $"Publish Date: {book.PublishDate},\n " +
                    $"Description: {book.Description},\n " +
                    $"Registration Date: {book.RegistrationDate}");
            }
        }

    }
}
