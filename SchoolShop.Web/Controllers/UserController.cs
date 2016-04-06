using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using SchoolShop.Model;
using SchoolShop.Business.BLL;
using SchoolShop.Web.Public;
using SchoolShop.FrameWork.Utility;
using System.IO;


namespace SchoolShop.Web.Controllers
{
    public class UserController : Controller
    {
        #region 用户登录注册
        #region 用户请求登录页
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = "")
        {
            returnUrl = Server.UrlDecode(returnUrl) == "/User/Login" ? "" : returnUrl;
            this.ViewBag.returnUrl = returnUrl;
            return View();
        }
        #endregion

        #region 用户密码判断
        /// <summary>
        /// 用户密码判断
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckLogin()
        {
            ReturnResult result = new ReturnResult();
            string userName = this.Request["userName"].ToString();
            string passWord = this.Request["passWord"].ToString();
            string returnUrl = this.Request["returnurl"].Replace("-", "&");
            bool saveState = Convert.ToBoolean(this.Request["saveState"]);
            passWord = Public.EDncrypt.MD5Encrypt(passWord + "shcool");//用school加密
            Users user = BLLFactory.Instance.UsersBLL.UserLogin(userName, passWord);
            if (user != null)
            {
                result.Result = true;
                result.Message = returnUrl;
                #region 保存用户Cookie
                HttpCookie cookie = new HttpCookie("UID", user.UID.ToString());

                HttpCookie cookieUserName = new HttpCookie("userName", userName);
                HttpCookie cookiePassWord = new HttpCookie("passWord", passWord);
                if (saveState)
                {
                    cookie.Expires = DateTime.Now.AddDays(7);
                    cookieUserName.Expires = DateTime.Now.AddDays(7);
                    cookiePassWord.Expires = DateTime.Now.AddDays(7);
                }
                this.Response.Cookies.Add(cookie);
                this.Response.Cookies.Add(cookieUserName);
                this.Response.Cookies.Add(cookiePassWord);
                #endregion
            }
            return this.Json(result);


        }
        #endregion

