/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: form allows user to search for Order records in various ways
 *          and then select a record to populate form: frmOrderDetails
 *       
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orders {
    public partial class frmSearchOrder : Form {

        const int MAX_VALUE_LENGTH = 5; // to protect against sql injection ... see wildcards on sql query for OrderDB.cs
        // list of orders used to fill display area
        List<Order> ordersList = new List<Order>();

        // data for frmOrderDetails.cs
        public int OrdId { get; set; }
        public string CustId { get; set; }
        public DateTime ? OrdDate { get; set; }
        public DateTime ? ReqDate { get; set; }
        public DateTime ? ShipDate { get; set; }

        public frmSearchOrder() {
            InitializeComponent();
        }

        // user cancelled search, close the form
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        // calls SearchBoxesEnableDisable when selection changed on combo box
        private void comboSearchBy_SelectedValueChanged(object sender, EventArgs e) {
            SearchBoxesEnableDisable();
        }

        // enable or disable appropriate search values
        private void SearchBoxesEnableDisable() {
            switch (comboSearchBy.Text) {
                case "OrderID":
                case "CustomerID":
                    txtValue.Enabled = true;
                    dtpFrom.Enabled = false;
                    dtpTo.Enabled = false;
                    lblTipText.Text = "Enter whole or partial Value to search";
                    break;
                case "OrderDate":
                case "RequiredDate":
                case "ShippedDate":
                    txtValue.Enabled = false;
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                    lblTipText.Text = "Select a range of dates to search";
                    break;
            }
        }

        // upon selection in listview, enable okay button
        private void lsvOrders_SelectedIndexChanged(object sender, EventArgs e) {
            btnOk.Enabled = true;
            lblTipText.Text = "Click OK to finish";
        }

        // set ordId to selected item to send OrderID value to frmOrderDetails.cs
        private void btnOk_Click(object sender, EventArgs e) {
            // send selected data to frmOrderDetails
            if (this.lsvOrders.SelectedItems.Count > 0) { 
                OrdId = Convert.ToInt32(lsvOrders.SelectedItems[0].SubItems[0].Text);
                CustId = lsvOrders.SelectedItems[0].SubItems[1].Text;
                if (lsvOrders.SelectedItems[0].SubItems[2].Text != "") { 
                    OrdDate = Convert.ToDateTime(lsvOrders.SelectedItems[0].SubItems[2].Text);
                }
                if (lsvOrders.SelectedItems[0].SubItems[3].Text != "") {
                    ReqDate = Convert.ToDateTime(lsvOrders.SelectedItems[0].SubItems[3].Text);
                }
                if (lsvOrders.SelectedItems[0].SubItems[4].Text != "") {
                    ShipDate = Convert.ToDateTime(lsvOrders.SelectedItems[0].SubItems[4].Text);
                }
            }
            this.Close();
        }

        // validates search text fields, calls for queries, and display results
        private void btnSearch_Click(object sender, EventArgs e) {
            if ((comboSearchBy.Text == "OrderID" || comboSearchBy.Text == "CustomerID")
                    && txtValue.Text == "") {
                MessageBox.Show("There is no value, please enter a value and try again", "No Value",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValue.Focus();
            } else { 
            switch (comboSearchBy.Text) {
                case "OrderID":
                    Regex regex = new Regex(@"^\d{1,5}");
                    if (regex.IsMatch(txtValue.Text)) {
                        try {
                            ordersList = OrderDB.GetOrderByOrderID(txtValue.Text);
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    } else {
                        MessageBox.Show("Invalid value for: " + comboSearchBy.Text +
                                         ", please enter a valid " + comboSearchBy.Text);
                    }
                    break;
                case "CustomerID":
                        if (txtValue.Text.Length <= MAX_VALUE_LENGTH)  
                            ordersList = OrderDB.GetOrderListByCustomerID(txtValue.Text);
                        break;
                        
                    case "OrderDate": // GetOrderListByOrderDateRange() returns list of Order Objects
                case "RequiredDate":
                case "ShippedDate":
                    if (Convert.ToDateTime(dtpFrom.Text) <= Convert.ToDateTime(dtpTo.Text)) { 
                        ordersList = OrderDB.GetOrderListByDateRange(
                                     comboSearchBy.Text, dtpFrom.Text.Replace("-", ""), 
                                     dtpTo.Text.Replace("-", ""));
                        break;
                    } else {
                        MessageBox.Show("The date range is invalid, please choose a valid date range (fromDate <= toDate)");
                        dtpFrom.Focus();
                        break;
                    }
                }
            }
            // display listview from order list
            DisplayList(ordersList);
        }

        /* 
         * Display list to lsvOrders list view 
         */
        private void DisplayList(List<Order> ol) {
            if (ol.Count() == 0) {
                MessageBox.Show("No data was found. Try searching again");
            } else {
                lsvOrders.Items.Clear(); // first clear the list
                foreach (Order o in ol) {
                    string[] arr = new string[5]; // create array for order data
                    arr[0] = o.OrderID.ToString();
                    arr[1] = o.CustomerID;
                    arr[2] = Regex.Replace(o.OrderDate.ToString(), "(0[1-9]|1[0-2]):[0-5][0-9]:[0-5][0-9] (AM|PM)$", "");
                    arr[3] = Regex.Replace(o.RequiredDate.ToString(), "(0[1-9]|1[0-2]):[0-5][0-9]:[0-5][0-9] (AM|PM)$", "");
                    arr[4] = Regex.Replace(o.ShippedDate.ToString(), "(0[1-9]|1[0-2]):[0-5][0-9]:[0-5][0-9] (AM|PM)$", "");
                    ListViewItem itm;
                    itm = new ListViewItem(arr);
                    lsvOrders.Items.Add(itm);
                    lblTipText.Text = "Select an item from the list below";
                }
            }
        }

        private void frmSearchOrder_Load(object sender, EventArgs e) {
            // set combo box to first item by default
            lblTipText.Text = "Choose 'Search By' method";
            comboSearchBy.SelectedIndex = 0;
        }
    }
}
