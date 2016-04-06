using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolShop.Model;
using SchoolShop.Data.DAL;

namespace SchoolShop.Business.BLL
{
    public class DialogBLL
    {
        public DialogDAL _dialog
        {
            get { return DALFactory.Instance.DialogDAL; }
        }


        #region 根据PID获取对话
        /// <summary>
        /// 根据PID获取对话
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<Dialog> GetDialogByPID(int pid)
        {
            return _dialog.GetDialogByPID(pid);
        }

        /// <summary>
        /// 用户提出问题
        /// </summary>
        /// <param name="dialogPID">PID</param>
        /// <param name="consultUID">提问用户ID</param>
        /// <param name="consultContent">提问用户内容</param>
        /// <param name="replyUID">回复用户ID</param>
        /// <returns></returns>
        public int AddConsult(int dialogPID, int consultUID, string consultContent, int replyUID)
        {
            return _dialog.AddConsult(dialogPID, consultUID, consultContent, replyUID);
        }

        /// <summary>
        /// 用户回复
        /// </summary>
        /// <param name="dialogID"></param>
        /// <param name="replyContent"></param>
        /// <returns></returns>
        public int AddReply(int dialogID, string replyContent)
        {
            return _dialog.AddReply(dialogID, replyContent);
        }

        /// <summary>
        /// 获取用户提问的问题
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Dialog> GetUserConsultByUID(int uid)
        {
            return _dialog.GetUserConsultByUID(uid);
        }

        /// <summary>
        /// 获取用户回复的问题
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Dialog> GetUserReplyByUID(int uid)
        {
            return _dialog.GetUserReplyByUID(uid);
        }
        #endregion
    }
}
