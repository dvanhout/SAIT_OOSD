/*
* Author:  Donald van Hout
* Created on:  June, 2017
* Purpose:  Lab 2 assignment for SAIT OOSD program
* 
* --- CommercialCustomer.cs inherits from Customer.cs.
*         Calculations are specific to type of customer  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPower {

    public class CommercialCustomer : Customer {
        // constants
        const decimal COMMERCIAL_BASE_RATE = 60.00m; // base rate for commercial
        const decimal COMMERCIAL_HOUR_RATE = 0.045m; // hourly rate for commercial

        // fields
        private decimal bill; // amount of bill

        // properties
        public decimal Bill {
            get { return bill; }
            set { bill = value; }
        }


        // constructors
        public CommercialCustomer() {
        }

        // when bill is known, but hrs are not
        public CommercialCustomer(int i, string n, char t, decimal b) : base(i, n, t) {
            Bill = b;
        }

        // when hrs are known, bill is derived
        public CommercialCustomer(int i, string n, char t, int hrs) : base(i, n, t) {
            calcCCustomer(hrs); // set customer bill
        }

        public override string ToString() {
            return base.Id + "," + base.Name + "," + Type.ToString() + "," + "$" + Bill.ToString("f2");
        }

        public void calcCCustomer(int hrs) {
            decimal price = COMMERCIAL_BASE_RATE; // return value for calculation
            if (hrs > BASE_HRS) {
                price += COMMERCIAL_HOUR_RATE * (hrs - BASE_HRS);
            }
            Bill = price;
        }
    }
}
