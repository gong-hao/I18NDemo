using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestI18n.Models;

namespace TestI18n
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            var getLangFromUserLanguage = new GetLangFromUserLanguage();

            var lang = getLangFromUserLanguage.GetLang(Context);

            if (!string.IsNullOrWhiteSpace(lang))
            {
                var cultureInfo = new System.Globalization.CultureInfo(lang);

                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;

                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
        }
    }
}