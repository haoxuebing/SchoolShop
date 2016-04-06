using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class Catalogs
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public string CatalogID { get; set; }
        /// <summary>
        /// 分类名字
        /// </summary>
        public string CatalogName { get; set; }
        /// <summary>
        /// 分类等级
        /// </summary>
        public int CatalogLevel { get; set; }
        /// <summary>
        /// 分类父ID
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderID { get; set; }
    }
}
