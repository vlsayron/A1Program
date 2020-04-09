using System;
using System.Linq;
using System.Web;
using FileHandler.FileBuilder;
using Module5Linq2db;

namespace FileHandler
{
    public class FileHandler : IHttpHandler
    {
        private readonly DbNorthwind _dbModel;

        public bool IsReusable => true;

        public FileHandler()
        {
            _dbModel = new DbNorthwind();
        }

        public void ProcessRequest(HttpContext context)
        {
            
            var customerId = context.Request.Params.Get("customer");
            var dateTo = Convert.ToDateTime(context.Request.Params.Get("dateTo"));
            var dateFrom = Convert.ToDateTime(context.Request.Params.Get("dateFrom"));
            var skip = Convert.ToInt32(context.Request.Params.Get("skip"));
            var take = Convert.ToInt32(context.Request.Params.Get("take"));
            
            var orders = _dbModel.Orders.OrderBy(o => o.CustomerID).ToList();

            if (!string.IsNullOrWhiteSpace(customerId))
            {
                orders = orders.Where(x => x.CustomerID == customerId).ToList();
            }

            if (dateFrom != DateTime.MinValue)
            {
                orders = orders.Where(x => x.RequiredDate >= dateFrom).ToList();
            }

            if (dateTo != DateTime.MinValue)
            {
                orders = orders.Where(x => x.RequiredDate <= dateTo).ToList();
            }

            if (skip != 0)
            {
                orders = orders.Skip(skip).ToList();
            }

            if (take != 0)
            {
                orders = orders.Take(take).ToList();
            }

            var fileType = FileRequest.GetType(context.Request.Headers["Accept"]);
            
            IFileBuilder fileBuilder;
            string fileNameExtension;
            string contentType;

            switch (fileType)
            {
                case FileRequest.FileRequestTypeEnum.XmlDocument:
                    {
                        fileBuilder = new XmlBuilder();
                        fileNameExtension = ".xml";
                        contentType = "text/xml";
                        break;
                    }
                case FileRequest.FileRequestTypeEnum.ExcelDocument:
                    {
                        fileBuilder = new ExcelBuilder();
                        fileNameExtension = ".xlsx";
                        contentType = "application/vnd.ms-excel";
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var stream = fileBuilder.BuildFile(orders);

            var fileName = $"Orders_{DateTime.Now}{fileNameExtension}";

            context.Response.Clear();
            context.Response.ContentType = contentType;
            context.Response.Buffer = true;
            context.Response.BinaryWrite(stream.ToArray());
            context.Response.AddHeader("content-disposition", $"attachment; filename={fileName}");
            context.Response.End();

        }


    }
}