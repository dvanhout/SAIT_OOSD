using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayrollCalculation {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // turn off jquery
            // UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.WebForms;

        }

        protected void btnCalculate_Click(object sender, EventArgs e) {
            const double FULL_WEEK = 37.5;
            const double OT_RATE = 1.5; // time and a half for overtime

            double hours;
            double payRate; // hourly
            double payAmount;

            // get input values
            hours = Convert.ToDouble(txtHours.Text);
            payRate = Convert.ToDouble(txtRate.Text);

            // calculate
            if (hours <= FULL_WEEK) { 
                payAmount = payRate * hours;
            } else {
                payAmount = FULL_WEEK * payRate + (hours - FULL_WEEK) * OT_RATE * payRate;
            }

            // display result
            lblAmount.Text = payAmount.ToString("c");

        }

        protected void btnClear_Click(object sender, EventArgs e) {
            txtHours.Text = "";
            txtRate.Text = "";
            lblAmount.Text = "";
        }
    }
}