using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class UserAttention
    {
        /// <summary>
        /// 关注ID
        /// </summary>
        public int UserAttentionID { get; set; }
        /// <summary>
        /// 关注商品的用户ID
        /// </summary>
        public Nullable<int> AttrntionUID { get; set; }
        /// <summary>
        /// 关注商品ID
        /// </summary>
        public Nullable<int> AttentionPID { get; set; }
        /// <summary>
        /// 发布商品用户ID
        /// </summary>
        public Nullable<int> ProductUID { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public Nullable<System.DateTime> AttentionTime { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public Nullable<int> DelFalg { get; set; }
    }
}
