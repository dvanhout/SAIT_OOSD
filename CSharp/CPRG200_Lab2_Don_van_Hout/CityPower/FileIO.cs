using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Author:  Donald van Hout
 * Created on:  June, 2017
 * Purpose:  Lab 2 assignment for SAIT OOSD program
 * 
 * --- FileIO.cs reads from and writes to an external file, storing a list of customers 
 */

namespace CityPower {
    public static class FileIO {
        static string fpath = "customers.txt"; // the path to the file's location

        /**************************************************
        *  reads from file to creates CustomerList
        *************************************************/
        public static List<Customer> LoadListFromFile() {
            FileStream fs;
            StreamReader sr = null;
            string line;
            string[] fields;
            int id;
            string name;
            char category;
            decimal bill;
            List<Customer> cl = new List<Customer>();
            // try to read from file
            try {
                fs = new FileStream(fpath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                while (!sr.EndOfStream) { // while more customers
                    line = sr.ReadLine();
                    fields = line.Split(',');
                    id = Convert.ToInt32(fields[0]);
                    name = fields[1];
                    category = Convert.ToChar(fields[2]);
                    bill = Convert.ToDecimal(fields[3]);

                    // create customer type based on category
                    if (category == 'R') {
                        ResidentialCustomer c = new ResidentialCustomer(id, name, category, bill);
                        cl.Add(c); // add to list
                    } else if (category == 'C') {
                        CommercialCustomer c = new CommercialCustomer(id, name, category, bill);
                        cl.Add(c);
                    } else if (category == 'I') {
                        IndustrialCustomer c = new IndustrialCustomer(id, name, category, bill);
                        cl.Add(c);
                    }
                }           
            // handle exceptions
            } catch (Exception ex) {
                MessageBox.Show("Error while reading customer data \n" + ex.GetType().ToString() + ": " + ex.Message);
            } finally {
                if (sr != null) { sr.Close(); }
            }
            return cl;
        }


        /**************************************************
        *  writes list of customers to file 
        *************************************************/
        public static void SaveToFile(List<Customer> cl) {
            FileStream fs;
            StreamWriter sw = null;
            string str;

            try {
                fs = new FileStream(fpath, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                foreach (Customer customer in cl) {
                    str = customer.ToString().Replace("$", ""); // strip $ from string when writing
                    sw.WriteLine(str);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error while writing customer data to file \n" + ex.GetType().ToString() + ": " + ex.Message);
            } finally {
                if (sw != null) {
                    sw.Close();
                }
            }
        }
    }
}
