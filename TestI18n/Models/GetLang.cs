using System.Linq;
using System.Web;
using System.Web.Routing;

namespace TestI18n.Models
{
    public interface IGetLang
    {
        string GetLang(HttpContext context);

        string DefaultLang { get; }
    }

    /// <summary>
    /// 使用 Cookie 決定語系
    /// </summary>
    public class GetLangFromCookie : IGetLang
    {
        public string GetLang(HttpContext context)
        {
            var cookie = context.Request.Cookies["lang"];

            if (cookie != null && !string.IsNullOrWhiteSpace(cookie.Value))
            {
                return cookie.Value;
            }

            return DefaultLang;
        }

        public string DefaultLang
        {
            get
            {
                return "zh-tw";
            }
        }
    }

    /// <summary>
    /// 使用 QueryString 決定語系
    /// </summary>
    public class GetLangFromQueryString : IGetLang
    {
        public string GetLang(HttpContext context)
        {
            var lang = context.Request.QueryString["lang"];

            if (!string.IsNullOrWhiteSpace(lang))
            {
                return lang;
            }

            return DefaultLang;
        }

        public string DefaultLang
        {
            get
            {
                return "zh-tw";
            }
        }
    }

    /// <summary>
    /// 使用 Route 決定語系
    /// </summary>
    public class GetLangFromRoute : IGetLang
    {
        public string GetLang(HttpContext context)
        {
            var httpContextWrapper = new HttpContextWrapper(context);

            var routeData = RouteTable.Routes.GetRouteData(httpContextWrapper);

            var lang = routeData.GetRequiredString("lang");

            if (!string.IsNullOrWhiteSpace(lang))
            {
                return lang;
            }

            return DefaultLang;
        }

        public string DefaultLang
        {
            get
            {
                return "zh-tw";
            }
        }
    }

    /// <summary>
    /// 使用 Accept-Language 決定語系
    /// </summary>
    public class GetLangFromUserLanguage : IGetLang
    {
        public string GetLang(HttpContext context)
        {
            var userLanguages = context.Request.UserLanguages;

            var lang = userLanguages.FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(lang))
            {
                return lang;
            }

            return DefaultLang;
        }

        public string DefaultLang
        {
            get
            {
                return "zh-tw";
            }
        }
    }
}