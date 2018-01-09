/*  
 * 
 * Author: Don van Hout
 * Date: July 2017
 * Purpose:  Lab assignment 3, CPRG 214, SAIT OOSD, Spring 2017
 * Description:  Main connection string for establishing connection
 *               to TechSupport.mdf Database
 *  
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OpenIncidents {
    public class TechSupportDB {
        // get connection from database
        public static SqlConnection GetConnection() {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}