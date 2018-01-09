<!-- 
     Author:        Don van Hout
     Date:          July 2017
     Purpose:       Lab assignment 3, CPRG 214, SAIT OOSD, Spring 2017
     Description:   This web page takes data from two tables in TechSupport.mdf
                    database.   
    
                    The TechSupport database (ERD on the last page of this lab) is 
                    used to track technical support incidents for a small software 
                    company named SportsPro. 

                    User selects a technician's name from a drop down list, which 
                    then queries the database to retrieve open Incident's and
                    displays the list of open incidents to a list, ordered by 
                    date that the incident was opened.  
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OpenIncidents.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server" enableviewstate="True">
        <title>Lab 3 CPRG 214, SAIT OOSD (2017 Track)</title>
        <!-- bootstrap references -->
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Content/styles.css" rel="stylesheet" /> <!-- bootstrap override stylesheet -->
        <script src="Scripts/jquery-1.9.1.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>

        <!-- google fonts imported -->
        <link href="https://fonts.googleapis.com/css?family=Arimo" rel="stylesheet">

        <style type="text/css">

        </style>

    </head>


    <body class="container">
        <form id="form1" class="form-group container-fluid" runat="server">
            <div>
                <!-- header text-->
                <header>
                    <div class="page-header">
                        <h1>
                            <img alt="issue_icon" class="img" src="Images/issue.png" />&nbsp; Open Incidents Report
                        </h1>
                    </div>
                </header>


                <!-- drop down technicians menu -->
                <main>
                    <div>
                        <div class="dropdown col-lg-4">
                            <asp:DropDownList ID="ddlTechnicians" cssClass="btn btn-default btn-block" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TechID">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllTechnicians" TypeName="OpenIncidents.TechnicianDB"></asp:ObjectDataSource>
                        </div>
                    </div> 
        
                    <div class="table table-responsive">
                        <asp:GridView ID="gvOpenIncidents" cssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                            <Columns>
                                <asp:BoundField DataField="TechID" HeaderText="Tech" SortExpression="TechID" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IncidentID" HeaderText="Incident" SortExpression="IncidentID" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer" SortExpression="CustomerName" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateOpened" HeaderText="Opened" SortExpression="DateOpened" DataFormatString="{0:d}" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                <ItemStyle Font-Size="Smaller" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateClosed" HeaderText="Closed" SortExpression="DateClosed" DataFormatString="{0:d}" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                <ItemStyle Font-Size="Smaller" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" >
                                <HeaderStyle BackColor="#2A2A2A" ForeColor="White" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOpenTechIncidents" TypeName="OpenIncidents.IncidentDB">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlTechnicians" Name="techID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                     </div>
                </main>
            </div>
        </form>
    </body>
</html>
