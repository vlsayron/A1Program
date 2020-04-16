using Module5Linq2db.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using ClosedXML.Excel;

namespace FileHandler.FileBuilder
{
    internal class ExcelBuilder : IFileBuilder
    {
        public MemoryStream BuildFile(IEnumerable<Order> orders)
        {
            var stream = new MemoryStream();

            using (var excelBook = new XLWorkbook())
            {
                var worksheet = excelBook.Worksheets.Add("Orders");

                worksheet.Cell("A1").Value = "Customer";
                worksheet.Cell("B1").Value = "Ship name";
                worksheet.Cell("C1").Value = "Order date";
                worksheet.Cell("D1").Value = "Address";
                worksheet.Cell("E1").Value = "Freight";

                var i = 2;

                foreach (var order in orders)
                {
                    worksheet.Cell("A" + i).Value = order.CustomerID;
                    worksheet.Cell("B" + i).Value = order.ShipName;
                    worksheet.Cell("C" + i).Value = order.OrderDate;
                    worksheet.Cell("D" + i).Value = $"{order.ShipCountry}, {order.ShipCity}";
                    worksheet.Cell("E" + i).Value = order.Freight;

                    i++;
                }

                excelBook.SaveAs(stream);
                stream.Position = 0;
            }

            return stream;

        }
    }
}