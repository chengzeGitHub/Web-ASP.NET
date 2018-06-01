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
using System.Configuration;

public partial class ConnectionDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strCnn = ConfigurationManager.ConnectionStrings["StudentCnnString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(strCnn);

        cnn.Open();
        Label1.Text = "成立建立数据库连接";
        cnn.Close();
    }
}
