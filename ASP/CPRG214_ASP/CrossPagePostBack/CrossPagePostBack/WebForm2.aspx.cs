using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrossPagePostBack {
    public partial class WebForm2 : System.Web.UI.Page {
        // retrieve name from text box on page 1 and display in a label
        protected void Page_Load(object sender, EventArgs e) {
                Page previous = Page.PreviousPage; // where the control came from 
                if (previous != null) { 
                TextBox txtb = (TextBox)previous.FindControl("txtName");
                lblName.Text = txtb.Text;
            } else {
                lblName.Text = "unknown";
            }
        }
    }
}