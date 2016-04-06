using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    public class MyAttentions
    {
        public Nullable<int> AttentionPID { get; set; }
        public Nullable<int> ProductUID { get; set; }
        public Nullable<System.DateTime> AttentionTime { get; set; }
        public Nullable<int> DelFalg { get; set; }
        public int UserAttentionID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> ProductPrice { get; set; }
        public string ImgURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Describe { get; set; }
        public Nullable<int> AttrntionUID { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public Nullable<int> Gender { get; set; }
    }
}
