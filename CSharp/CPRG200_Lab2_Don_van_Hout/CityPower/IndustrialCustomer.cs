/*
* Author:  Donald van Hout
* Created on:  June, 2017
* Purpose:  Lab 2 assignment for SAIT OOSD program
* 
* --- IndustrialCustomer.cs inherits from Customer.cs.
*         Calculations are specific to type of customer  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPower {

    public class IndustrialCustomer : Customer {
        // constants
        const decimal INDUSTRIAL_BASE_RATE_OFF = 40.00m; // base rate for OFFPEAK industrial
        const decimal INDUSTRIAL_HOUR_RATE_OFF = 0.028m; // hourly rate for OFFPEAK industrial
        const decimal INDUSTRIAL_BASE_RATE_PEAK = 76.00m; // base rate for PEAK industrial
        const decimal INDUSTRIAL_HOUR_RATE_PEAK = 0.065m; // hourly rate for PEAK industrial

        // fields
        private decimal bill; // amount of bill


        // properties
        public decimal Bill {
            get { return bill; }
            set { bill = value; }
        }

        // constructors
        // when bill is known, but hrs are not
        public IndustrialCustomer(int i, string n, char t, decimal b) : base(i, n, t) {
            Bill = b;
        }

        // when hrs are known, bill is derived from hours
        public IndustrialCustomer(int i, string n, char t, int hrs, int OP_hrs) : base(i, n, t) {
            calcICustomer(hrs, OP_hrs);
        }

        public void calcICustomer(int hrs, int OP_hrs) {
            // base industrial rate is off peak base rate + peak base rate, even at 0 kWh's
            decimal price = INDUSTRIAL_BASE_RATE_PEAK + INDUSTRIAL_BASE_RATE_OFF;

            // calculate price for peak hours over 1000
            if (hrs > BASE_HRS) {
                price += INDUSTRIAL_HOUR_RATE_PEAK * (hrs - BASE_HRS);
            }

            // calculate off peak hours over 1000
            if (OP_hrs > BASE_HRS) {
                price += INDUSTRIAL_HOUR_RATE_OFF * (OP_hrs - BASE_HRS);
            }
            Bill = price;
        }

        public override string ToString() {
            return base.Id + "," + base.Name + "," + Type.ToString() + "," + "$" + Bill.ToString("f2");
        }
    }
}
