<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="PartyDateVote.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Current Voting Results</h1>
        <h3>
            Vote Totals:</h3>
        <p>
            Day 1 =&nbsp;
            <asp:Label ID="lblDay1Tally" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600"></asp:Label>
        </p>
        <p>
            Day 2 =&nbsp;
            <asp:Label ID="lblDay2Tally" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600"></asp:Label>
        </p>
        <p>
            Day 3 =&nbsp;
            <asp:Label ID="lblDay3Tally" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#006600"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnReturn" runat="server" Height="40px" PostBackUrl="~/DateVote.aspx" Text="Return" Width="100px" />
        </p>
    
    </div>
    </form>
</body>
</html>
