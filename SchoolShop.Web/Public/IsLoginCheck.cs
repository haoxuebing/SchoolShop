using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolShop.Web.Public
{
    /// <summary>
    /// 切片编程验证登陆
    /// </summary>
    public class IsLoginCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
            HttpCookie cookie = filterContext.RequestContext.HttpContext.Request.Cookies["UID"];
            int uid = cookie == null ? 0 : Convert.ToInt32(cookie.Value);
            if (uid == 0)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new System.Web.Routing.RouteValueDictionary(
                    new { controller = "User", action = "Login", returnurl = returnUrl })
                );
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}