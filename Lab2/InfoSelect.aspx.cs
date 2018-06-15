using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Configuration;

public partial class InfoSelect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strCnn = ConfigurationManager.ConnectionStrings["StudentCnnString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(strCnn);
        
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        cmd.Connection = cnn;
        cmd2.Connection = cnn;
        cmd.CommandText = "select * from StudInfo";

        SqlDataReader stuReader = null;
     

        
        try
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            stuReader = cmd.ExecuteReader();
            Response.Write("<table border = '1'><tr align = 'center'>");

            // 输出表格所有字段
            for (int i = 0; i < stuReader.FieldCount; i++)
            {
                Response.Write("<td style='width:300px'>" + stuReader.GetName(i) + "</td>");
            }

            Response.Write("</tr>");

            
            
            
            



            // 输出记录
            while (stuReader.Read())
            {
                Response.Write("<tr>");

                // 输出前面的信息
                int j;
                for (j = 0; j < stuReader.FieldCount-1; j++)
                {
                    Response.Write("<td style='height:30px;text-align:center'>" + stuReader.GetValue(j) + "</td>");
                }
                /* 冲突报错 DataReader
                // 从数据表Major获取专业名字，索引是stuReader.GetValue(j)
                int num = (int)stuReader.GetValue(j);
                //stuReader.Close();
                cmd2.CommandText = "select MajorName from Major where MajorId = " + num;
                string majorName = (string)cmd2.ExecuteScalar();
               
                Response.Write("<td>" + majorName + "</td>");
                 */
                
                //stuReader.Open();
                
                // 从数据库的数据表获取图片名字
                string imageUrl = (string)stuReader.GetValue(j);

                // 输出图片
                Response.Write("<td><img src='image/" + imageUrl + "'/></td>");

                Response.Write("</tr>");
            }
            Response.Write("</table>");
        }
        catch(Exception ex)
        {
           Response.Write("失败：" + ex.Message);
        }
            
        finally
        {
            if(stuReader.IsClosed == false)
                stuReader.Close();
            if(cnn.State == ConnectionState.Open)
                cnn.Close();
        }
         

    }
    
}
