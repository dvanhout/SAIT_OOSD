using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace States {
    public partial class WebForm1 : System.Web.UI.Page {

        int count; // does not get stored on each button click
        // we need to add local variables to ViewState in order to preserve values

        protected void Page_Load(object sender, EventArgs e) {
            if (Application["count"] != null) {
                count = (int)Application["count"]; // application collaborates accross multiple sessions
                // count = (int)Session["count"]; // no collaboration... independent of session
            }
            lblClicks.Text = count.ToString();
        }

        protected void btnClick_Click(object sender, EventArgs e) {
            count++;
            lblClicks.Text = count.ToString();
            Application["count"] = count;
        }
    }
}