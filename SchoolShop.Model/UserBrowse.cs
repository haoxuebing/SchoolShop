using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class UserBrowse
    {
        /// <summary>
        /// 浏览ID
        /// </summary>
        public int BroeseID { get; set; }
        /// <summary>
        /// 浏览用户ID
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 浏览商品ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public Nullable<decimal> ProductPrice { get; set; }
        /// <summary>
        /// 商品所在分类
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 浏览时间
        /// </summary>
        public System.DateTime BDateTime { get; set; }
        /// <summary>
        /// 是否删除，0不删，1删
        /// </summary>
        public Nullable<int> DelFlag { get; set; }
    }
}
