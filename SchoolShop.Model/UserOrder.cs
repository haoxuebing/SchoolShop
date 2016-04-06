using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class UserOrder
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 发布商品人ID
        /// </summary>
        public int PUID { get; set; }
        /// <summary>
        /// 是否付款
        /// </summary>
        public Nullable<int> ISPay { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public Nullable<System.DateTime> OrderTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<int> DelFlag { get; set; }
        /// <summary>
        /// 商品名
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
        /// 联系电话
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
