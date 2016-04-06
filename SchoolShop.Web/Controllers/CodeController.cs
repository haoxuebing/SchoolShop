using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SchoolShop.Model;
using System.Drawing.Imaging;

namespace SchoolShop.Web.Controllers
{
    public class CodeController : Controller
    {
        private const string CODE = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";//验证码字符池
        private const int COUNT = 4;//验证码字符个数
        private const int WIDTH = 65;//图片宽
        private const int HEIGHT = 26;//图片高

        // 产生验证码
        private string GetCode()
        {
            Random r = new Random();
            int length = CODE.Length;
            StringBuilder sCode = new StringBuilder();
            for (int i = 0; i < COUNT; i++)
            {
                int index = r.Next(0, length);
                sCode.Append(CODE[index]);
            }
            return sCode.ToString();
        }

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <returns>图片文件</returns>
        public ActionResult Code()
        {
            //画背景图
            Bitmap bmp = new Bitmap(WIDTH, HEIGHT);//创建位图(宽，高)
            Graphics g = Graphics.FromImage(bmp);//创建画布
            g.FillRectangle(Brushes.LightGray, 0, 0, WIDTH, HEIGHT);//为画布填充底色(颜色，起始位置，终止位置)

            //画验证码
            string code = this.GetCode();//取出验证码
            this.Session.Add("code", code);//将当前验证码存入Session
            Font f = new Font("微软雅黑", 12, FontStyle.Italic);//自定义文本格式(字体，字号，字形)
            g.DrawString(code, f, Brushes.Black, 0, 0);//在画布上写入文本(内容，格式，颜色，起始位置)

            //画干扰点或线
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                Color color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));//随机颜色
                Pen pen = new Pen(color);//创建线笔(颜色)

                int x = r.Next(0, WIDTH);
                int y = r.Next(0, HEIGHT);
                int xDir = r.Next(3);
                int yDir = r.Next(3);
                g.DrawLine(pen, x, y, x + xDir, y + yDir);//在画布上画短线(线笔，起始位置，终止位置)
            }
            ReturnResult result = new ReturnResult() { Result = true };
            //向客户端输出
            using (MemoryStream mStream = new MemoryStream())//创建内存流对象
            {
                bmp.Save(mStream, ImageFormat.Jpeg);//保存位图至内存流(内存流，格式)
                byte[] data = mStream.ToArray();//将内存流转换成字节数组
                return this.File(data, "application/image");//向客户端输出文件(输出内容，内容类型)
            }
        }
    }
}
