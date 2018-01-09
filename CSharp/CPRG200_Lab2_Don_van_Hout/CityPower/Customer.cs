/*
* Author:  Donald van Hout
* Created on:  June, 2017
* Purpose:  Lab 2 assignment for SAIT OOSD program
* 
* --- Customer.cs is the parent class of ResidentialCustomer.cs, CommercialCustomer.cs, & IndustrialCustomer.cs
*         
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPower {
    public class Customer {
        // constant
        public const int BASE_HRS = 1000; // base hours used in child classes
        
        // private data
        private int id; // customer id
        private string name; // customer name
        private char type; // type of customer

        // properties
        public int Id {
            get { return id; }
            set { id = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public char Type {
            get { return type; }
            set { type = value; }
        }

        // statistic
        public static int TotalCustomers { get; private set; }

        // constructors
        public Customer () {
        }
        
        public Customer (int i, string n, char t) {
            id = i;
            name = n;
            type = t;
            TotalCustomers++;
        }

    }
}
