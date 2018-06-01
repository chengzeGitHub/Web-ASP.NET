using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class Input : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strCnn = ConfigurationManager.ConnectionStrings["StudentCnnString"].ConnectionString;

        using (SqlConnection cnn = new SqlConnection(strCnn))
        {
            SqlDataAdapter daStu = new SqlDataAdapter("select * from StudInfo", cnn);

            SqlCommandBuilder sbStu = new SqlCommandBuilder(daStu);

            DataTable dtStuInfo = new DataTable();

            daStu.FillSchema(dtStuInfo, SchemaType.Mapped);

            DataRow dr = dtStuInfo.NewRow();
            dr[0] = TextBox1.Text.Trim();
            dr[1] = TextBox2.Text.Trim();
            dr[2] = TextBox3.Text.Trim();
            dr[3] = TextBox4.Text.Trim();
            dtStuInfo.Rows.Add(dr);
            daStu.Update(dtStuInfo);

            Label2.Text = "提交成功";
        }
    }

    // 查看 
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("InfoSelect.aspx");
        //Response.Redirect(InfoSelect.aspx);
    }

    // 修改
    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("Del.aspx");
        // Response.Redirect("Del.aspx");
    }
}
