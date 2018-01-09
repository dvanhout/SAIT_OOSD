/*  
 * 
 * Author: Don van Hout
 * Date: July 2017
 * Purpose:  Lab assignment 3, CPRG 214, SAIT OOSD, Spring 2017
 * Description:  IncidentDB contains methods for retrieving data from
 *               TechSupport.mdf database
 *  
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OpenIncidents {

    [DataObject(true)]
    public static class IncidentDB {

        // get incidents that are open (i.e. date closed is null)
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Incident> GetOpenTechIncidents(int techID) {
            List<Incident> openTechIncidents = new List<Incident>(); // empty list to return 
            Incident techIncident = null; // empty incident to build list
            SqlConnection connection = TechSupportDB.GetConnection(); // db connection

            string selectString = "SELECT Incidents.IncidentID, Customers.Name, Incidents.ProductCode, Incidents.TechID, " +
                                  "       Incidents.DateOpened, Incidents.DateClosed, Incidents.Title, Incidents.Description " +
                                  "FROM Incidents JOIN Customers " +
                                  "ON Incidents.CustomerID = Customers.CustomerID " +
                                  "WHERE Incidents.TechID = @TechID AND Incidents.DateClosed IS NULL " +
                                  "ORDER BY Incidents.DateOpened"; // get open incidents for tech Incidents.DateClosed IS NULL AND 

            SqlCommand selectCommand = new SqlCommand(selectString, connection);
            //selectCommand.Parameters.AddWithValue("@TechID", techID);
            SqlParameter param = new SqlParameter("@TechID", SqlDbType.Int);
            param.Value = techID;
            selectCommand.Parameters.Add(param);

            // try to connect and execute command
            try {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read()) { // get next row
                    techIncident = new Incident();
                    techIncident.IncidentID = (int)reader["IncidentID"];
                    techIncident.CustomerName = reader["Name"].ToString();
                    techIncident.ProductCode = reader["ProductCode"].ToString();
                    if (reader["TechID"] != DBNull.Value) { // check for null values
                        techIncident.TechID = (int)reader["TechID"]; 
                    } else { techIncident.TechID = null; }
                    techIncident.DateOpened = Convert.ToDateTime(reader["DateOpened"]);
                    if (reader["DateClosed"] != DBNull.Value) { // check for null values
                        techIncident.DateClosed = (DateTime)reader["DateClosed"];
                    } else { techIncident.DateClosed = null; }
                    techIncident.Title = reader["Title"].ToString();
                    techIncident.Description = reader["Description"].ToString();
                    
                    openTechIncidents.Add(techIncident); // build the list of open incidents
                }
                reader.Close(); // close the readre

            } catch (SqlException ex) { throw ex; } // throw exception to form
            finally { connection.Close(); }
            return openTechIncidents;
        } // end GetOpenTechIncidents
    }
}