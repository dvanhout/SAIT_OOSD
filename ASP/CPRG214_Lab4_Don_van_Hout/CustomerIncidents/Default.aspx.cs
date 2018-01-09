/*
 *  Author:         Don van Hout
 *  Date:           July 2017
 *  Purpose:        CPRG 214 Lab 4, SAIT OOSD 2017 (spring track)
 *  Description:    Gets data from Web Service to populate a drop 
 *                  down list with customer id's.  User can choose
 *                  customer id to see incidents associated with thier id.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerIncidents {
    public partial class Default2 : System.Web.UI.Page {

        IncidentsServiceReference.IncidentServiceClient proxy =
            new IncidentsServiceReference.IncidentServiceClient(); // client proxy
        IncidentsServiceReference.Incident[] customers; // all incidents

        protected void Page_Load(object sender, EventArgs e) {
            loadDdl(); // load the drop down list
        }

        protected void ddlCustomerID_SelectedIndexChanged(object sender, EventArgs e) {
            loadGrid(); // load the gridview when ddl changed
        }

        protected void ddlCustomerID_Load(object sender, EventArgs e) {
            loadGrid(); // load the gridview when drop down initializes
        }

        protected void loadDdl() {
            if (!IsPostBack) {
                customers = proxy.GetAllCustomerIncidents(); // get all the customer incidents
                // populate drop down
                ddlCustomerID.DataSource = customers;
                ddlCustomerID.DataTextField = "CustomerID";
                ddlCustomerID.DataValueField = "CustomerID";
                ddlCustomerID.DataBind();
                Session["customers"] = customers;
                ddlCustomerID.SelectedIndex = 0;
            } else {
                customers = (IncidentsServiceReference.Incident[])Session["customers"];
            }
        }

        // load the gridview
        protected void loadGrid() {
            int index = ddlCustomerID.SelectedIndex;
            if (index != -1) {
                IncidentsServiceReference.Incident incidents = customers[index];
                IncidentsServiceReference.Incident[] i;
                i = proxy.GetCustomerIncidentsByID(incidents.CustomerID); // get customer incidents by id
 
                gvIncidents.DataSource = i;
                gvIncidents.DataBind();
            }
        }
    }
}