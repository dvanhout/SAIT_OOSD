using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPRG200_Lab3_Don_van_Hout {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            try {
                this.productsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.nORTHWNDDataSet);

            } catch (DBConcurrencyException) {
                MessageBox.Show("Another user changed or deleted data.  Try again");
                // refresh the dataset from the database
                this.productsTableAdapter.Fill(this.nORTHWNDDataSet.Products);

            } catch (SqlException ex) {
                MessageBox.Show(ex.GetType().ToString() + ": " + ex.Message);

            } catch (Exception ex) {
                MessageBox.Show(ex.GetType().ToString() + ": " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nORTHWNDDataSet.Order_Details' table. You can move, or remove it, as needed.
            this.order_DetailsTableAdapter.Fill(this.nORTHWNDDataSet.Order_Details);
            // TODO: This line of code loads data into the 'nORTHWNDDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.nORTHWNDDataSet.Categories);
            // TODO: This line of code loads data into the 'nORTHWNDDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.nORTHWNDDataSet.Suppliers);
            // TODO: This line of code loads data into the 'nORTHWNDDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.nORTHWNDDataSet.Products);

        }

        private void order_DetailsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            int row = e.RowIndex + 1; // row number in human-speak
            int col = e.ColumnIndex;
            string message = "Incorrect data in column ";
            switch (col) {
                case 0:
                    message += "OrderID";
                    break;
                case 1:
                    message += "ProductID";
                    break;
                case 2:
                    message += "UnitPrice";
                    break;
                case 3:
                    message += "Quantity";
                    break;
                case 4:
                    message += "Discount";
                    break;
                default: break;

            }
            message += " in " + row + " row.";
            MessageBox.Show(message);
        }

    }
}
