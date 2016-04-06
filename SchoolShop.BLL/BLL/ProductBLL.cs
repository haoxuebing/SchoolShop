using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolShop.Model;
using SchoolShop.Data.DAL;

namespace SchoolShop.Business.BLL
{
    public class ProductBLL
    {
        public ProductDAL _productDAL
        {
            get { return DALFactory.Instance.ProductDAL; }
        }

        #region 获取所有的分类
        /// <summary>
        /// 获取所有的分类
        /// </summary>
        /// <returns></returns>
        public List<Catalogs> GetAllCatalogs()
        {
            return _productDAL.GetAllCatalogs();
        }

        #endregion

        #region 获取商品

        /// <summary>
        /// 获取对应商品
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public Products GetProductByPID(int pid)
        {
            return _productDAL.GetProductByPID(pid);
        }

        /// <summary>
        /// 根据关键字检索商品
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Products> GetProductsByKeyword(string keyword)
        {
            return _productDAL.GetProductsByKeyword(keyword);
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
            return _productDAL.GetProductsByKeyword(keyword, sort, pageIndex, pageSize, out totalCount);
        }

        /// <summary>
        /// 根据分类ID检索商品
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public List<Products> GetProductsByCatalogID(string catalogID)
        {
            return _productDAL.GetProductsByCatalogID(catalogID);
        }

        /// <summary>
        /// 根据分类ID检索商品,获取前n个
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public List<Products> GetProductsByCatalogID(string catalogID, int n)
        {
            return _productDAL.GetProductsByCatalogID(catalogID, n);
        }
        /// <summary>
        /// 根据分类ID检索商品,并分页
        /// </summary>
        /// <param name="catalogID">分类ID</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public List<Products> GetProductsByCatalogID(string catalogID, int pageIndex, int pageSize, out int totalCount)
        {
            return _productDAL.GetProductsByCatalogID(catalogID, pageIndex, pageSize, out totalCount);
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
            return _productDAL.GetProductsByCatalogID(catalogID, sort, pageIndex, pageSize, out totalCount);
        }

        /// <summary>
        /// 获取最新的前n个商品
        /// </summary>
        /// <param name="n">前n个</param>
        /// <returns></returns>
        public List<Products> GetNewProducts(int n)
        {
            return _productDAL.GetNewProducts(n);
        }

        /// <summary>
        /// 获取最热门的前n个商品
        /// </summary>
        /// <param name="n">前n个</param>
        /// <returns></returns>
        public List<Products> GetHotProducts(int n)
        {
            return _productDAL.GetHotProducts(n);
        }

        /// <summary>
        /// 获取特价商品
        /// </summary>
        /// <param name="n">前n个</param>
        /// <returns></returns>
        public List<Products> GetLowPriceProducts(int n = 4)
        {
            return _productDAL.GetLowPriceProducts(n);
        }

        /// <summary>
        /// 根据行业ID获取子行业
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public List<Catalogs> GetSubCatalogs(string catalogID)
        {
            return _productDAL.GetSubCatalogs(catalogID);
        }

        /// <summary>
        /// 根据行业ID获取行业名
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public string GetCatalogNameByCatalogID(string catalogID)
        {
            return _productDAL.GetCatalogNameByCatalogID(catalogID);
        }

         /// <summary>
        /// 获取关注人数
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int GetAttentionCount(int pid)
        {
            return _productDAL.GetAttentionCount(pid);
        }
        #endregion

        #region 浏览记录
        /// <summary>
        /// 添加浏览历史
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="p">浏览商品</param>
        /// <returns></returns>
        public int AddUserBrowse(int uid, Products p)
        {
            return _productDAL.AddUserBrowse(uid, p);
        }

        /// <summary>
        /// 获取用户的前n条浏览历史
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="n">最近的前n条</param>
        /// <returns></returns>
        public List<UserBrowse> GetUserBrowse(int uid, int n)
        {
            return _productDAL.GetUserBrowse(uid, n);
        }
        #endregion

        #region 推荐商品

        /// <summary>
        /// 根据当前商品ID推荐喜欢的分类
        /// </summary>
        /// <param name="pid">商品ID</param>
        /// <param name="n">获取推荐的前n个</param>
        /// <returns></returns>
        public List<Products> MayBeLike(int pid, int n)
        {
            return _productDAL.MayBeLike(pid, n);
        }
        #endregion

    }
}
