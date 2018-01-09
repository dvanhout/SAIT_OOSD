/*  
 * 
 * Author: Don van Hout
 * Date: July 2017
 * Purpose:  Lab assignment 3, CPRG 214, SAIT OOSD, Spring 2017
 * Description:  TechnicianDB contains methods for retrieving Technician 
 *               data from TechSupport.mdf database
 *  
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OpenIncidents {

    [DataObject(true)]
    public static class TechnicianDB {

        // gets list of technicians from database
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Technician> GetAllTechnicians() {
            List<Technician> technicians = new List<Technician>(); // empty list for return
            Technician technician; 
            
            SqlConnection connection = TechSupportDB.GetConnection(); // DB connection

            // create select command
            string selectString = "SELECT TechID, Name, Email, Phone " +
                                  "FROM Technicians " +
                                  "ORDER BY Name";
            SqlCommand selectCommand = new SqlCommand(selectString, connection);
            
            // try to connect and execute command
            try {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read()) { // get next row
                    technician = new Technician((int)reader["TechID"],
                                                reader["Name"].ToString(),
                                                reader["Email"].ToString(),
                                                reader["Phone"].ToString());
                    technicians.Add(technician); // build the list
                }
                reader.Close(); // close the reader

            } catch (SqlException ex) { throw ex; } // throw exception to form
            finally { connection.Close(); }
            return technicians;
        } // end GetAllTechnicians
    }
}