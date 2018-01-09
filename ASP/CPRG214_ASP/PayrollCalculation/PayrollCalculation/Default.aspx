<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PayrollCalculation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 45px">
        <link href="styles.css" rel="stylesheet" />
        <h1 class="burgundy">Payroll Calculation</h1>
        <br />
    
    </div>
        <p>
            <img alt="MoneyImage" class="auto-style2" src="images/canadian-money.jpg" /></p>
        <table class="auto-style3">
            <tr>
                <td class="auto-style6" style="font-family: Arial, Helvetica, sans-serif; font-size: small">Enter Total Hours Worked:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtHours" runat="server" Width="186px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvHours" runat="server" ControlToValidate="txtHours" Display="Dynamic" ErrorMessage="Hours Worked must have a value" style="color: #FF0000"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvalHours" runat="server" ControlToValidate="txtHours" Display="Dynamic" ErrorMessage="Hours must be a number (0 -&gt; 80)" MaximumValue="80" MinimumValue="0" style="color: #660066" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="font-family: Arial, Helvetica, sans-serif; font-size: small">Enter Hourly Rate:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtRate" runat="server" Width="188px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRate" runat="server" ControlToValidate="txtRate" Display="Dynamic" ErrorMessage="Hourly Rate must have a value" style="color: #FF0000"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvalRate" runat="server" ControlToValidate="txtRate" Display="Dynamic" ErrorMessage="Hourly Rate must be a number (0 -&gt; 1000)" MaximumValue="1000" MinimumValue="0" style="color: #660066" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Calculate" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Width="91px" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="font-family: Arial; font-size: 16px; font-weight: bold; font-style: normal; font-variant: small-caps; text-transform: capitalize">Pay Amount</td>
                <td class="auto-style5">
                    <asp:Label ID="lblAmount" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
