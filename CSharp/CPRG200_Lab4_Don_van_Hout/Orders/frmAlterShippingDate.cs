/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: form that allows user to make changes to 
 *          the ShippingDate field for a particular Order 
 *          in the Orders table of the Northwind Database
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
    public partial class frmAlterShippingDate : Form {

        public string ShipDate { get; set; }
        public bool EnterNullShipDate { get; set; }

        public frmAlterShippingDate(string shippingDate) {
            InitializeComponent();
            if (shippingDate == "") {
                dtpShippedDate.Format = DateTimePickerFormat.Custom;
                dtpShippedDate.CustomFormat = " ";
            } else { dtpShippedDate.Text = shippingDate; }
        }

        // cancel without making any changes
        private void btnChangeDateCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        // alter shipping date on click
        private void btnChangeDate_Click(object sender, EventArgs e) {
            if (chkEnterNullValue.Checked == true) {
                ShipDate = null;
                EnterNullShipDate = true;
            }
            else { 
                ShipDate = dtpShippedDate.Value.ToShortDateString();
                EnterNullShipDate = false;
            }
        }

        private void frmAlterShippingDate_Load(object sender, EventArgs e) {
        }

        private void chkEnterNullValue_CheckedChanged(object sender, EventArgs e) {
            if (chkEnterNullValue.Checked == true) {
                dtpShippedDate.Visible = false;
            } else { dtpShippedDate.Visible = true; }
        }

        private void dtpShippedDate_ValueChanged(object sender, EventArgs e) {
            dtpShippedDate.Format = DateTimePickerFormat.Short;
        }
    }
}
