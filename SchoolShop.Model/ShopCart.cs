using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class ShopCart
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public int PUID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }
       /// <summary>
       /// 购买时间
       /// </summary>
        public System.DateTime BuyTime { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public Nullable<int> DelFlag { get; set; }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ShopCartID { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName { get; set; }
       /// <summary>
       /// 商品图片
       /// </summary>
        public string ImgURL { get; set; }
    }
}
