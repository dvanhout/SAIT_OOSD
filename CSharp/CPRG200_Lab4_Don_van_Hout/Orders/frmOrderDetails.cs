/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: form displays data from for Orders and linked OrderDetails.
 *          Controls allow user to search for Orders and alter Shipping Dates
 *       
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orders {
    public partial class frmOrderDetails : Form {

        public DateTime? ShipDate { get; set; }

        List<OrderDetails> OrderDetailsList = new List<OrderDetails>(); // list for storing data from query

        public frmOrderDetails() {
            InitializeComponent();
        }

        // exits the program
        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        // show frmSearchOrder.cs on button click
        private void btnSearchOrders_Click(object sender, EventArgs e) {
            frmSearchOrder searchOrderForm = new frmSearchOrder(); // open form to search orders
            if (searchOrderForm.ShowDialog() == DialogResult.OK ) { // return results from search form
                // populate text boxes
                txtOrderID.Text = searchOrderForm.OrdId.ToString();
                txtCustomerID.Text = searchOrderForm.CustId;
                txtOrderDate.Text = GetDateString(searchOrderForm.OrdDate.Value);
                txtRequiredDate.Text = GetDateString(searchOrderForm.ReqDate.Value);
                txtShippedDate.Text = GetDateString(searchOrderForm.ShipDate);

                // uses ShipDate to send ship date to frmAlterShippingDates.cs
                ShipDate = searchOrderForm.ShipDate;
               
                // display to list box
                OrderDetailsList = OrderDetailsDB.GetOrderDetailsList(Convert.ToInt32(txtOrderID.Text));
                DisplayList(OrderDetailsList);

                // calculate sum of orders
                DisplayTotalOrders();

                // enable button to allow user to alter the ShippedDate of record
                btnAlterShipDate.Enabled = true;
            }
        }

        // when converting null value to DateTime, value will return as a very small value like: 0001/01/01
        // this block of code checks if this is the case and enters blank text into the 
        // text box rather than putting the ancient converted date 
        private string GetDateString(DateTime ? dt) {
            DateTime referenceDate = new DateTime(1900, 1, 1);
            int result;
            result = DateTime.Compare(Convert.ToDateTime(dt), referenceDate);
            if (result < 0) {
                return "";
            } else {
                return Convert.ToDateTime(dt).ToShortDateString();
            }
        }

        // displays sum of all orders
        private void DisplayTotalOrders() {
            decimal total = 0;
            foreach (OrderDetails o in OrderDetailsList) {
                total += o.UnitPrice * (1 - o.Discount) * o.Quantity;
            }
            txtOrderTotal.Text = total.ToString("c");
        }

        // displays list in listview 
        private void DisplayList(List<OrderDetails> odlist) {
            if (odlist.Count() == 0) { // there's nothing in the list
                MessageBox.Show("Nothing to display, nothing was found. Try searching again");
            } else {
                lsvOrderDetails.Items.Clear(); // first clear the list of old data
                foreach (OrderDetails o in odlist) {
                    string[] arr = new string[5]; // create array for order data
                    arr[0] = o.ProductID.ToString();
                    arr[1] = o.UnitPrice.ToString();
                    arr[2] = o.Quantity.ToString();
                    arr[3] = o.Discount.ToString();
                    ListViewItem itm;
                    itm = new ListViewItem(arr);
                    lsvOrderDetails.Items.Add(itm); // generate list
                }
            }
        }

        // show frmAlterShippingDates.cs on button click
        private void btnAlterShipDate_Click(object sender, EventArgs e) {
            if (txtOrderID.Text != "") { // if there's a record, then execute code below
                string oldDate = txtShippedDate.Text; // store old date in case there's a problem in execution 

                frmAlterShippingDate alterShippingDateForm = new frmAlterShippingDate(txtShippedDate.Text); // create a new form to alter shipping date
                if (alterShippingDateForm.ShowDialog() == DialogResult.OK) { // open the form
                    string newDate = alterShippingDateForm.ShipDate; // get result from user

                    // check to see if shipping date is within range before changes
                    if (Convert.ToDateTime(newDate) >= Convert.ToDateTime(txtOrderDate.Text)
                        && Convert.ToDateTime(newDate) <= Convert.ToDateTime(txtRequiredDate.Text)
                        || alterShippingDateForm.EnterNullShipDate) {


                        // run update query  
                        if (OrderDB.UpdateShippedDate(newDate, Convert.ToInt32(txtOrderID.Text))) {
                            MessageBox.Show("Successfully updated ShippingDate for order with ID: " + txtOrderID.Text);
                            txtShippedDate.Text = newDate;
                        } else { // query failed, show error
                            MessageBox.Show("There was an error updating Shipping Date, please try again");
                            txtShippedDate.Text = oldDate;
                        }

                    } else { // user shipping date is out of range
                        MessageBox.Show("The ShippedDate is not in range.  Please enter OrderDate <= ShippedDate <= RequiredDate");
                    }
                }

            } else {
                MessageBox.Show("No record to change. Search for a record before altering Shipping Date");
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e) {

        }
    }
}
