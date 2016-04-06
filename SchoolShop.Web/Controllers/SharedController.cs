using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolShop.Model;
using SchoolShop.Business.BLL;
using SchoolShop.Web.Public;

namespace SchoolShop.Web.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Shared/

        /// <summary>
        /// 网站顶部
        /// </summary>
        /// <returns></returns>
        public ActionResult SSTop()
        {
            bool isLogin=false;
            Users user=Public.SystemManager.GetCurrentUser(this.Request, out isLogin);
            return View(user);
        }

        /// <summary>
        /// 分类
        /// </summary>
        /// <returns></returns>
        public ActionResult SSCatalog()
        {
            #region 商品分类
            List<Catalogs> catalogs = BLLFactory.Instance.ProductBLL.GetAllCatalogs();
            Dictionary<string, List<Catalogs>> dicCatalog = catalogs.GroupBy(c => c.ParentID).ToDictionary(o => o.Key, o => o.ToList());
            this.ViewBag.dicCatalog = dicCatalog;
            #endregion

            return View();
        }

        /// <summary>
        /// 头部连接
        /// </summary>
        /// <returns></returns>
        public ActionResult SSHeadLink()
        {
            return View();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult Search()
        {
            return View();
        }

        /// <summary>
        /// 用户中心左边
        /// </summary>
        /// <returns></returns>
        public ActionResult SSLeft()
        {
            return View();
        }

        /// <summary>
        /// 用户购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult SUserShopCart()
        {
            int uid = SystemManager.GetUID(this.Request);
            List<ShopCart> list = new List<ShopCart>();
            decimal money = 0;
            if (uid > 0)
            {
               list = BLLFactory.Instance.UsersBLL.GetShopCart(uid);
               foreach (var item in list)
               {
                   money = money + item.Price;
               }
            }
            this.ViewBag.list = list;
            this.ViewBag.money = money;
            return View();
        }

    }
}
