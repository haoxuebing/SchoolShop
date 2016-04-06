using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class Products
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 发布该商品的用户ID
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 商品所属的分类ID
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 商品名字
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal ProductPrice { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ImgURL { get; set; }
        /// <summary>
        /// 商品浏览量
        /// </summary>
        public Nullable<int> ViewsCount { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 上架时间
        /// </summary>
        public Nullable<System.DateTime> SaleTime { get; set; }
        /// <summary>
        /// 产品详细介绍
        /// </summary>
        public string PrudouctDetail { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public Nullable<int> DelFlag { get; set; }
    }
}
