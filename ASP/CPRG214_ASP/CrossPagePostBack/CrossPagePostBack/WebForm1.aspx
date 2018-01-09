<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CrossPagePostBack.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>I am on Page 1</h1>
        <p>
            enter your name:&nbsp;
            <asp:TextBox ID="txtName" runat="server" Height="21px" Width="147px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnGo" runat="server" Height="41px" PostBackUrl="~/WebForm2.aspx" Text="Go" Width="113px" />
        </p>
    
    </div>
    </form>
</body>
</html>
