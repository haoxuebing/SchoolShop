using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolShop.Model;
using SchoolShop.Business.BLL;

namespace SchoolShop.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            #region 商品分类
            List<Catalogs> catalogs = BLLFactory.Instance.ProductBLL.GetAllCatalogs(); // BLLFactory.GetInstance().ProductBLL.GetAllCatalogs();
            Dictionary<string, List<Catalogs>> dicCatalog = catalogs.GroupBy(c => c.ParentID).ToDictionary(o => o.Key, o => o.ToList());
            this.ViewBag.dicCatalog = dicCatalog;
            #endregion

            #region 最热门的商品
            List<Products> hotProducts = BLLFactory.Instance.ProductBLL.GetHotProducts(6);// BLLFactory.GetInstance().ProductBLL.GetHotProducts(6);
            this.ViewBag.hotProducts = hotProducts;
            #endregion

            #region 最新商品
            List<Products> newProducts = BLLFactory.Instance.ProductBLL.GetNewProducts(5);
            this.ViewBag.newProducts = newProducts;
            #endregion

            #region 按分类获取商品
            List<Products> sportProducts = BLLFactory.Instance.ProductBLL.GetProductsByCatalogID("01", 4);
            List<Products> bookProducts = BLLFactory.Instance.ProductBLL.GetProductsByCatalogID("02", 4);
            List<Products> electronicsProducts = BLLFactory.Instance.ProductBLL.GetProductsByCatalogID("03", 4);
            List<Products> musicProducts = BLLFactory.Instance.ProductBLL.GetProductsByCatalogID("04", 4);
            List<Products> otherProducts = BLLFactory.Instance.ProductBLL.GetProductsByCatalogID("05", 4);
            List<Products> lowPriceProducts = BLLFactory.Instance.ProductBLL.GetLowPriceProducts(4);
            this.ViewBag.sportProducts = sportProducts;
            this.ViewBag.bookProducts = bookProducts;
            this.ViewBag.electronicsProducts = electronicsProducts;
            this.ViewBag.musicProducts = musicProducts;
            this.ViewBag.otherProducts = otherProducts;
            this.ViewBag.lowPriceProducts = lowPriceProducts;


            #endregion

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

    }

   
}
