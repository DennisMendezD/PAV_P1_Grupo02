using System.Web;
using System.Web.Mvc;

namespace PAV_P1_Grupo02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
