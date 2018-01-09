<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="CrossPagePostBack.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>I am on Page 2</h1>
        <p>
            Your name is:&nbsp;
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnGoBack" runat="server" Height="45px" PostBackUrl="~/WebForm1.aspx" Text="Back" Width="100px" />
        </p>
    </form>
</body>
</html>
