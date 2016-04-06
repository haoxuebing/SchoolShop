using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class ReturnResult
    {
        /// <summary>
        /// bool类型数据
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// object类型数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// string类型数据
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string NameUrl { get; set; }
    }
}
