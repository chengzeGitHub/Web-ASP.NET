<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Del.aspx.cs" Inherits="Del" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="删除学生信息："></asp:Label>
        <br />
        学号： <asp:TextBox ID="StuNo" runat="server"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="Delete" runat="server" Text="删除" onclick="Delete_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="MsgDel" runat="server"></asp:Label>
        <br />
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="修改学生信息："></asp:Label>
         <br />
         学号：<asp:TextBox ID="txtStuNo" runat="server"></asp:TextBox><br />
         姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
         专业：<asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>&nbsp;&nbsp;
         <asp:Button ID="Change" runat="server" Text="修改" onclick="Change_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="MsgChg" runat="server"></asp:Label><br />
    </div>
    <div>
    </div>
    
    <p>
        <asp:Button ID="View" runat="server" Text="查看" onclick="View_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Input" runat="server" Text="添加" onclick="Input_Click" />
    &nbsp;</p>
    
    </form>
</body>
</html>
