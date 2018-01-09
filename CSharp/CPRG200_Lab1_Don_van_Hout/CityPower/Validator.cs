using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityPower {
    public static class Validator {

        /**************************************************
         *  Check that field is not empty
         **************************************************/
        public static bool IsPresent(TextBox textBox, string name) {
            if (textBox.Text == "") {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        /**************************************************
         *  Check that field is an integer
         **************************************************/
        public static bool IsInt32(TextBox textBox, string name) {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number)) {
                return true;
            } else {
                MessageBox.Show(name + " must be a whole number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        /**************************************************
         *  Check that field is a positive (type: Int)
         **************************************************/
        public static bool IsPositiveInt(TextBox textBox, string name) {
            int number = Convert.ToInt32(textBox.Text);
            if (number < 0) {
                MessageBox.Show(name + " must be positive");
                textBox.Focus();
                return false;
            }
            return true;
        }
    }
}
