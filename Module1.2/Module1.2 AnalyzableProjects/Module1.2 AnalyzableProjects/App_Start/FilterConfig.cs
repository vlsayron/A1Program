using System.Web;
using System.Web.Mvc;

namespace Module1._2_AnalyzableProjects
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
