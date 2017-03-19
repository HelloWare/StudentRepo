using System.Web;
using System.Web.Mvc;

namespace HWA.Ecom.Wed
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
