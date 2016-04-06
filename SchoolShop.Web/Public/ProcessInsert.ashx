<%@ WebHandler Language="C#" Class="ProcessInsert" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
public class ProcessInsert : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //获取客户端提取过来的数据
        string Title = context.Request.Form["txtname"];
        string user_input = context.Request.Form["k_textarea"];
        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=MyPhotos;Integrated Security=True"))
        {
            string sql = "insert into T_News values(@Title,@Context,@PubDate)";
            SqlParameter[] param = new SqlParameter[] { 
                                   new SqlParameter("@Title",SqlDbType.NVarChar,100){Value=Title},
                                   new SqlParameter("@Context",SqlDbType.NVarChar){Value=user_input},
                                    new SqlParameter("@PubDate",SqlDbType.DateTime){Value=DateTime.Now}
            };
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                con.Open();
                com.Parameters.AddRange(param);
                com.ExecuteNonQuery();
            }
        }
        int mm = 0;
        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=MyPhotos;Integrated Security=True"))
        {
            string sql = "select *from T_News";
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    mm = Convert.ToInt32(sdr["AUToID"]);
                }
            }
        };


        context.Response.Redirect("Show.aspx?id=" + mm);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}