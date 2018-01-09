/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: OrderDetailsDB.cs contains methods that 
 *          query the database and return results
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders {
    class OrderDetailsDB {
        // select query returns order details for a particular OrderID and returns a list
        public static List<OrderDetails> GetOrderDetailsList(int orderID) {
            List<OrderDetails> ODList = new List<OrderDetails>();
            OrderDetails od;
            SqlConnection con = NorthwndDb.GetConnection();
            string selectStatement = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount " +
                                     "FROM [Order Details] " +
                                     "WHERE OrderID = @OrderID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, con);
            selectCommand.Parameters.AddWithValue("@OrderID", orderID);
            try {
                con.Open();
                SqlDataReader ordReader = selectCommand.ExecuteReader();
                while (ordReader.Read()) {
                    od = new OrderDetails();
                    od.OrderID = (int)ordReader["OrderID"];
                    od.ProductID = (int)ordReader["ProductID"];
                    od.UnitPrice = (decimal)ordReader["UnitPrice"];
                    od.Quantity = Convert.ToInt32(ordReader["Quantity"]);
                    od.Discount = Convert.ToDecimal(ordReader["Discount"]);
                    ODList.Add(od);
                }
            } catch (SqlException ex) {
                throw ex;
            } finally {
                con.Close();
            }
            return ODList;
        }
    }
}
