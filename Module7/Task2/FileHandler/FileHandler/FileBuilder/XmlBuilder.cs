using Module5Linq2db.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace FileHandler.FileBuilder
{
    internal class XmlBuilder : IFileBuilder
    {
        public MemoryStream BuildFile(IEnumerable<Order> orders)
        {
            var doc = new XDocument();
            var ordersXml = new XElement("orders");

            foreach (var order in orders)
            {
                var orderXml = new XElement("order");

                var customer = new XAttribute("Customer", order.CustomerID);
                var shipName = new XElement("ShipName", order.ShipName);
                var orderDate = new XElement("OrderDate", order.OrderDate);
                var address = new XElement("Address", $"{order.ShipCountry}, {order.ShipCity}");
                var freight = new XElement("Freight", order.Freight);

                orderXml.Add(customer);
                orderXml.Add(shipName);
                orderXml.Add(orderDate);
                orderXml.Add(address);
                orderXml.Add(freight);

                ordersXml.Add(orderXml);
            }

            var stream = new MemoryStream();
            doc.Add(ordersXml);
            doc.Save(stream);
            stream.Position = 0;

            return stream;
        }
    }
}