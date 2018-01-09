<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateVote.aspx.cs" Inherits="PartyDateVote.DateVote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 399px;
            height: 201px;
        }
        .auto-style2 {
            color: #006600;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <img alt="Party_Image" class="auto-style1" src="Images/party.png" /><br />
        <br />
        <h4><span class="auto-style2"><strong>Choose your preferred Party Date from the calendar below and submit your vote</strong></span></h4>
        <asp:Calendar ID="calDate" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="396px" NextPrevFormat="ShortMonth" OnDayRender="calDate_DayRender" OnSelectionChanged="calDate_SelectionChanged" Width="524px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
            <DayStyle BackColor="#CCCCCC" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <SelectorStyle BackColor="Lime" />
            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
        <asp:Label ID="lblError" runat="server" style="color: #FF0000"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Height="40px" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
    </form>
</body>
</html>
