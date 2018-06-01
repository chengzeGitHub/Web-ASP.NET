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
        cmd.Connection = cnn;
        cmd.CommandText = "select * from StudInfo";

        SqlDataReader stuReader = null;

        
        try
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            stuReader = cmd.ExecuteReader();
            Response.Write("<table border = '1'><tr align = 'center'>");

            for (int i = 0; i < stuReader.FieldCount; i++)
            {
                Response.Write("<td>" + stuReader.GetName(i) + "</td>");
            }

            Response.Write("</tr>");

            while (stuReader.Read())
            {
                Response.Write("<tr>");
                for (int j = 0; j < stuReader.FieldCount; j++)
                {
                    Response.Write("<td>" + stuReader.GetValue(j) + "</td>");
                }
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
