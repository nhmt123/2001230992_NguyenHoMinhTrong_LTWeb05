using System.Web;
using System.Web.Mvc;

namespace LTWeb05_Bai01_Bai02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
