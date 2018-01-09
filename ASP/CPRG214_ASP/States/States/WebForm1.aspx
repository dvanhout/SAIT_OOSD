<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="States.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>I am Page 1</h1>
        <p>
            <asp:Button ID="btnClick" runat="server" Height="42px" OnClick="btnClick_Click" Text="Click Me" Width="98px" />
        </p>
        <p>
            Number of clicks:&nbsp;
            <asp:Label ID="lblClicks" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnGo" runat="server" Height="33px" PostBackUrl="~/WebForm2.aspx" Text="Go" Width="98px" />
        </p>
    
    </div>
    </form>
</body>
</html>
