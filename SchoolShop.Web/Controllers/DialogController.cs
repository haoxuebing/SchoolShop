using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolShop.Web.Public;
using SchoolShop.Business.BLL;
namespace SchoolShop.Web.Controllers
{
    public class DialogController : Controller
    {

        /// <summary>
        /// 添加咨询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [IsLoginCheck]
        public ActionResult AddConsult()
        {
            int dialogPID = Convert.ToInt32(this.Request["dialogPID"]);
            int replyUID = Convert.ToInt32(this.Request["replyUID"]);
            string consult = this.Request["consult"].ToString();
            int consultUID = SystemManager.GetUID(this.Request);
            int result = BLLFactory.Instance.DialogBLL.AddConsult(dialogPID, consultUID, consult, replyUID);
            if (result > 0)
            {
                return this.Content("ok");
            }
            else
            {
                return this.Content("error");
            }

        }

    }
}
