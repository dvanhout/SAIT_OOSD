/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: Orders.cs builds OrderDetails objects to store
 *          database values
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders {
    public class OrderDetails {
        public OrderDetails() { }

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

    }
}
