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
    public class ProductController : Controller
    {

        /// <summary>
        /// 商品列表页
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public ActionResult ProductList(string catalogID = "01", int pno = 1, int sort = 0)
        {

            //分类集合
            List<Catalogs> catalogList = BLLFactory.Instance.ProductBLL.GetSubCatalogs(catalogID);
            this.ViewBag.catalogList = catalogList;

            //商品集合
            int totalCount;
            int pageSize = 20;
            //推荐、最新、价格从高到低、价格从低到高、关注度(0--4)
            List<Products> productsList = BLLFactory.Instance.ProductBLL.GetProductsByCatalogID(catalogID, sort, pno, pageSize, out totalCount);
            this.ViewBag.productsList = productsList;
            this.ViewBag.totalCount = totalCount;
            this.ViewBag.pageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));//总页数
            this.ViewBag.sort = sort;

            //当前分类名字
            this.ViewBag.catalogName = BLLFactory.Instance.ProductBLL.GetCatalogNameByCatalogID(catalogID);
            this.ViewBag.catalogID = catalogID;
            this.ViewBag.dealCatalogID = catalogID.Substring(0, 2);//处理后

            return View();
        }

        /// <summary>
        /// 商品详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductDetail(int pid)
        {
            Products product = BLLFactory.Instance.ProductBLL.GetProductByPID(pid);
            //获取商品发布人的信息
            Users user = BLLFactory.Instance.UsersBLL.GetUserByUID(product.UID);
            this.ViewBag.user = user;
            #region 浏览记录和商品推荐
            int uid = SystemManager.GetUID(this.Request);
            if (uid != 0)
            {
                BLLFactory.Instance.ProductBLL.AddUserBrowse(uid, product);
            }

            List<UserBrowse> userBrowse = BLLFactory.Instance.ProductBLL.GetUserBrowse(uid, 6);
            this.ViewBag.userBrowse = userBrowse;


            List<Products> likeProducts = BLLFactory.Instance.ProductBLL.MayBeLike(pid, 6);
            this.ViewBag.likeProducts = likeProducts;
            #endregion
            this.ViewBag.catalogID = product.CatalogID.Substring(0, 2);
            this.ViewBag.product = product;
            //多少人关注了该商品
            this.ViewBag.AttentionCount = BLLFactory.Instance.ProductBLL.GetAttentionCount(pid);
            //商品质询
            List<Dialog> dialogList = BLLFactory.Instance.DialogBLL.GetDialogByPID(pid);
            this.ViewBag.dialogList = dialogList;
            return View();
        }

        /// <summary>
        /// 加关注
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddShopCart()
        {

            int uid = SystemManager.GetUID(this.Request);
            if (uid == 0)
            {
                return this.Content("error");
            }
            int pid = Convert.ToInt32(this.Request["pid"]);
            int result = BLLFactory.Instance.UsersBLL.AddUserAttention(uid, pid);
            return this.Content("ok");
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [IsLoginCheck]
        public ActionResult AddCart(FormCollection fm)
        {
            int uid = SystemManager.GetUID(this.Request);
            if (uid == 0)
            {
                return this.Content("error");
            }

            ShopCart shop = new ShopCart()
            {
                BuyTime = DateTime.Now,
                ImgURL = fm["imgURL"],
                PID = Convert.ToInt32(fm["pid"]),
                Price = Convert.ToDecimal(fm["price"]),
                ProductName = fm["productName"],
                PUID = Convert.ToInt32(fm["puid"]),
                UID = uid,
                DelFlag = 0
            };
            int result = BLLFactory.Instance.UsersBLL.AddShopCart(shop);
            if (result > 0)
            {
                return this.Content(result.ToString());
            }
            else
            {
                return this.Content("no");
            }
           
        }

        /// <summary>
        /// 从购物车删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelCart()
        {
            int id=Convert.ToInt32(this.Request["id"]);
            BLLFactory.Instance.UsersBLL.DelShopCart(id);
            return this.Content("ok");

        }

        /// <summary>
        /// 商品搜索
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult SearchProduct(string keyWord, int pno = 1, int sort = 0)
        {
            int totalCount;
            int pageSize = 20;
            List<Products> productsList = BLLFactory.Instance.ProductBLL.GetProductsByKeyword(keyWord, sort, pno, pageSize, out totalCount);
            this.ViewBag.productsList = productsList;//商品集合
            this.ViewBag.totalCount = totalCount;//总条数
            this.ViewBag.pageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));//总页数
            this.ViewBag.keyWord = keyWord;//关键字
            this.ViewBag.sort = sort;//按啥排序,推荐、最新、价格从高到低、价格从低到高、关注度(0--4)
            return View();
        }


    }
}
