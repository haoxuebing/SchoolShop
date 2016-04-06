using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 用户生日
        /// </summary>
        public Nullable<System.DateTime> Birthday { get; set; }
        /// <summary>
        /// 用户注册时间
        /// </summary>
        public System.DateTime RegistTime { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Nullable<int> Gender { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImage { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public Nullable<int> DelFlag { get; set; }
        /// <summary>
        /// 信誉值
        /// </summary>
        public Nullable<int> CreditValue { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNumber { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        public string QQNumber { get; set; }
    }
}
