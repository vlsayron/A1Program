using System;
using System.Linq;
using System.Web;
using Module5Linq2db;

namespace FileHandler
{
    public class FileHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Output.WriteLine("Test message: ");

            var customerId = context.Request.Params.Get("customer");
            var dateTo = Convert.ToDateTime(context.Request.Params.Get("dateTo"));
            var dateFrom = Convert.ToDateTime(context.Request.Params.Get("dateFrom"));
            var take = Convert.ToInt32(context.Request.Params.Get("take"));
            var skip = Convert.ToInt32(context.Request.Params.Get("skip"));

            var dbModel = new DbNorthwind();

            context.Response.Output.WriteLine(dbModel.Customers.First().Address);

        }
    }
}