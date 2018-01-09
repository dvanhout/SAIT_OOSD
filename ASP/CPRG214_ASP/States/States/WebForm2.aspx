<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="States.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>I am page 2</h1>
        <p>
            <asp:Button ID="btnClick" runat="server" Height="42px" OnClick="btnClick_Click" Text="Click Me" Width="98px" />
        </p>
        <p>
            Number of clicks = <asp:Label ID="lblClicks" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnGoBack" runat="server" Height="22px" PostBackUrl="~/WebForm1.aspx" Text="Go Back" Width="100px" />
        </p>
    
    </div>
    </form>
</body>
</html>
