<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Input.aspx.cs" Inherits="Input" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="学生信息录入：" Font-Bold="True" 
        Font-Size="Large"></asp:Label>
    <br /> <br /> <br /> 
    <div>
       学号：<asp:TextBox ID="StuNo" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="StuNo"  
            ErrorMessage="必须输入学号"></asp:RequiredFieldValidator><br />
       <br />姓名：<asp:TextBox ID="Name" runat="server"></asp:TextBox><br /><br />
       生日：<asp:TextBox ID="Birth" runat="server" ontextchanged="TextBox3_TextChanged"></asp:TextBox><br /><br />
       专业：<asp:TextBox ID="MajorId" runat="server"></asp:TextBox><br /><br />
       照片：<asp:FileUpload ID="Image" runat="server" style="margin-bottom: 0px" 
            Width="185px" />
        <br />
       </div>  
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
            
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <p>
        <asp:Button ID="Button1" runat="server" Text="提交" Height="25px" 
        onclick="Button1_Click" Width="67px" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Button2" runat="server" 
            Text="查看" onclick="Button2_Click" 
            Width="58px" style="height: 26px" />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="Button3" runat="server" Text="修改" onclick="Button3_Click" 
            Width="58px" />
    
    </p>
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
            BackColor="#00CC00"></asp:Label>
    
    </p>
    
    </form>
</body>
</html>
