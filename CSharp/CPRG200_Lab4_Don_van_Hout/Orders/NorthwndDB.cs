/*
 * Lab 4, CPRG200, SAIT OOSD Program
 * Date:  June 2017
 * Author: Don van Hout
 *      Description: NorthwndDB.cs is used to connect to the
 *      Northwind database        
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders {
    public static class NorthwndDb {
        public static SqlConnection GetConnection() {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\northwnd.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}