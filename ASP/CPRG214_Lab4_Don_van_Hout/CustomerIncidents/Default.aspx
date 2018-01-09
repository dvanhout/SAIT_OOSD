<!-- 

 *  Author:         Don van Hout
 *  Date:           July 2017
 *  Purpose:        CPRG 214 Lab 4, SAIT OOSD 2017 (spring track)
 *  Description:    Gets data from Web Service to populate a drop 
 *                  down list with customer id's.  User can choose
 *                  customer id to see incidents associated with thier id.
 -->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerIncidents.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Lab 4 CPRG 214, SAIT OOSD (2017 Spring Track)</title>
        <!-- bootstrap references -->
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Content/styles.css" rel="stylesheet" /> <!-- bootstrap override stylesheet -->
        <script src="Scripts/jquery-1.9.1.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>

        <!-- google fonts imported -->
        <link href="https://fonts.googleapis.com/css?family=Arimo" rel="stylesheet" />

        <style type="text/css">

        </style>

</head>
    <body class="container">
        <form id="form1" class="form-group container-fluid" runat="server">
            <!-- header text-->
            <header>
                <div class="page-header">
                    <h1>
                        <img alt="issue_icon" class="img" src="Images/issue.png" />&nbsp; Customer Incidents Report
                    </h1>
                </div>
            </header>

            <!-- drop down customers menu -->
            <main>
                <div>
                    <div class="dropdown col-lg-4">
                        <asp:DropDownList ID="ddlCustomerID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomerID_SelectedIndexChanged" OnLoad="ddlCustomerID_Load">
                        </asp:DropDownList>
                    </div>
                </div> 

                <!-- grid view -->
                <div class="table table-responsive">
                    <asp:GridView ID="gvIncidents" cssClass="table table-bordered table-hover" runat="server">
                    </asp:GridView>
            
                </div>
            </main>
        </form>
    </body>
</html>
