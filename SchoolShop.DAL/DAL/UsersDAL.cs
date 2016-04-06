using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolShop.Model;
using SchoolShop.FrameWork.Utility;
using System.Collections;
using System.Reflection;
namespace SchoolShop.Data.DAL
{
    public class UsersDAL
    {

        #region 用户登录、注册
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">用户密码</param>
        /// <returns>该用户</returns>
        public Users UserLogin(string username, string password)
        {
            Users user = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.FirstOrDefault(u => u.UserName == username && u.Password == password && u.DelFlag == 0);
                if (entity != null)
                {
                    user = CreatUser(user, entity);
                    entity.LastLoginTime = DateTime.Now;
                    content.SaveChanges();
                }
            }
            return user;
        }

        /// <summary>
        /// 根据uid获取用户
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns>该用户</returns>
        public Users GetUserByUID(int uid)
        {
            Users user = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.FirstOrDefault(u => u.UID == uid);
                if (entity != null)
                {
                    user = CreatUser(user, entity);
                }
            }
            return user;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int RegisterUser(Users user)
        {
            int flag = -1;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                EF.SS_Users entity = new EF.SS_Users()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    RegistTime = user.RegistTime,
                    NickName = user.UserName,
                    DelFlag = user.DelFlag
                };
                content.SS_Users.Add(entity);
                flag = content.SaveChanges();
            }
            return flag;

        }

        /// <summary>
        /// 检测用户明是否注册过
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int CheckUserName(string userName)
        {
            int flag = -1;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.Where(u => u.UserName == userName);
                flag = entity.Count();
            }
            return flag;
        }

        /// <summary>
        /// 获取用户邮箱
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetUserMail(string userName)
        {
            string result = "";
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.SingleOrDefault(u => u.UserName == userName);
                if (entity != null)
                {
                    result = entity.Email;
                }
            }
            return result;
        }

        /// <summary>
        /// 验证用户和邮箱
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int CheckUserNameEmail(string userName, string email)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.SingleOrDefault(u => u.UserName == userName && u.Email == email);
                if (entity != null)
                {
                    result = 1;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据用户修改密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int ChangePasswordByUserName(string userName, string passWord)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.SingleOrDefault(u => u.UserName == userName);
                if (entity != null)
                {
                    entity.Password = passWord;
                    result = content.SaveChanges();
                }
            }
            return result;
        }

        /// <summary>
        /// 根据UID修改密码
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int ChangePasswordByUID(int uid, string passWord)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.SingleOrDefault(u => u.UID == uid);
                if (entity != null)
                {
                    entity.Password = passWord;
                    result = content.SaveChanges();
                }
            }
            return result;
        }

        /// <summary>
        /// 实体转化成模型
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private Users CreatUser(Users user, EF.SS_Users entity)
        {
            user = new Users()
            {
                UID = entity.UID,
                UserName = entity.UserName,
                Password = entity.Password,
                NickName = entity.NickName,
                Mobile = entity.Mobile,
                Email = entity.Email,
                Gender = entity.Gender,
                Address = entity.Address,
                LastLoginTime = entity.LastLoginTime,
                Birthday = entity.Birthday,
                RegistTime = entity.RegistTime,
                HeadImage = entity.HeadImage,
                CreditValue = entity.CreditValue,
                note = entity.note,
                IDNumber = entity.IDNumber,
                RealName = entity.RealName,
                QQNumber = entity.QQNumber
            };
            return user;
        }




        #endregion

        #region 用户信息修改
        /// <summary>
        /// 用户修改个人信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int ChangeUserInfo(Users user)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.SingleOrDefault(u => u.UID == user.UID);
                entity.Address = user.Address;
                entity.Birthday = user.Birthday;
                entity.Email = user.Email;
                entity.Gender = user.Gender;
                entity.IDNumber = user.IDNumber;
                entity.Mobile = user.Mobile;
                entity.NickName = user.NickName;
                entity.QQNumber = user.QQNumber;
                entity.RealName = user.RealName;
                result = content.SaveChanges();
            }
            return result;

        }

        /// <summary>
        /// 保存用户头像
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public int SaveUserHeadImg(int uid, string imgUrl)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Users.SingleOrDefault(u => u.UID == uid);
                entity.HeadImage = imgUrl;
                result = content.SaveChanges();
            }
            return result;
        }
        #endregion

        #region 用户关注
        /// <summary>
        /// 用户关注商品
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int AddUserAttention(int uid, int pid)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_UserAttention.SingleOrDefault(e => e.AttentionPID == pid && e.AttrntionUID == uid && e.DelFalg == 0);
                if (entity == null)
                {
                    int productuid = content.SS_Products.SingleOrDefault(p => p.PID == pid).UID;
                    EF.SS_UserAttention u = new EF.SS_UserAttention()
                    {
                        AttentionPID = pid,
                        AttentionTime = DateTime.Now,
                        AttrntionUID = uid,
                        ProductUID = productuid,
                        DelFalg = 0
                    };
                    content.SS_UserAttention.Add(u);
                    result = content.SaveChanges();
                }

            }
            return result;
        }
        /// <summary>
        /// 用户取消关注
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int CancelUserAttention(int aid)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_UserAttention.SingleOrDefault(u => u.UserAttentionID == aid);
                if (entity != null)
                {
                    entity.DelFalg = 1;
                    result = content.SaveChanges();
                }
            }
            return result;
        }
        /// <summary>
        /// 我关注的商品
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<MyAttentions> GetUserAttention(int uid)
        {
            List<MyAttentions> list = new List<MyAttentions>();
            List<EF.View_MyAttentions> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.View_MyAttentions.Where(a => a.AttrntionUID == uid && a.DelFalg == 0).ToList();
            }
            if (entity != null)
            {
                MyAttentions ma = null;
                foreach (var item in entity)
                {
                    ma = new MyAttentions()
                    {
                        AttentionPID = item.AttentionPID,
                        AttentionTime = item.AttentionTime,
                        AttrntionUID = item.AttrntionUID,
                        Describe = item.Describe,
                        ImgURL = item.ImgURL,
                        PhoneNumber = item.PhoneNumber,
                        ProductName = item.ProductName,
                        ProductPrice = item.ProductPrice,
                        ProductUID = item.ProductUID,
                        Gender = item.Gender,
                        NickName = item.NickName,
                        RealName = item.RealName,
                        UserAttentionID = item.UserAttentionID
                    };
                    list.Add(ma);
                }
            }
            return list;
        }

        /// <summary>
        /// 谁关注了我的商品
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<WhoAttention> GetWhoAttenMyProduct(int uid)
        {
            List<WhoAttention> list = new List<WhoAttention>();
            List<EF.View_WhoAttention> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.View_WhoAttention.Where(w => w.ProductUID == uid && w.DelFalg == 0).ToList();
            }
            if (entity != null)
            {
                WhoAttention w = null;
                foreach (var item in entity)
                {
                    w = new WhoAttention()
                    {
                        Address = item.Address,
                        AttentionPID = item.AttentionPID,
                        AttentionTime = item.AttentionTime,
                        AttrntionUID = item.AttrntionUID,
                        Birthday = item.Birthday,
                        Email = item.Email,
                        Gender = item.Gender,
                        HeadImage = item.HeadImage,
                        ImgURL = item.ImgURL,
                        LastLoginTime = item.LastLoginTime,
                        Mobile = item.Mobile,
                        NickName = item.NickName,
                        ProductName = item.ProductName,
                        ProductPrice = item.ProductPrice,
                        QQNumber = item.QQNumber,
                        RealName = item.RealName
                    };
                    list.Add(w);
                }
            }
            return list;
        }

        #endregion

        #region 用户发布的商品
        /// <summary>
        /// 获取用户发布的商品
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Products> GetUserPublishProduct(int uid)
        {
            List<Products> list = new List<Products>();
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(p => p.UID == uid && p.DelFlag == 0).OrderByDescending(p => p.SaleTime).ToList();
            }
            if (entity != null)
            {
                Products pro = null;
                foreach (var item in entity)
                {
                    pro = new Products()
                    {
                        Describe = item.Describe,
                        ImgURL = item.ImgURL,
                        ProductName = item.ProductName,
                        PID = item.PID,
                        ProductPrice = item.ProductPrice,
                        PhoneNumber = item.PhoneNumber,
                        SaleTime = item.SaleTime,
                        ViewsCount = item.ViewsCount,
                        Remark = item.Remark
                    };
                    list.Add(pro);
                }
            }
            return list;

        }
        /// <summary>
        /// 获取用户删除的商品
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Products> GetDelPublishProduct(int uid)
        {
            List<Products> list = new List<Products>();
            List<EF.SS_Products> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Products.Where(p => p.UID == uid && p.DelFlag == 1).OrderByDescending(p => p.SaleTime).ToList();
            }
            if (entity != null)
            {
                Products pro = null;
                foreach (var item in entity)
                {
                    pro = new Products()
                    {
                        Describe = item.Describe,
                        ImgURL = item.ImgURL,
                        ProductName = item.ProductName,
                        PID = item.PID,
                        ProductPrice = item.ProductPrice,
                        PhoneNumber = item.PhoneNumber,
                        SaleTime = item.SaleTime,
                        ViewsCount = item.ViewsCount,
                        Remark = item.Remark
                    };
                    list.Add(pro);
                }
            }
            return list;
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int AddProduct(Products p)
        {
            int result = 0;
            EF.SS_Products entity = new EF.SS_Products()
            {
                DelFlag = 0,
                Describe = p.Describe,
                ImgURL = p.ImgURL,
                PhoneNumber = p.PhoneNumber,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                PrudouctDetail = p.PrudouctDetail,
                SaleTime = DateTime.Now,
                UID = p.UID,
                ViewsCount = 0,
                AskCount = 0,
                CatalogID = p.CatalogID,
                Remark = p.Remark

            };
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                content.SS_Products.Add(entity);
                result = content.SaveChanges();
            }
            return result;
        }

        #endregion

        #region 用户删除商品
        /// <summary>
        /// 用根据PID删除商品
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int DelProduct(int pid, int uid)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Products.SingleOrDefault(p => p.PID == pid && p.UID == uid);
                if (entity != null)
                {
                    entity.DelFlag = 1;
                    var entity2 = content.SS_UserBrowse.Where(b => b.PID == pid);
                    foreach (var item in entity2)
                    {
                        item.DelFlag = 1;
                    }
                    result = content.SaveChanges();
                }
            }
            return result;
        }


        #endregion

        #region 用户购物车
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        public int AddShopCart(ShopCart shopCart)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_ShopCart.Where(s => s.PID == shopCart.PID && s.UID == shopCart.UID && s.DelFlag == 0).ToList().Count;
                if (entity == 0)
                {
                    EF.SS_ShopCart sc = new EF.SS_ShopCart()
                    {
                        BuyTime = DateTime.Now,
                        DelFlag = 0,
                        PID = shopCart.PID,
                        UID = shopCart.UID,
                        Price = shopCart.Price,
                        PUID = shopCart.PUID
                    };
                    content.SS_ShopCart.Add(sc);
                    content.SaveChanges();
                    result = content.SS_ShopCart.SingleOrDefault(s => s.PID == shopCart.PID && s.UID == shopCart.UID && s.DelFlag == 0).ShopCartID;
                }
            }
            return result;
        }
        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="shopCartID"></param>
        /// <returns></returns>
        public int DelShopCart(int shopCartID)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_ShopCart.SingleOrDefault(s => s.ShopCartID == shopCartID);
                entity.DelFlag = 1;
                result = content.SaveChanges();
            }
            return result;

        }
        /// <summary>
        /// 获取用户购物车
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShopCart> GetShopCart(int uid)
        {
            List<ShopCart> list = new List<ShopCart>();
            List<EF.View_ShopCartView> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.View_ShopCartView.Where(s => s.UID == uid && s.DelFlag == 0).ToList();

            }
            if (entity != null)
            {
                ShopCart s = null;
                foreach (var item in entity)
                {
                    s = new ShopCart()
                    {
                        ShopCartID = item.ShopCartID,
                        BuyTime = item.BuyTime,
                        PID = item.PID,
                        PUID = item.PUID,
                        UID = item.UID,
                        Price = item.Price,
                        ImgURL = item.ImgURL,
                        ProductName = item.ProductName

                    };
                    list.Add(s);
                }
            }
            return list;
        }

        #endregion

        #region 用户订单
        /// <summary>
        /// 用户生成订单
        /// </summary>
        /// <param name="orderlist"></param>
        /// <returns></returns>
        public int AddUserOrder(int uid)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_ShopCart.Where(s => s.UID == uid && s.DelFlag == 0).ToList();
                foreach (var item in entity)
                {
                    item.DelFlag = 1;
                    EF.SS_UserOrder uo = new EF.SS_UserOrder()
                    {
                        UID = uid,
                        PUID = item.PUID,
                        PID = item.PID,
                        OrderTime = DateTime.Now,
                        ISPay = 0,
                        DelFlag = 0
                    };
                    content.SS_UserOrder.Add(uo);
                }
                result = content.SaveChanges();
            }
            return result;
        }

        #endregion
    }
}
