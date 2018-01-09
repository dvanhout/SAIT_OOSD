using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace States {
    public partial class WebForm2 : System.Web.UI.Page {
        int count;
        protected void Page_Load(object sender, EventArgs e) {
            if (Application["count"] != null) {
                count = (int)Application["count"];
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