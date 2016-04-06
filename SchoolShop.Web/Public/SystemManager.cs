using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolShop.Model;
using SchoolShop.Business.BLL;

namespace SchoolShop.Web.Public
{
    public class SystemManager
    {
        /// <summary>
        /// 获取用户UID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static int GetUID(HttpRequestBase request)
        {
            HttpCookie cookie = request.Cookies["UID"];
            int uid = cookie == null ? 0 : Convert.ToInt32(cookie.Value);
            return uid;
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isLogin"></param>
        /// <returns></returns>
        public static Users GetCurrentUser(HttpRequestBase request)
        {
            Users user = new Users();
            HttpCookie cookie = request.Cookies["UID"];
            int uid = cookie == null ? 0 : Convert.ToInt32(cookie.Value);
            if (uid > 0)
            {
                user = BLLFactory.Instance.UsersBLL.GetUserByUID(uid);
            }
            return user;
        }
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isLogin"></param>
        /// <returns></returns>
        public static Users GetCurrentUser(HttpRequestBase request,out bool isLogin)
        {
            isLogin=false;
            Users user=new Users();
            HttpCookie cookie=request.Cookies["UID"];
            int uid = cookie == null ? 0 : Convert.ToInt32(cookie.Value);
            if (uid > 0)
            {
                isLogin = true;
                user = BLLFactory.Instance.UsersBLL.GetUserByUID(uid);
            }
            return user;
        }


    }
}