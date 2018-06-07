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

    /**
     * 在该页面的.cs文件中编写“提交”按钮的事件处理程序，
     * 利用SqlConnection对象、SqlCommand对象及SqlParameter对象，
     * 使用参数化SQL语句实现StuInfo表新记录的添加。
     * */
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strCnn = ConfigurationManager.ConnectionStrings["StudentCnnString"].ConnectionString;

        /* 此为断开模式的
        using (SqlConnection cnn = new SqlConnection(strCnn))
        {
            SqlDataAdapter daStu = new SqlDataAdapter("select * from StudInfo", cnn);

            SqlCommandBuilder sbStu = new SqlCommandBuilder(daStu);

            DataTable dtStuInfo = new DataTable();

            daStu.FillSchema(dtStuInfo, SchemaType.Mapped);

            DataRow dr = dtStuInfo.NewRow();
            dr[0] = StuNo.Text.Trim();
            dr[1] = Name.Text.Trim();
            dr[2] = Birth.Text.Trim();
            dr[3] = MajorId.Text.Trim();
            dtStuInfo.Rows.Add(dr);
            daStu.Update(dtStuInfo);

            Label2.Text = "提交成功";
        }
        */

        /* 以下使用连接模式 */
        SqlConnection cnn = new SqlConnection(strCnn);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = "insert into StudInfo values(@StuNo, @Name, @Birth, @MajorId, @Image)";

        // 使用SqlParameter为SqlCommand对象准备参数
        SqlParameter stuNoParam = new SqlParameter();
        SqlParameter nameParam = new SqlParameter();
        SqlParameter birthParam = new SqlParameter();
        SqlParameter majorParam = new SqlParameter();
        SqlParameter imageParam = new SqlParameter();

        // 设置SqlParameter对象指向对应参数
        stuNoParam.ParameterName = "@StuNo";
        nameParam.ParameterName = "@Name";
        birthParam.ParameterName = "@Birth";
        majorParam.ParameterName = "@MajorId";
        imageParam.ParameterName = "@Image";

        // 给参数赋值
        stuNoParam.Value = StuNo.Text.Trim();
        nameParam.Value = Name.Text.Trim();
        birthParam.Value = Birth.Text.Trim();
        majorParam.Value = MajorId.Text.Trim();
        imageParam.Value = Image.FileName.Trim();

        // 将SqlParameter对象绑定到SqlCommand对象下
        cmd.Parameters.Add(stuNoParam);
        cmd.Parameters.Add(nameParam);
        cmd.Parameters.Add(birthParam);
        cmd.Parameters.Add(majorParam);
        cmd.Parameters.Add(imageParam);

        // 打开连接执行
        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
            Label2.Text = "提交成功";
            cnn.Close();
            
        }
        catch (Exception ex)
        {
            // 
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
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
}
