using System;
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

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Verify_Click(object sender, EventArgs e)
    {
        

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Upload(object sender, EventArgs e)
    {
        // 算分
        int score = 0;
        if (RadioButtonList1.Text == "康熙")
        {
            score++;
            
        }
        if (RadioButtonList2.Text == "罗贯中")
        {
            score++;

        }
        if (RadioButtonList3.Text == "印度")
        {
            score++;

        }
        
        // 多项题目
        if (CheckBoxList1.Items[0].Selected && CheckBoxList1.Items[2].Selected && CheckBoxList1.Items[3].Selected )
        {
            score++;
        
        }
        if (CheckBoxList2.Items[0].Selected && CheckBoxList2.Items[1].Selected && CheckBoxList2.Items[2].Selected )
        {
            score++;
        }

        score *= 20;
        Score.Text = score.ToString();

        Answer.Text = "一， 1.康熙 2.罗贯中 3.印度 " + "\n"  + "二， 1.泰国、日本、英国 2.老古玩店、雾都孤儿、呼啸山庄";
    }

}
