using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class Dialog
    {
        /// <summary>
        /// 对话ID
        /// </summary>
        public int DialogID { get; set; }
        /// <summary>
        /// 对话商品ID
        /// </summary>
        public int DialogPID { get; set; }
        /// <summary>
        /// 提问用户ID
        /// </summary>
        public int ConsultUID { get; set; }
        /// <summary>
        /// 提问内容
        /// </summary>
        public string ConsultContent { get; set; }
        /// <summary>
        /// 提问时间
        /// </summary>
        public System.DateTime ConsultTime { get; set; }
        /// <summary>
        /// 回复用户ID
        /// </summary>
        public int ReplyUID { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public Nullable<System.DateTime> ReplyTime { get; set; }
        /// <summary>
        /// 对话是否完成,0--没完成，1--完成
        /// </summary>
        public int DialogOver { get; set; }
        /// <summary>
        /// 是否删除,0--不删除,1--删除
        /// </summary>
        public int DelFlag { get; set; }
    }
}