        #region 注销登录
        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        public ActionResult CancelLogin()
        {
            HttpCookie hc = this.Request.Cookies["UID"];
            if (hc != null)
            {
                hc.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Set(hc);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region 用户注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        #endregion

        #region 用户提交注册
        /// <summary>
        /// 用户提交注册
        /// </summary>
        /// <returns></returns>
        public ActionResult SubRegister(FormCollection fm)
        {
            string result = string.Empty;
            string codetxt = this.Session["code"] as string;
            string codeStr = fm["codeStr"];
            if (codetxt.ToUpper() != codeStr.ToUpper())
            {
                result = "codeError";
                return this.Content(result);
            }
            else
            {
                Users user = new Users();
                user.UserName = fm["userName"].ToString();
                user.Password = Public.EDncrypt.MD5Encrypt(fm["passWord"].ToString() + "shcool");
                user.RegistTime = DateTime.Now;
                user.DelFlag = 0;
                result = BLLFactory.Instance.UsersBLL.RegisterUser(user) > 0 ? "ok" : "error";
            }

            return this.Content(result);
        }
        #endregion

        #region 检测用户名是否被注册
        /// <summary>
        /// 检测用户名是否被注册
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ActionResult CheckUserName(string userName)
        {
            string reault = BLLFactory.Instance.UsersBLL.CheckUserName(userName) > 0 ? "no" : "yes";
            return Content(reault);
        }
        #endregion
        #endregion

        #region 用户中心
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult UserInfo()
        {
            int uid = SystemManager.GetUID(this.Request);
            Users userInfo = new Users();
            userInfo = BLLFactory.Instance.UsersBLL.GetUserByUID(uid);
            userInfo.Birthday = userInfo.Birthday ?? DateTime.Now;
            //this.ViewBag.userInfo = userInfo;
            return View(userInfo);
        }

        /// <summary>
        /// 用户提交保存信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserSubmit(FormCollection fm)
        {
            Users user = new Users();
            user.UID = Convert.ToInt32(fm["userid"]);
            user.RealName = fm["rname"].ToString();
            user.QQNumber = fm["qqnumber"].ToString();
            user.NickName = fm["nickname"].ToString();
            user.Mobile = fm["mobile"].ToString();
            user.IDNumber = fm["idNumber"].ToString();
            string gender = fm["genderValue"].ToString() == "" ? "2" : fm["genderValue"].ToString();
            user.Gender = Convert.ToInt32(gender);
            user.Email = fm["email"].ToString();
            user.Birthday = Convert.ToDateTime(fm["birthDay"]);
            user.Address = fm["Address"].ToString();
            BLLFactory.Instance.UsersBLL.ChangeUserInfo(user);
            return this.Content("ok");
        }



        #endregion

        #region 上传照片
        /// <summary>
        /// 上传照片,HeadPic用户头像,ProductPic产品照片
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpLoadPicture(string action)
        {
            int UID = SystemManager.GetUID(this.Request);
            ReturnResult result = new ReturnResult() { Result = true };
            if (this.Request.Files.Count > 0)
            {
                var file = this.Request.Files[0];
                List<String> lastNameAlow = new List<String>() { "gif", "jpeg", "png", "jpg" };
                String lastName = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                if (lastNameAlow.Exists(a => a == lastName.Trim().ToLower()))
                {
                    byte[] bytes = new byte[file.InputStream.Length];
                    file.InputStream.Read(bytes, 0, bytes.Length);
                    String s = Convert.ToBase64String(bytes);
                    result.Data = lastName + "|" + s;
                    string name = "";
                    string uPath = @"/UploadFile/Users" + @"/" + UID;
                    switch (action)
                    {
                        case "HeadPic":
                            name = "1." + lastName;
                            result.Result = BLLFactory.Instance.UsersBLL.SaveUserHeadImg(UID, uPath + "/" + name) > 0 ? true : false;
                            break;
                        case "ProductPic":
                            name = file.FileName;
                            break;
                        default: break;
                    }

                    #region 保存在MVC代码

                    uPath = System.Web.HttpContext.Current.Server.MapPath(uPath);
                    if (!Directory.Exists(uPath))
                    {
                        Directory.CreateDirectory(uPath);
                    }
                    file.SaveAs(uPath + "/" + name);
                    #endregion
                    if (action == "ProductPic")
                    {
                        result.NameUrl = @"/UploadFile/Users" + @"/" + UID + "/" + name;
                    }
                    result.Result = true;//flag;
                }
            }
            return this.Json(result);
        }
        #endregion

        #region 用户关注

        /// <summary>
        /// 用户关注的商品
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult UserAttention()
        {
            int uid = SystemManager.GetUID(this.Request);
            List<MyAttentions> list = BLLFactory.Instance.UsersBLL.GetUserAttention(uid);
            this.ViewBag.list = list;
            return View();
        }

        /// <summary>
        /// 用户取消关注
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CancelAttention()
        {
            int aid = Convert.ToInt32(this.Request["aid"]);
            int result = BLLFactory.Instance.UsersBLL.CancelUserAttention(aid);
            if (result > 0)
            {
                return this.Content("ok");
            }
            else
            {
                return this.Content("error");
            }

        }

        /// <summary>
        /// 谁关注了我的商品
        /// </summary>
        /// <returns></returns>
        public ActionResult WhoAttentionMe()
        {
            int uid = SystemManager.GetUID(this.Request);
            List<WhoAttention> list = BLLFactory.Instance.UsersBLL.GetWhoAttenMyProduct(uid);
            this.ViewBag.list = list;
            return View();
        }


        #endregion

        #region 发布商品

        /// <summary>
        /// 我要发布商品
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult PublishProduct()
        {
            Users user = SystemManager.GetCurrentUser(this.Request);
            List<Catalogs> listCatalogs = BLLFactory.Instance.ProductBLL.GetAllCatalogs();
            this.ViewBag.listCatalogs = listCatalogs;
            return View(user);
        }

        /// <summary>
        /// 我发布的商品
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult MyPublish()
        {
            int uid = SystemManager.GetUID(this.Request);
            List<Products> list = BLLFactory.Instance.UsersBLL.GetUserPublishProduct(uid);
            this.ViewBag.list = list;
            return View();
        }

        /// <summary>
        /// 用户删除发布的商品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelProduct()
        {
            int uid = SystemManager.GetUID(this.Request);
            int pid = Convert.ToInt32(this.Request["pid"]);
            int result = BLLFactory.Instance.UsersBLL.DelProduct(pid, uid);
            if (result > 0)
            {
                return this.Content("ok");
            }
            else
            {
                return this.Content("error");
            }

        }

        /// <summary>
        /// 获取用户删除的商品
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult UserDelProduct()
        {
            int uid = SystemManager.GetUID(this.Request);
            List<Products> list = BLLFactory.Instance.UsersBLL.GetDelPublishProduct(uid);
            this.ViewBag.list = list;
            return View();
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveProductInfo()
        {
            try
            {
                Products p = new Products();
                p.UID = SystemManager.GetUID(this.Request);
                p.CatalogID = this.Request.Form["selminor"];
                p.Describe = this.Request.Form["productName"];
                p.ImgURL = this.Request.Form["picUrl"];
                p.PhoneNumber = this.Request.Form["phone"];
                p.ProductName = this.Request.Form["productName"];
                p.ProductPrice = Convert.ToDecimal(this.Request.Form["productPrice"]);
                p.Remark = this.Request.Form["remark"].ToString();
                p.PrudouctDetail = this.Request.Unvalidated["k_textarea"];
                int result = 0;
                result = BLLFactory.Instance.UsersBLL.AddProduct(p);
                return RedirectToAction("MyPublish");
            }
            catch
            {
                return RedirectToAction("PublishProduct");
            }

        }
        #endregion

        #region 修改商品

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <returns></returns>
        [IsLoginCheck]
        public ActionResult ChangeProduct(int pid)
        {
            return View();
        }

        #endregion

        #region 找回密码
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// 检测邮箱
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckEmail()
        {
            string mail = this.Request["mail"];
            string userName = this.Request["userName"];
            string getEmail = BLLFactory.Instance.UsersBLL.GetUserMail(userName);
            if (mail == getEmail)
            {
                return this.Content("ok");
            }
            else
            {
                return this.Content("error");
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ForgotPassword_Change()
        {
            string codeStr = this.Request["codeStr"];
            string code = this.Session["code"].ToString();
            if (code.ToLower() == codeStr.ToLower())
            {
                string userName = this.Request["userName"];
                string email = this.Request["email"];
                int result = BLLFactory.Instance.UsersBLL.CheckUserNameEmail(userName, email);
                if (result > 0)
                {
                    this.ViewBag.userName = userName;
                    return View();
                }
            }

            return RedirectToAction("ForgotPassword");
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword()
        {
            string userName = this.Request["userName"];
            string password = this.Request["password1"];
            string password2 = Public.EDncrypt.MD5Encrypt(password + "shcool");
            int result = BLLFactory.Instance.UsersBLL.ChangePasswordByUserName(userName, password2);
            if (result > 0)
            {
                return this.Redirect("Login");
            }
            else
            {
                return this.Content("修改失败");
            }

        }
        #endregion

        #region 消息中心

        [IsLoginCheck]
        public ActionResult UserMessage()
        {
            int uid = SystemManager.GetUID(this.Request);
            List<Dialog> consultList = BLLFactory.Instance.DialogBLL.GetUserConsultByUID(uid);
            List<Dialog> replyList = BLLFactory.Instance.DialogBLL.GetUserReplyByUID(uid);
            this.ViewBag.consultList = consultList;
            this.ViewBag.replyList = replyList;
            return View();
        }

        /// <summary>
        /// 用户添加回复
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [IsLoginCheck]
        public ActionResult AddReply()
        {
            int dialogid = Convert.ToInt32(this.Request["dialogid"]);
            string replyContent = this.Request["replyContent"];
            int result = BLLFactory.Instance.DialogBLL.AddReply(dialogid, replyContent);
            if (result>0)
            {
               return this.Content("ok");
            }
            else
            {
                return this.Content("error");
            }


        }

        #endregion

        #region 用户订单
        [IsLoginCheck]
        public ActionResult CreateOrder()
        {
            int uid = SystemManager.GetUID(this.Request);
            int result= BLLFactory.Instance.UsersBLL.AddUserOrder(uid);
            return this.Content("ok");
        }
        #endregion

    }
}

