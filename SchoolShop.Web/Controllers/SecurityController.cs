using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolShop.Web.Public;
using SchoolShop.Business.BLL;

namespace SchoolShop.Web.Controllers
{
    public class SecurityController : Controller
    {
        #region 安全中心

        /// <summary>
        /// 安全中心
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult UserSecurity()
        {
            return View();

        }
        /// <summary>
        /// 安全中心-修改密码
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult Security_Password()
        {
            return View();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        [HttpPost]
        public ActionResult ChangePassword()
        {
            int uid = SystemManager.GetUID(this.Request);
            string password = this.Request["password"];
            string password2 = Public.EDncrypt.MD5Encrypt(password + "shcool");
            int result = BLLFactory.Instance.UsersBLL.ChangePasswordByUID(uid, password2);
            if (result > 0)
            {
                return this.Content("ok");
            }
            else
            {
                return this.Content("error");
            }
        }

        #endregion

    }
}
