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
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

public partial class Del : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MsgDel.Text = " ";
        MsgChg.Text = " ";
    }

    /** 编写“删除”按钮的事件处理程序，
     * 使用连接模式的数据库操作，
     * 删除StuInfo表的指定记录
     * 即，根据输入的StuNo值，删除相应记录。
     * 要求利用SqlParameter对象，
     * 使用参数化SQL语句，实现StuInfo表的指定记录删除。
     **/
    protected void Delete_Click(object sender, EventArgs e)
    {
        string strCnn = ConfigurationManager.ConnectionStrings["StudentCnnString"].ConnectionString;
         
        /*  此为断开模式
        using (SqlConnection cnn = new SqlConnection(strCnn))
        {
            SqlDataAdapter daStu = new SqlDataAdapter("select * from StudInfo", cnn);
            daStu.DeleteCommand = new SqlCommand("delete from StudInfo where StuNo = @StuNo", cnn);
            daStu.DeleteCommand.Parameters.Add("@StuNo", SqlDbType.VarChar, 8, "StuNo");
            DataTable dtStudInfo = new DataTable();
            daStu.Fill(dtStudInfo);
            dtStudInfo.PrimaryKey = new DataColumn[] {dtStudInfo.Columns["StuNo"]};
            DataRow row = dtStudInfo.Rows.Find(StuNo.Text.Trim());
            if(row != null)
            {
                row.Delete();
                daStu.Update(dtStudInfo);
                MsgDel.Text = "删除成功";
            }
            else
            {
                MsgDel.Text = "没有该记录";
            }
        }
        */
        SqlConnection cnn = new SqlConnection(strCnn);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnn;  // 绑定Command对象

        // 设置带参数的SQL命令
        cmd.CommandText = "delete from StudInfo where StuNo = @StuNo";

        // 为Command对象使用SqlParament对象准备参数
        SqlParameter stuNoParam = new SqlParameter();
        stuNoParam.ParameterName = "@StuNo";
        stuNoParam.Value = StuNo.Text.Trim();

        // 将准备好的参数加入Command对象
        cmd.Parameters.Add(stuNoParam);

        cnn.Open();
       


        ///////////////////////// 删除照片
        // 从数据库获取图片名字
        string cmdText = "select Image from StudInfo where StuNo = " + StuNo.Text.Trim();
        SqlCommand cmd2 = new SqlCommand(cmdText, cnn);
        SqlDataReader dr = cmd2.ExecuteReader();
        if (dr.Read())
        {
            string imageName = (string)dr.GetValue(0);
            Response.Write(imageName);

            // 获取路径并且删除
            string FilePath = Server.MapPath("image/" + imageName);  // 必须转化以下文件路径，不能直接delete("image/4jpg");
            File.Delete(FilePath);
        }
        cnn.Close();
        cnn.Open();

        // 删除图片后删除记录
        cmd.ExecuteNonQuery();
        MsgDel.Text = "删除成功";
        cnn.Close();

        

    }
    // 修改
    protected void Change_Click(object sender, EventArgs e)
    {
        /*
         * 编写“更改”按钮的事件处理程序，使用断开模式的数据库访问方式，
         * 修改StuInfo表中的Name和MajorId 字段的值（即，根据输入的StuNo值及新的Name和MajorId值进行修改）。
         * 要求利用SqlDataAdapter和DataSet对象，实现该功能。
         */
        string strCnn = ConfigurationManager.ConnectionStrings["StudentCnnString"].ConnectionString;

        using (SqlConnection cnn = new SqlConnection(strCnn))
        {
            SqlDataAdapter daStu = new SqlDataAdapter("select * from StudInfo", cnn);

            SqlCommandBuilder sbStu = new SqlCommandBuilder(daStu);

            DataTable dtStuInfo = new DataTable();

            daStu.Fill(dtStuInfo);

            dtStuInfo.PrimaryKey = new DataColumn[] { dtStuInfo.Columns["StuNo"] };

            DataRow row = dtStuInfo.Rows.Find(txtStuNo.Text.Trim());

            // 判断是否存在
            if (row != null)
            {
                // 修改
                row.BeginEdit();
                row[1] = txtName.Text.Trim();
                row[3] = txtMajor.Text.Trim();
                row.EndEdit();

                daStu.Update(dtStuInfo);
                MsgChg.Text = "修改成功";
            }
            else
            {
                MsgChg.Text = "修改失败";
            }
        }

    }
    protected void Input_Click(object sender, EventArgs e)
    {
        Server.Transfer("Input.aspx");
    }
    protected void View_Click(object sender, EventArgs e)
    {
        Server.Transfer("InfoSelect.aspx");
    }
}
