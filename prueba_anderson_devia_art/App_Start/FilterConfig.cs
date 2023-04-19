using System.Web;
using System.Web.Mvc;

namespace prueva_anderson_devia_art
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
