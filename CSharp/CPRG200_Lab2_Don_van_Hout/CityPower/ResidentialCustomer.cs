/*
* Author:  Donald van Hout
* Created on:  June, 2017
* Purpose:  Lab 2 assignment for SAIT OOSD program
* 
* --- ResidentialCustomer.cs class inherits from Customer.cs class
*       Calculations are specific to type of customer 
*           
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPower {

    public class ResidentialCustomer : Customer {
        // constants
        const decimal RESIDENTIAL_BASE_RATE = 6.00m; // base rate for residential
        const decimal RESIDENTIAL_HOUR_RATE = 0.052m; // hourly rate for residential

        // fields
        private decimal bill; // amount of bill

        // properties
        public decimal Bill {
            get { return bill; }
            set { bill = value; }
        }

        // statistic
        public static decimal SumR { get; private set; }

        // constructors
        public ResidentialCustomer() { }

        // when bill is known, but hrs are not
        public ResidentialCustomer(int i, string n, char t, decimal b) : base(i, n, t) {
            Bill = b;
        }

        // when hrs are know, bill is derived
        public ResidentialCustomer(int i, string n, char t, int hrs) : base (i, n, t) {
            // residential pricing has base rate from 0 hrs
           calcRCustomer(hrs);
        }

        // calculate bill using residential rates
        public void calcRCustomer(int hrs) {
            decimal price = RESIDENTIAL_BASE_RATE + RESIDENTIAL_HOUR_RATE * hrs; // return value for calculation
            Bill = price;
        }
        public override string ToString() {
            return base.Id + "," + base.Name + "," + Type.ToString() + "," + "$" + Bill.ToString("f2");
        }
    }
}
