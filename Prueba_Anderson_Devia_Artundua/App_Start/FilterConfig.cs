using System.Web;
using System.Web.Mvc;

namespace Prueba_Anderson_Devia_Artundua
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
