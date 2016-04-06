using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolShop.Model;
using SchoolShop.Data.DAL;

namespace SchoolShop.Business.BLL
{
    public class UsersBLL
    {
        public UsersDAL _usersDAL
        {
            get { return DALFactory.Instance.UsersDAL; }
        }

        #region 用户登录

        /// <summary>
        /// 判断用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">用户密码</param>
        /// <returns>该用户</returns>
        public Users UserLogin(string username, string password)
        {
            Users user = _usersDAL.UserLogin(username, password);
            return user;
        }

        /// <summary>
        /// 根据uid获取用户
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns>该用户</returns>
        public Users GetUserByUID(int uid)
        {
            Users user = _usersDAL.GetUserByUID(uid);
            return user;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int RegisterUser(Users user)
        {
            return _usersDAL.RegisterUser(user);
        }

        /// <summary>
        /// 检测用户明是否注册过
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int CheckUserName(string userName)
        {
            return _usersDAL.CheckUserName(userName);
        }

        /// <summary>
        /// 获取用户邮箱
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetUserMail(string userName)
        {
            return _usersDAL.GetUserMail(userName);
        }

        /// <summary>
        /// 根据UID修改密码
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int ChangePasswordByUID(int uid, string passWord)
        {
            return _usersDAL.ChangePasswordByUID(uid, passWord);
        }
        /// <summary>
        /// 验证用户和邮箱
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int CheckUserNameEmail(string userName, string email)
        {
            return _usersDAL.CheckUserNameEmail(userName, email);
        }

        /// <summary>
        /// 根据用户修改密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int ChangePasswordByUserName(string userName, string passWord)
        {
            return _usersDAL.ChangePasswordByUserName(userName, passWord);
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
            return _usersDAL.ChangeUserInfo(user);

        }
        /// <summary>
        /// 保存用户头像
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public int SaveUserHeadImg(int uid, string imgUrl)
        {
            return _usersDAL.SaveUserHeadImg(uid, imgUrl);
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
            return _usersDAL.AddUserAttention(uid, pid);
        }
        /// <summary>
        /// 用户取消关注
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int CancelUserAttention(int aid)
        {
            return _usersDAL.CancelUserAttention(aid);
        }

        /// <summary>
        /// 我关注的商品
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<MyAttentions> GetUserAttention(int uid)
        {
            return _usersDAL.GetUserAttention(uid);
        }


        /// <summary>
        /// 谁关注了我的商品
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<WhoAttention> GetWhoAttenMyProduct(int uid)
        {
            return _usersDAL.GetWhoAttenMyProduct(uid);
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
            return _usersDAL.GetUserPublishProduct(uid);
        }

        /// <summary>
        /// 用根据PID删除发布的商品
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int DelProduct(int pid, int uid)
        {
            return _usersDAL.DelProduct(pid, uid);
        }

        /// <summary>
        /// 获取用户删除的商品
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Products> GetDelPublishProduct(int uid)
        {
            return _usersDAL.GetDelPublishProduct(uid);
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int AddProduct(Products p)
        {
            return _usersDAL.AddProduct(p);
        }
        #endregion

        #region 用户购物车
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        public int AddShopCart(ShopCart shopCart)
        {
            return _usersDAL.AddShopCart(shopCart);
        }


        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="shopCartID"></param>
        /// <returns></returns>
        public int DelShopCart(int shopCartID)
        {
            return _usersDAL.DelShopCart(shopCartID);
        }

        /// <summary>
        /// 获取用户购物车
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShopCart> GetShopCart(int uid)
        {
            return _usersDAL.GetShopCart(uid);
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
            return _usersDAL.AddUserOrder(uid);
        }
        #endregion

    }
}
