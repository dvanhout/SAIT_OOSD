using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringDemo {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnSplit_Click(object sender, EventArgs e) {
            //string address; // full address
            string[] parts; // components of the address

            // separate address into components at the commas
            parts = txtAddress.Text.Split(',');

            // parts[0] is street address 
            parts[0] = parts[0].Replace(".", " "); // remove the dots
            parts[0] = parts[0].Replace("Str ", "Street ");
            parts[0] = parts[0].Replace("Ave ", "Avenue ");
            
            // parts[1] is city
            CultureInfo cf = Thread.CurrentThread.CurrentCulture;
            TextInfo tf = cf.TextInfo;
            parts[1] = tf.ToTitleCase(parts[1]);
            
            // parts[2] is prov
            parts[2] = parts[2].ToUpper();

            // display
            lblStreet.Text = parts[0];
            lblCity.Text = parts[1];
            lblProvince.Text = parts[2];


        }
    }
}
