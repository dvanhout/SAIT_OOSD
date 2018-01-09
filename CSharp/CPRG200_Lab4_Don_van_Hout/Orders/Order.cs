/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: Order.cs is a class that defines an
 *      Order record from the Object table of the Northwind database
 *         
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders {
    public class Order {

        public Order() { }

        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public DateTime ? OrderDate { get; set; }

        public DateTime ? RequiredDate { get; set; }

        public DateTime ? ShippedDate { get; set; }
    }
}
