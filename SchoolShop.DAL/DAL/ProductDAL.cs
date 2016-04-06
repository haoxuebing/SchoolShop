using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolShop.Model;

namespace SchoolShop.Data.DAL
{
    public class ProductDAL
    {

        #region 获取所有分类
        /// <summary>
        /// 获取所有的分类
        /// </summary>
        /// <returns></returns>
        public List<Catalogs> GetAllCatalogs()
        {
            List<Catalogs> listCatalogs = new List<Catalogs>();
            Catalogs catalogs = null;
            List<EF.SS_Catalogs> entity = new List<EF.SS_Catalogs>();
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Catalogs.ToList();
            }
            if (entity != null)
            {
                foreach (var item in entity)
                {
                    catalogs = new Catalogs()
                    {
                        CatalogID = item.CatalogID,
                        CatalogLevel = item.CatalogLevel,
                        CatalogName = item.CatalogName,
                        OrderID = item.OrderID,
                        ParentID = item.ParentID,
                        Remark = item.Remark
                    };
                    listCatalogs.Add(catalogs);
                }
            }
            return listCatalogs;
        }


        #endregion

        #region 根据商品Id获取对应商品
        /// <summary>
        /// 获取对应商品
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public Products GetProductByPID(int pid)
        {
            Products pro = null;
            EF.SS_Products entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(p => p.PID == pid).SingleOrDefault();
                entity.ViewsCount++;
                content.SaveChanges();
            }
            if (entity != null)
            {
                pro = new Products()
                {
                    CatalogID = entity.CatalogID,
                    Describe = entity.Describe,
                    ImgURL = entity.ImgURL,
                    PhoneNumber = entity.PhoneNumber,
                    PID = entity.PID,
                    ProductName = entity.ProductName,
                    ProductPrice = entity.ProductPrice,
                    Remark = entity.Remark,
                    UID = entity.UID,
                    ViewsCount = entity.ViewsCount,
                    SaleTime = entity.SaleTime,
                    PrudouctDetail = entity.PrudouctDetail
                };
            }

