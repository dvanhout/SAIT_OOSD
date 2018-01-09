using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemperatureConverter {
    public partial class _default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnCalculate_Click(object sender, EventArgs e) {
            double result = Convert.ToDouble(txtInput.Text);

            double value = Convert.ToDouble(txtInput.Text);

            if (ddlFrom.SelectedValue == "Celsius") { // convert from c
                if (ddlTo.SelectedValue == "Fairenheit") { // to f
                    result = value * 9.0 / 5.0 + 32;
                } else if (ddlTo.SelectedValue == "Kelvin") { // to k
                    result = value + 273.15;
                }

            } else if (ddlFrom.SelectedValue == "Fairenheit") { // convert from f
                if (ddlTo.SelectedValue == "Celsius") { // to c
                    result = (value - 32) * 5.0 / 9.0;
                } else if (ddlTo.SelectedValue == "Kelvin") {
                    result = ((value - 32) * 5.0 / 9.0) + 273.15;
                }
            } else if (ddlFrom.SelectedValue == "Kelvin") {
                if (ddlTo.SelectedValue == "Celsius") {
                    result = value - 273.15;
                } else if (ddlTo.SelectedValue == "Fairenheit") {
                    result = (value - 273.15) * 9.0 / 5.0 + 32;
                }
            }

            // display result to two decimal places
            Math.Round(result, 2);
            string output;
            output = txtInput.Text + " degrees " + ddlFrom.Text +
                    " is: " + result.ToString("f2") + " degrees " + ddlTo.Text;
            lblResult.Text = output;
        }

        protected void btnClear_Click(object sender, EventArgs e) {
            txtInput.Text = "";
            lblResult.Text = "";
        }
    }
}