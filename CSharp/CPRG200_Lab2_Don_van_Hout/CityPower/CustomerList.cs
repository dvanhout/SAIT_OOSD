/*
* Author:  Donald van Hout
* Created on:  June, 2017
* Purpose:  Lab 2 assignment for SAIT OOSD program
* 
* --- CustomerList.cs creates a list of Customer.cs items
*           
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CityPower {
    public class CustomerList : List<Customer> {
        private List<Customer> customers;

        // constructor
        public CustomerList() {
            customers = new List<Customer>();
        }

        // methods
        public new void Add(Customer c) => base.Add(c);

        // reads from a file using FileIO.cs to build a list of customers
        public void Fill() {
            List<Customer> customers = FileIO.LoadListFromFile();
            foreach (Customer customer in customers) {
                base.Add(customer);
            }
        }

        public void Save(CustomerList cl) => FileIO.SaveToFile(cl);

        public void RemoveListItem(Customer customer) { 
            customers.Remove(customer);
        }

        public void RemoveListItem(int id) {
            int index = 0;
            foreach (Customer c in customers) {
                if (c.Id == id) {
                    base.RemoveAt(index);
                }
                index++;
            }
        }

        // override the operator
        public static CustomerList operator +(CustomerList cl, Customer c) {
            cl.Add(c);
            return cl;
        }

        public static CustomerList operator -(CustomerList cl, Customer c) {
            cl.Remove(c);
            return cl;
        }
    }
}