            return pro;
        }

        #endregion

        #region 根据关键字检索商品
        /// <summary>
        /// 根据关键字检索商品
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Products> GetProductsByKeyword(string keyword)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).ToList();
            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }

        /// <summary>
        /// 根据关键字检索商品
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="sort">推荐、最新、价格从高到低、价格从低到高、关注度</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        public List<Products> GetProductsByKeyword(string keyword, int sort, int pageIndex, int pageSize, out int totalCount)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                totalCount = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).Count();
                switch (sort)
                {
                    case 0:
                        //推荐
                        entity = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).OrderByDescending(s => s.ViewsCount).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 1:
                        //最新
                        entity = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).OrderByDescending(s => s.SaleTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 2:
                        //价格从高到低
                        entity = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).OrderByDescending(s => s.ProductPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 3:
                        //价格从低到高
                        entity = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).OrderBy(s => s.ProductPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 4:
                        //关注度
                        entity = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).OrderByDescending(s => s.ViewsCount).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        entity = content.SS_Products.Where(s => s.Remark.Contains(keyword) && s.DelFlag == 0).OrderByDescending(s => s.ViewsCount).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                }

            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }

        #endregion

        #region 根据分类ID检索商品
        /// <summary>
        /// 根据分类ID检索商品
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public List<Products> GetProductsByCatalogID(string catalogID)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).ToList();
            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }
        /// <summary>
        /// 根据分类ID检索商品,获取前n个
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public List<Products> GetProductsByCatalogID(string catalogID, int n)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).Take(n).ToList();
            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }

        /// <summary>
        /// 根据分类ID检索商品,并分页
        /// </summary>
        /// <param name="catalogID">分类ID</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        public List<Products> GetProductsByCatalogID(string catalogID, int pageIndex, int pageSize, out int totalCount)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                totalCount = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).Count();
                entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).OrderByDescending(s => s.SaleTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }

        /// <summary>
        /// 根据分类ID检索商品,并分页
        /// </summary>
        /// <param name="catalogID">分类ID</param>
        /// <param name="sort">推荐、最新、价格从高到低、价格从低到高、关注度</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        public List<Products> GetProductsByCatalogID(string catalogID, int sort, int pageIndex, int pageSize, out int totalCount)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                totalCount = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).Count();
                switch (sort)
                {
                    case 0:
                        //推荐
                        entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).OrderByDescending(s => s.ViewsCount).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 1:
                        //最新
                        entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).OrderByDescending(s => s.SaleTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 2:
                        //价格从高到低
                        entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).OrderByDescending(s => s.ProductPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 3:
                        //价格从低到高
                        entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).OrderBy(s => s.ProductPrice).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    case 4:
                        //关注度
                        entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).OrderByDescending(s => s.ViewsCount).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        entity = content.SS_Products.Where(s => s.CatalogID.StartsWith(catalogID) && s.DelFlag == 0).OrderByDescending(s => s.ViewsCount).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        break;
                }

            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }
        #endregion

        #region 获取最新的前n个商品
        /// <summary>
        /// 获取最新的前n个商品
        /// </summary>
        /// <param name="n">前n个</param>
        /// <returns></returns>
        public List<Products> GetNewProducts(int n = 5)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(s => s.DelFlag == 0).OrderByDescending(s => s.SaleTime).Take(n).ToList();
            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }


        #endregion

        #region 获取最热门的前n个商品
        /// <summary>
        /// 获取最热门的前n个商品
        /// </summary>
        /// <param name="n">前n个</param>
        /// <returns></returns>
        public List<Products> GetHotProducts(int n = 6)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(s => s.DelFlag == 0).OrderByDescending(s => s.ViewsCount).Take(n).ToList();
            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }


        #endregion

        #region 特价商品

        /// <summary>
        /// 获取特价商品
        /// </summary>
        /// <param name="n">前n个</param>
        /// <returns></returns>
        public List<Products> GetLowPriceProducts(int n = 4)
        {
            List<Products> list = null;
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(s => s.DelFlag == 0).OrderBy(s => s.ProductPrice).Take(n).ToList();
            }
            if (entity != null)
            {
                list = GetProductList(entity);
            }
            return list;
        }


        #endregion

        #region 根据行业ID获取子行业
        /// <summary>
        /// 根据行业ID获取子行业
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public List<Catalogs> GetSubCatalogs(string catalogID)
        {
            List<Catalogs> list = new List<Catalogs>();
            Catalogs catalog = null;
            List<EF.SS_Catalogs> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Catalogs.Where(c => c.ParentID == catalogID).ToList();
            }
            if (entity != null)
            {
                foreach (var item in entity)
                {
                    catalog = new Catalogs()
                    {
                        CatalogID = item.CatalogID,
                        CatalogLevel = item.CatalogLevel,
                        CatalogName = item.CatalogName,
                        OrderID = item.OrderID,
                        ParentID = item.ParentID,
                        Remark = item.Remark
                    };
                    list.Add(catalog);
                }
            }
            return list;
        }


        #endregion

        #region 根据行业ID获取行业名

        /// <summary>
        /// 根据行业ID获取行业名
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public string GetCatalogNameByCatalogID(string catalogID)
        {
            string catalogName = "";
            EF.SS_Catalogs entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Catalogs.SingleOrDefault(c => c.CatalogID == catalogID);
                if (entity != null)
                {
                    catalogName = entity.CatalogName;
                }
            }
            return catalogName;
        }

        #endregion

        #region 浏览历史
        /// <summary>
        /// 添加浏览历史
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="p">浏览商品</param>
        /// <returns></returns>
        public int AddUserBrowse(int uid, Products p)
        {
            int result = 0;
            EF.SS_UserBrowse entity = new EF.SS_UserBrowse()
            {
                BDateTime = DateTime.Now,
                CatalogID = p.CatalogID,
                DelFlag = 0,
                ImgUrl = p.ImgURL,
                PID = p.PID,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                UID = uid
            };
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                if (content.SS_UserBrowse.Where(u => u.UID == uid && u.PID == p.PID).Count() > 0 ? false : true)
                {
                    content.SS_UserBrowse.Add(entity);
                    result = content.SaveChanges();
                }
            }
            return result;
        }
        /// <summary>
        /// 获取用户的前n条浏览历史
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="n">最近的前n条</param>
        /// <returns></returns>
        public List<UserBrowse> GetUserBrowse(int uid, int n)
        {
            List<UserBrowse> list = new List<UserBrowse>();
            UserBrowse ub = null;
            List<EF.SS_UserBrowse> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_UserBrowse.Where(u => u.UID == uid && u.DelFlag == 0).OrderByDescending(u => u.BDateTime).Take(n).ToList();
            }
            if (entity != null)
            {
                foreach (var item in entity)
                {
                    ub = new UserBrowse()
                    {
                        BDateTime = item.BDateTime,
                        ProductName = item.ProductName,
                        ImgUrl = item.ImgUrl,
                        PID = item.PID,
                        ProductPrice = item.ProductPrice,
                        CatalogID = item.CatalogID,
                        BroeseID = item.BroeseID,
                        UID = item.UID,
                        DelFlag = item.DelFlag
                    };
                    list.Add(ub);
                }
            }
            return list;
        }

        #endregion

        #region 猜你喜欢
        /// <summary>
        /// 根据当前商品ID推荐喜欢的分类
        /// </summary>
        /// <param name="pid">商品ID</param>
        /// <param name="n">获取推荐的前n个</param>
        /// <returns></returns>
        public List<Products> MayBeLike(int pid, int n)
        {
            List<Products> list = new List<Products>();
            string catalogID = "0101";
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                catalogID = content.SS_Products.SingleOrDefault(p => p.PID == pid && p.DelFlag == 0).CatalogID;
            }
            list = GetProductsByCatalogID(catalogID, n);
            return list;
        }

        #endregion

        #region 获取关注人数
        /// <summary>
        /// 获取关注人数
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int GetAttentionCount(int pid)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                result = content.SS_UserAttention.Count(u => u.AttentionPID == pid);
            }
            return result;
        }

        #endregion

        /// <summary>
        /// 实体集合转对象集合
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static List<Products> GetProductList(List<EF.SS_Products> entity)
        {
            List<Products> list = new List<Products>();
            Products pro = null;
            foreach (var item in entity)
            {
                pro = new Products()
                {
                    CatalogID = item.CatalogID,
                    Describe = item.Describe,
                    ImgURL = item.ImgURL,
                    PhoneNumber = item.PhoneNumber,
                    PID = item.PID,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice,
                    Remark = item.Remark,
                    UID = item.UID,
                    ViewsCount = item.ViewsCount,
                    SaleTime = item.SaleTime
                };
                list.Add(pro);
            }
            return list;
        }

    }
}
