/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: OrderDB.cs contains methods to run SQL queries on 
 *              the Northwind Database
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orders {
    public static class OrderDB {

        // Updates the ShippedDate field of the Order table, return success or failure bool
        public static bool UpdateShippedDate(string ShippedDate, int orderID) {
            SqlConnection con = NorthwndDb.GetConnection();
            string updateStatement = "UPDATE Orders " +
                                     "SET ShippedDate = @ShippedDate " +
                                     "WHERE OrderID = @OrderID";
            SqlCommand updateCommand = new SqlCommand(updateStatement, con);
            updateCommand.Parameters.AddWithValue("@ShippedDate", ShippedDate ?? Convert.DBNull); 
            updateCommand.Parameters.AddWithValue("@OrderID", orderID);
            try {
                con.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0) { return true; }
                else { return false; }
            } catch (SqlException ex) {
                throw ex;
            } finally {
                con.Close();
            }
        }

        // get order by orderID, return list of records
        public static List<Order> GetOrderByOrderID(string orderID) {
            List<Order> orderList = new List<Order>();
            Order ord;
            SqlConnection con = NorthwndDb.GetConnection();
            string selectStatement = "SELECT OrderID, CustomerID, OrderDate, RequiredDate, ShippedDate " +
                                     "FROM Orders " +
                                     "WHERE OrderID LIKE @OrderID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, con);
            selectCommand.Parameters.AddWithValue("@OrderID", orderID + "%"); //use SQL wildcard to match partial string, sql injection handled at form level
            try {
                con.Open();
                SqlDataReader ordReader = selectCommand.ExecuteReader();
                while (ordReader.Read()) {
                    ord = new Order();
                    ord.OrderID = (int)ordReader["OrderID"];
                    ord.CustomerID = ordReader["CustomerID"].ToString(); 
                    if (ordReader["OrderDate"] != DBNull.Value) { // handle null values
                        ord.OrderDate = (DateTime)ordReader["OrderDate"];
                    } else { ord.OrderDate = null; }
                    if (ordReader["RequiredDate"] != DBNull.Value) {
                        ord.RequiredDate = (DateTime)ordReader["RequiredDate"];
                    } else { ord.RequiredDate = null; }
                    if (ordReader["ShippedDate"] != DBNull.Value) {
                        ord.ShippedDate = Convert.ToDateTime(ordReader["ShippedDate"].ToString());
                    } else { ord.ShippedDate = null; }
                    orderList.Add(ord); // add order to list
                }
            } catch (SqlException ex) {
                throw ex;
            } finally {
                con.Close();
            }
            return orderList;
        } 
        
        // get order by CustomerID, return a list of records
        public static List<Order> GetOrderListByCustomerID(string customerID) {
            List<Order> orderList = new List<Order>();
            SqlConnection con = NorthwndDb.GetConnection();
            Order ord;
            string selectStatement = "SELECT OrderID, CustomerID, OrderDate, RequiredDate, ShippedDate " +
                                     "FROM Orders " +
                                     "WHERE CustomerID LIKE @CustomerID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, con);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID + "%"); // wilcard for partial strings, sql injection handled at form level
            try {
                con.Open();
                SqlDataReader ordReader = selectCommand.ExecuteReader();
                while (ordReader.Read()) {
                    ord = new Order();
                    ord.OrderID = (int)ordReader["OrderID"];
                    ord.CustomerID = ordReader["CustomerID"].ToString();
                    if (ordReader["OrderDate"] != DBNull.Value) {
                        ord.OrderDate = (DateTime)ordReader["OrderDate"];
                    } else { ord.OrderDate = null; }
                    if (ordReader["RequiredDate"] != DBNull.Value) {
                        ord.RequiredDate = (DateTime)ordReader["RequiredDate"];
                    } else { ord.RequiredDate = null; }
                    if (ordReader["ShippedDate"] != DBNull.Value) {
                        ord.ShippedDate = Convert.ToDateTime(ordReader["ShippedDate"].ToString());
                    } else { ord.ShippedDate = null; }
                    orderList.Add(ord); // add order to list
                }
            } catch (SqlException ex) {
                throw ex;
            } finally {
                con.Close();
            }
            return orderList;
        } // end GetOrderListByCustomerID()


        // get a list of orders by dateType ... @dateType must be OrderDate, RequiredDate, or ShippedDate
        public static List<Order> GetOrderListByDateRange(string dateType, string fromDate, string toDate) {
            List<Order> orderList = new List<Order>();
            Order ord;
            SqlConnection con = NorthwndDb.GetConnection();
            string selectStatement = "SELECT OrderID, CustomerID, OrderDate, RequiredDate, ShippedDate " +
                                     "FROM Orders " +
                                     "WHERE " + dateType + " BETWEEN @fromDate AND @toDate";
            SqlCommand selectCommand = new SqlCommand(selectStatement, con);
            selectCommand.Parameters.AddWithValue("@fromDate", fromDate);
            selectCommand.Parameters.AddWithValue("@toDate", toDate);
            try {
                con.Open();
                SqlDataReader ordReader = selectCommand.ExecuteReader();
                while (ordReader.Read()) {
                    ord = new Order();
                    ord.OrderID = (int)ordReader["OrderID"];
                    ord.CustomerID = ordReader["CustomerID"].ToString();
                    if (ordReader["OrderDate"] != DBNull.Value) {
                        ord.OrderDate = (DateTime)ordReader["OrderDate"];
                    } else { ord.OrderDate = null; }
                    if (ordReader["RequiredDate"] != DBNull.Value) {
                        ord.RequiredDate = (DateTime)ordReader["RequiredDate"];
                    } else { ord.RequiredDate = null; }
                    if (ordReader["ShippedDate"] != DBNull.Value) {
                        ord.ShippedDate = Convert.ToDateTime(ordReader["ShippedDate"].ToString());
                    } else { ord.ShippedDate = null; }
                    orderList.Add(ord); // add order to list
                }
            } catch (SqlException ex) {
                throw ex;
            } finally {
                con.Close();
            }
            return orderList;
        }
    }
}
