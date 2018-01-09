/**************************************************
 *  
 *  Author: Don van Hout (dvanhout)
 *  Date: June 1, 2017
 *  Purpose: The application calculates electricity rates 
 *           based on $/kWh usage formula for different
 *           user types 
 *  
 **************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityPower {
    public partial class frmCalcPower : Form {
        // rates for different types of users
        const decimal RESIDENTIAL_BASE_RATE = 6.00m; // base rate for residential
        const decimal RESIDENTIAL_HOUR_RATE = 0.052m; // hourly rate for residential
        const decimal COMMERCIAL_BASE_RATE = 60.00m; // base rate for commercial
        const decimal COMMERCIAL_HOUR_RATE = 0.045m; // hourly rate for commercial
        const decimal INDUSTRIAL_BASE_RATE_OFF = 40.00m; // base rate for OFFPEAK industrial
        const decimal INDUSTRIAL_HOUR_RATE_OFF = 0.028m; // hourly rate for OFFPEAK industrial
        const decimal INDUSTRIAL_BASE_RATE_PEAK = 76.00m; // base rate for PEAK industrial
        const decimal INDUSTRIAL_HOUR_RATE_PEAK = 0.065m; // hourly rate for PEAK industrial

        public frmCalcPower() {
            InitializeComponent();
        }

        /**************************************************
         *  Exit button closes the program
         **************************************************/
        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        /**************************************************
         *  Clear button, resets values
         **************************************************/
        private void btnClear_Click(object sender, EventArgs e) {
            txtKwh.Text = "0";
            txtOffPeak.Text = "0";
            txtCost.Text = "";
        }

        /**************************************************
         *  Calculate button triggers appropriate calculation based on radio button
         **************************************************/
        private void btnCalculate_Click(object sender, EventArgs e) {
            decimal cost = 0; // variable used for cost
            int kwh = 0; // kWh value

            if (IsValid()) { 
                // get kwh from user
                kwh = Convert.ToInt32(txtKwh.Text);

                // calculate cost based on radio box
                if (radResidential.Checked == true) {
                    // calculate residential rate
                    cost = ResidentialRate(kwh);

                } else if (radCommercial.Checked == true) {
                    // calculate commercial rate
                    cost = CommercialRate(kwh);

                } else if (radIndustrial.Checked == true) {
                    // calculate industrial rate
                    int offPeakKwh = 0;
                    // validate off peak text box
                    if (IsValidIndustrial()) {
                        offPeakKwh = Convert.ToInt32(txtOffPeak.Text); // get industrial off-peak hours from user
                        cost = IndustrialRate(kwh, offPeakKwh);
                    }
                } 
      
                // output usage as a string with currency formatting
                txtCost.Text = cost.ToString("C");
            }
        }

        /**************************************************
         *  Calculates residential rate
         **************************************************/
        private decimal ResidentialRate(int hrs) {

            // residential pricing has base rate from 0 hrs
            decimal price = RESIDENTIAL_BASE_RATE + RESIDENTIAL_HOUR_RATE * hrs; 

            // return price
            return price;
        }

        /**************************************************
         *  Calculates commercial rate
         **************************************************/
        private decimal CommercialRate(int hrs) {

            decimal price = COMMERCIAL_BASE_RATE; // value charged even at 0 hrs

            if (hrs > 1000) {
                price += COMMERCIAL_HOUR_RATE * (hrs - 1000);
            }

            return price; // return the value
        }

        /**************************************************
         *  Calculates industrial rate
         **************************************************/
        private decimal IndustrialRate(int hrs, int OP_hrs) {

            // base industrial rate is off peak base rate + peak base rate, even at 0 kWh's
            decimal price = INDUSTRIAL_BASE_RATE_PEAK + INDUSTRIAL_BASE_RATE_OFF; 

            // calculate price for peak hours over 1000
            if (hrs > 1000) {
                price += INDUSTRIAL_HOUR_RATE_PEAK * (hrs - 1000);
            }

            // calculate off peak hours over 1000
            if (OP_hrs > 1000) {
                price += INDUSTRIAL_HOUR_RATE_OFF * (OP_hrs - 1000);
            }
            return price; // return the price
        }

        /**************************************************
         *  Show industrial off peak labels/textbox when radio button checked
         **************************************************/
        private void radIndustrial_CheckedChanged(object sender, EventArgs e) {
            ShowOffPeak();
            picImage.ImageLocation = "../../images/industrial.png";
        }

        /**************************************************
         *  Hide industrial off peak labels/textbox when radio button checked
         **************************************************/
        private void radCommercial_CheckedChanged(object sender, EventArgs e) {
            HideOffPeak();
            picImage.ImageLocation = "../../images/commercial.png";
        }

        /**************************************************
         *  Hide industrial off peak labels/textbox when radio button checked
         **************************************************/
        private void radResidential_CheckedChanged(object sender, EventArgs e) {
            HideOffPeak();
            picImage.ImageLocation = "../../images/residential.png";   
        }
        
        /**************************************************
         *  Check for valid input on txtKwh text box (residential and commercial)
         **************************************************/
        private bool IsValid() {
            return Validator.IsPresent(txtKwh, "kWh") &&
                   Validator.IsInt32(txtKwh, "kWh") &&
                   Validator.IsPositiveInt(txtKwh, "kWh");
        }

        /**************************************************
         *  Check for valid input on txtOffPeak text box (industrial only)
         **************************************************/
        private bool IsValidIndustrial() {
            return Validator.IsPresent(txtOffPeak, "Off Peak kWh") &&
                   Validator.IsInt32(txtOffPeak, "Off Peak kWh") &&
                   Validator.IsPositiveInt(txtOffPeak, "Off Peak kWh");
        }

        /**************************************************
         *  Hide Off Peak text box and labels
         **************************************************/
        private void HideOffPeak() {
            txtOffPeak.Visible = false;
            lblOffPeak.Visible = false;
            lblPeak.Visible = false;
        }

        /**************************************************
         *  Show Off Peak text box and labels
         **************************************************/
        private void ShowOffPeak() {
            txtOffPeak.Visible = true;
            lblOffPeak.Visible = true;
            lblPeak.Visible = true;
        }
    }
}
