<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TemperatureConverter._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="styles.css" rel="stylesheet" />

        <title>Temperature Converter</title>

    </head>

    <body>
        <form id="form" runat="server">
            <header>
                <h1>Temperature Converter</h1>
            </header>
            <main>
                <aside>
                    <div id="image_wrapper">
                        <img src="images/thermometer.png" />
                    </div>
                </aside>
                <div id="content_wrapper">
                    <div id="drop_wrapper">
                        <div id="drop_down1">
                            <div id="lbl_from">From:</div>
                                <asp:DropDownList ID="ddlFrom" runat="server">
                                <asp:ListItem>Celsius</asp:ListItem>
                                <asp:ListItem>Fairenheit</asp:ListItem>
                                <asp:ListItem>Kelvin</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="drop_down2">
                            <div id="lbl_to">To:</div>
                                <asp:DropDownList ID="ddlTo" runat="server">
                                <asp:ListItem>Fairenheit</asp:ListItem>
                                <asp:ListItem>Celsius</asp:ListItem>
                                <asp:ListItem>Kelvin</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="input"> 
                        <div id="lbl_Input_Temp">                  
                            <asp:Label ID="lbl_Input" runat="server" Text="Input Temperature:"></asp:Label>
                        </div>
                        <div id="txt_Input_Temp">
                            <asp:TextBox ID="txtInput" runat="server" Width="85px"></asp:TextBox>
                        </div>
                        <div id ="validate">
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtInput" Display="Dynamic" ErrorMessage="Temperature must be between -1000...1000" MaximumValue="1000" MinimumValue="-1000" Type="Double"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInput" Display="Dynamic" ErrorMessage="Must have a value to convert"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="btns">

                        <asp:Button class="calculateBtn" ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
                        <asp:Button class="clearBtn" ID="btnClear" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click" />
                    </div>
                    <div id="result">
                        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </main>
        </form>
    </body>
</html>
