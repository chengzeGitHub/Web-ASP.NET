<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        #Select1
        {
            width: 162px;
        }
    </style>

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function Select1_onclick() {

        }

// ]]>
    </script>
    <style type="text/css">
        #all
        {
        	margin:2% 32%;
        }
        	
    </style>
</head>
<body>
<div id="all">    <!-- 掌控全局 -->
    <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 在线知识问答系统</h1>
    <form id="form1" runat="server">
    请填写基本信息：<br />
&nbsp;<div>
            姓&nbsp; 名：<asp:TextBox ID="Name" runat="server"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="Name" Display="Dynamic" ErrorMessage="姓名不能为空"></asp:RequiredFieldValidator>
            <br /><br />
            编&nbsp; 号：<asp:TextBox ID="Num" runat="server"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="Num" Display="Dynamic" ErrorMessage="编号不能为空"></asp:RequiredFieldValidator>
                
            <br /><br />
            Email：<asp:TextBox ID="Email" runat="server"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="Email" Display="Dynamic" ErrorMessage="邮箱不能为空"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="RegularExpressionValidator" Display="Dynamic" 
                ControlToValidate="Email" 
                ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
        </div>
        <div>
        <br />
        请选择知识类型：<asp:DropDownList ID="QuestionType" runat="server" Height="26px" 
                Width="138px">
                <asp:ListItem>人文知识</asp:ListItem>
                <asp:ListItem>科学类</asp:ListItem>
                <asp:ListItem>经济管理</asp:ListItem>
            </asp:DropDownList>
            <br /><br />
            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="verify" runat="server" onclick="Verify_Click" Text="开始答题" />
        
        </div>
    <br />
    <asp:Panel ID="HumanSicene" runat="server">    <!--  题目位置 -->
     <!-- 第一大题 -->
          <h4>一.单项选择题（每小题20分，共60分）</h4>
          <div>
               1.中国历史上在位最长时间的皇帝是（）
               <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                   onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                   <asp:ListItem>唐太宗</asp:ListItem>
                   <asp:ListItem>康熙</asp:ListItem>
                   <asp:ListItem>乾隆</asp:ListItem>
               </asp:RadioButtonList>
          </div>
          <br />
          <div>
              2.《三国演义》的作者是（）
              <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                  <asp:ListItem>曹雪芹</asp:ListItem>
                  <asp:ListItem>罗贯中</asp:ListItem>
                  <asp:ListItem Value="冯梦龙"></asp:ListItem>
              </asp:RadioButtonList>
          </div>
          <br />
          <div>
             3.蔗糖生产技术是从哪里传入中国的（）
              <asp:RadioButtonList ID="RadioButtonList3" runat="server">
                  <asp:ListItem>印度</asp:ListItem>
                  <asp:ListItem>澳洲</asp:ListItem>
                  <asp:ListItem>非洲</asp:ListItem>
              </asp:RadioButtonList>
          </div>
    
 <!-- 第二大题 -->
        <h4>二.多项选择题（每小题20分，共40分）</h4>
        <div>
            1.采用君主立宪制政体的国家有（）
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem>泰国</asp:ListItem>
                <asp:ListItem>美国</asp:ListItem>
                <asp:ListItem>日本</asp:ListItem>
                <asp:ListItem>英国</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <br />
        <div>
            2.下列哪些作品出自英国作家（）
            <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                <asp:ListItem>老古玩店</asp:ListItem>
                <asp:ListItem>雾都孤儿</asp:ListItem>
                <asp:ListItem Value="呼啸山庄"></asp:ListItem>
                <asp:ListItem>基督山伯爵</asp:ListItem>
            </asp:CheckBoxList>
        
        </div>
    
    
  
    <br />
        <asp:Button ID="Button2" runat="server" Text="提  交" onclick="Upload"/>
     
     <br />
     <br />
     <!-- 提交结果显示 -->
        <h5>成绩：</h5>
        <asp:Label ID="Score" runat="server" Text=""></asp:Label>
        <br />
        <h5>正确答案：</h5>
        <asp:Label ID="Answer" runat="server" Text=""></asp:Label>
     
    </asp:Panel>
    </form>
</div>
<br />
<br />
</body>
</html>
