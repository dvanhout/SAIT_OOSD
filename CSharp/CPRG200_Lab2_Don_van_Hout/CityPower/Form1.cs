
/*
* Author:  Donald van Hout
* Created on:  June, 2017
* Purpose:  Lab 2 assignment for SAIT OOSD program
* 
* --- Form.cs calculates electricity rates for customers of an
*     electricity supply company. 
*           
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityPower {
    public partial class frmCalcPower : Form {

        // list of customers 
        CustomerList custList = new CustomerList();


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
         *  Clear button, wipes values using clearTextBoxes()
         **************************************************/
        private void btnClear_Click(object sender, EventArgs e) {
            clearTextBoxes();
        }

        /**************************************************
         *  function to clear text boxes
         **************************************************/
        private void clearTextBoxes() {
            txtKwh.Text = "";
            txtOffPeak.Text = "";
            txtCost.Text = "";
            txtCustomer.Text = "";
            txtAcctNo.Text = "";
        }


        /**************************************************
         *  Calculate button triggers calculation (method) based on radio button
         **************************************************/
        private void btnCalculate_Click(object sender, EventArgs e) {
            if (IsValidId() && IsValidName()) {
                //int kwh = Convert.ToInt32(txtKwh.Text); // kWh value
                int kwh = 0;
                int id = Convert.ToInt32(txtAcctNo.Text);
                string name = txtCustomer.Text;
                bool makeChanges = false;
                bool cancelPressed = false;
                bool changeNameOnly = false;
                int index = 0;

                // this block evaluates to see if a customer already exists in list based on id and gives user option to recalculate bill
                if (custExists(id)) {
                    string message = "you are about to make changes to an existing customer, do you want to continue?";
                    string title = "Changes";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK) {
                        makeChanges = true;
                        if (txtKwh.Text == "") { // only make changes to the name
                            changeNameOnly = true;
                        }
                    }
                    if (result == DialogResult.Cancel) {
                        cancelPressed = true;
                    }
                    index = IndexAt(id); // store list index of customer
                }

                if (changeNameOnly == true) { // customer exists, but change only the name value of customer
                    custList.ElementAt(index).Name = txtCustomer.Text;
                
                // recalculate the bill and change the name of customer
                } else if (makeChanges && IsValidKwh()) { 
                        kwh = Convert.ToInt32(txtKwh.Text);
                        switch (custList.ElementAt(index).Type) {
                            case 'C':
                                ((CommercialCustomer)custList.ElementAt(index)).calcCCustomer(kwh);
                                txtCost.Text = '$' + ((CommercialCustomer)custList.ElementAt(index)).Bill.ToString("f2");
                                break;
                            case 'R':
                                ((ResidentialCustomer)custList.ElementAt(index)).calcRCustomer(kwh);
                                txtCost.Text = '$' + ((ResidentialCustomer)custList.ElementAt(index)).Bill.ToString("f2");
                                break;
                            case 'I':
                                if (IsValidIndustrial()) {
                                    ((IndustrialCustomer)custList.ElementAt(index)).calcICustomer(kwh, Convert.ToInt32(txtOffPeak.Text));
                                    txtCost.Text = '$' + ((IndustrialCustomer)custList.ElementAt(index)).Bill.ToString("f2");
                                }
                                break;
                            default:
                                break;
                        }
                        custList.ElementAt(index).Name = txtCustomer.Text;
                    } else if (cancelPressed) { //do nothing
                
                // create a new customer and add to list
                } else if (IsValidKwh()) {
                    kwh = Convert.ToInt32(txtKwh.Text);
                    addCustomerToList(id, name, kwh);
                } 
            }
            // re-display to listview
            DisplayList(custList);
            txtKwh.Text = "";
            txtOffPeak.Text = "";
        }

        /**************************************************
        *  create a new customer in customer list
        **************************************************/
        private void addCustomerToList(int id, string name, int kwh) {
            // calculate cost based on radio box
            if (radResidential.Checked == true) { // residential customer
                ResidentialCustomer cust = new ResidentialCustomer(id, txtCustomer.Text, 'R', kwh);
                txtCost.Text = '$' + cust.Bill.ToString("f2"); // output to text box
                custList.Add(cust);

            } else if (radCommercial.Checked == true) { // commercial customer
                CommercialCustomer cust = new CommercialCustomer(id, txtCustomer.Text, 'C', kwh);
                txtCost.Text = '$' + cust.Bill.ToString("f2"); // output to text box
                custList.Add(cust);

            } else if (radIndustrial.Checked == true) { // industrial customer ... include off-peak hours
                int offPeakKwh = 0;

                // validate industrial off peak kWh
                if (IsValidIndustrial()) {
                    offPeakKwh = Convert.ToInt32(txtOffPeak.Text); // get industrial off-peak hours from user
                }
                IndustrialCustomer cust = new IndustrialCustomer(id, txtCustomer.Text, 'I', kwh, offPeakKwh);
                txtCost.Text = '$' + cust.Bill.ToString("f2"); // output to text box
                custList.Add(cust);
            }
            // update listview 
            DisplayList(custList);
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
        private bool IsValidKwh() {
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
         *  Check for valid input on Customer Id
         **************************************************/

        private bool IsValidId() {
            return Validator.IsPresent(txtAcctNo, "Account Number") &&
                   Validator.IsInt32(txtAcctNo, "Account Number") &&
                   Validator.IsPositiveInt(txtAcctNo, "Account Number");
        }


        /**************************************************
         *  Check for valid input on Customer Name field
         **************************************************/
        private bool IsValidName() {
            return Validator.IsPresent(txtCustomer, "Customer Name");
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


        /**************************************************
         *  On load, read customer data from file to list
         *************************************************/
        private void frmCalcPower_Load(object sender, EventArgs e) {
            // load list from file
            custList.Fill(); // load the list
            DisplayList(custList); // display list to listbox
        }


        /**************************************************
         *  itterate through list items and output to listview display
         *************************************************/
        private void DisplayList(CustomerList cl) {
            lsvCustomers.Items.Clear(); // clear the list
            foreach (Customer c in cl) {
                string[] arr = new string[4]; // create array for customer data
                arr = c.ToString().Split(',');
                ListViewItem itm; // display to listView
                itm = new ListViewItem(arr);
                lsvCustomers.Items.Add(itm);
            }

            // display statistics
            displayStats();
        }


        /**************************************************
        *  calcluate and shows statistics in statistics area
        *************************************************/
        private void displayStats() {
            decimal sumR = 0;
            decimal sumC = 0;
            decimal sumI = 0;
            int index = 0;
            foreach (Customer c in custList) {
                switch (c.Type) {
                    case 'R':
                        sumR += ((ResidentialCustomer)custList.ElementAt(index)).Bill;
                        break;
                    case 'C':
                        sumC += ((CommercialCustomer)custList.ElementAt(index)).Bill;
                        break;
                    case 'I':
                        sumI += ((IndustrialCustomer)custList.ElementAt(index)).Bill;
                        break;
                    default: break;
                }
                index++;
            }
            lblSumAll.Text = (sumR + sumC + sumI).ToString("c");
            lblSumR.Text = sumR.ToString("c");
            lblSumC.Text = sumC.ToString("c");
            lblSumI.Text = sumI.ToString("c");
            lblNumCustomer.Text = index.ToString();
        }


        /**************************************************
        *  write list of customers to file when file is closing
        *************************************************/
        private void frmCalcPower_FormClosing(object sender, FormClosingEventArgs e) {
            custList.Save(custList);
        }

        /**************************************************
        *  fill in text boxes and radio button when customer selected from listview  
        *************************************************/
        private void lsvCustomers_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.lsvCustomers.SelectedItems.Count > 0) {
                txtAcctNo.Text = lsvCustomers.SelectedItems[0].SubItems[0].Text;
                txtCustomer.Text = lsvCustomers.SelectedItems[0].SubItems[1].Text;
                switch (Convert.ToChar(lsvCustomers.SelectedItems[0].SubItems[2].Text)) {
                    case 'R':
                        radResidential.Checked = true;
                        break;
                    case 'C':
                        radCommercial.Checked = true;
                        break;
                    case 'I':
                        radIndustrial.Checked = true;
                        break;
                }
                txtCost.Text = lsvCustomers.SelectedItems[0].SubItems[3].Text;
            }
        }

        /**************************************************
        *  checks to see if customer id exists in the list
        *************************************************/
        private bool custExists(int id) {
            foreach (Customer c in custList) {
                if (c.Id == id) {
                    return true;
                }
            }
            return false;
        }

        /**************************************************
        * returns index of customer id in list if it exists or -1 if absent  
        *************************************************/
        private int IndexAt(int id) {
            int index = 0;
            foreach (Customer c in custList) {
                if (c.Id == id) {
                    return index;
                }
                index++;
            }
            return -1;
        }
        /**************************************************
         * triggers on text change for account id to enable/disable radio buttons
         * as user cannot make changes to customer type  
         *************************************************/
        private void txtAcctNo_TextChanged(object sender, EventArgs e) {
            int id = -1;
            if (txtAcctNo.Text != "") {
                id = Convert.ToInt32(txtAcctNo.Text);
            }
            if (custExists(id) == true) {
                radResidential.Enabled = false;
                radCommercial.Enabled = false;
                radIndustrial.Enabled = false;
                txtCustomer.Text = custList.ElementAt(IndexAt(id)).Name;
            } else {
                radResidential.Enabled = true;
                radCommercial.Enabled = true;
                radIndustrial.Enabled = true;
                txtCustomer.Text = "";
                txtCost.Text = "";
            }
        }
    }
}
