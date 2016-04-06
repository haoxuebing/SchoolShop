using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolShop.Model;
using SchoolShop.FrameWork.Utility;

namespace SchoolShop.Data.DAL
{
    public class DialogDAL
    {
        #region 对话
        /// <summary>
        /// 根据PID获取对话
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<Dialog> GetDialogByPID(int pid)
        {
            List<Dialog> list = new List<Dialog>();
            List<EF.SS_Dialog> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Dialog.Where(d => d.DialogPID == pid && d.DelFlag == 0).ToList();
            }
            if (entity != null)
            {
                Dialog dia = null;
                foreach (var item in entity)
                {
                    dia = new Dialog()
                    {
                        ConsultContent = item.ConsultContent,
                        ConsultTime = item.ConsultTime,
                        ConsultUID = item.ConsultUID,
                        DelFlag = item.DelFlag,
                        DialogID = item.DialogID,
                        DialogOver = item.DialogOver,
                        DialogPID = item.DialogPID,
                        ReplyContent = item.ReplyContent,
                        ReplyTime = item.ReplyTime,
                        ReplyUID = item.ReplyUID
                    };
                    list.Add(dia);
                }
            }
            return list;
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
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                EF.SS_Dialog entity = new EF.SS_Dialog()
                {
                    ConsultContent = consultContent,
                    ConsultTime = DateTime.Now,
                    ConsultUID = consultUID,
                    DelFlag = 0,
                    DialogOver = 0,
                    ReplyUID = replyUID,
                    DialogPID = dialogPID
                };
                content.SS_Dialog.Add(entity);
                result = content.SaveChanges();
            }
            return result;
        }
        /// <summary>
        /// 用户回复
        /// </summary>
        /// <param name="dialogID"></param>
        /// <param name="replyContent"></param>
        /// <returns></returns>
        public int AddReply(int dialogID, string replyContent)
        {
            int result = 0;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                var entity = content.SS_Dialog.SingleOrDefault(d => d.DialogID == dialogID);
                entity.ReplyContent = replyContent;
                entity.ReplyTime = DateTime.Now;
                result = content.SaveChanges();
            }
            return result;
        }
        /// <summary>
        /// 获取用户提问的问题
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Dialog> GetUserConsultByUID(int uid)
        {
            List<Dialog> list = new List<Dialog>();
            List<EF.SS_Dialog> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Dialog.Where(d => d.ConsultUID == uid && d.DelFlag == 0).ToList();
            }
            if (entity != null)
            {
                Dialog dia = null;
                foreach (var item in entity)
                {
                    dia = new Dialog()
                    {
                        ConsultContent = item.ConsultContent,
                        ConsultTime = item.ConsultTime,
                        ConsultUID = item.ConsultUID,
                        DelFlag = item.DelFlag,
                        DialogID = item.DialogID,
                        DialogOver = item.DialogOver,
                        DialogPID = item.DialogPID,
                        ReplyContent = item.ReplyContent,
                        ReplyTime = item.ReplyTime,
                        ReplyUID = item.ReplyUID
                    };
                    list.Add(dia);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取用户回复的问题
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Dialog> GetUserReplyByUID(int uid)
        {
            List<Dialog> list = new List<Dialog>();
            List<EF.SS_Dialog> entity = null;
            using (EF.schoolshopEntities content = new EF.schoolshopEntities())
            {
                entity = content.SS_Dialog.Where(d => d.ReplyUID == uid && d.DelFlag == 0).ToList();
            }
            if (entity != null)
            {
                Dialog dia = null;
                foreach (var item in entity)
                {
                    dia = new Dialog()
                    {
                        ConsultContent = item.ConsultContent,
                        ConsultTime = item.ConsultTime,
                        ConsultUID = item.ConsultUID,
                        DelFlag = item.DelFlag,
                        DialogID = item.DialogID,
                        DialogOver = item.DialogOver,
                        DialogPID = item.DialogPID,
                        ReplyContent = item.ReplyContent,
                        ReplyTime = item.ReplyTime,
                        ReplyUID = item.ReplyUID
                    };
                    list.Add(dia);
                }
            }
            return list;
        }
       


       
        #endregion

    }
}
