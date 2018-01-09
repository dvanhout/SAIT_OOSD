/*
 *  Author:         Don van Hout
 *  Date:           July 2017
 *  Purpose:        CPRG 214 Lab 4, SAIT OOSD 2017 (spring track)
 *  Description:    
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IncidentsService.Models {
    public static class IncidentDB {

        // returns connection string from configuration manager
        private static string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }


        // get all customer indcidents from Incidents table
        public static List<Incident> GetCustomerIncidents(int ? customerID = null) {
            List<Incident> incidentList = new List<Incident>();
            string selectStatement;
            if (customerID == null) { // default null value, get only customerID's
                selectStatement = "SELECT DISTINCT CustomerID FROM Incidents";

            } else { // get incidents based on CustomerID
                selectStatement = "SELECT IncidentID, CustomerID, ProductCode, " +
                                  "       TechID, DateOpened, DateClosed, Title, Description " +
                                  "FROM Incidents WHERE CustomerID=@CustomerID " +
                                  "ORDER BY CustomerID";
            }
            using (SqlConnection connection = new SqlConnection(GetConnectionString())) {
                using (SqlCommand command = new SqlCommand(selectStatement, connection)) {
                    connection.Open();
                    if (customerID != null) { // get data based on CustomerID
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        SqlDataReader reader = command.ExecuteReader();
                        Incident incident;
                        while (reader.Read()) {
                            incident = new Incident(); // create a new incident
                            incident.IncidentID = (int)reader["IncidentID"];
                            incident.CustomerID = (int)reader["CustomerID"];
                            incident.ProductCode = reader["ProductCode"].ToString();
                            if (reader["TechID"] != DBNull.Value) {
                                incident.TechID = (int)reader["TechID"];
                            } else { incident.TechID = null; }
                            incident.DateOpened = (DateTime)reader["DateOpened"];
                            if (reader["DateClosed"] != DBNull.Value) {
                                incident.DateClosed = (DateTime)reader["DateClosed"];
                            } else { incident.DateClosed = null; }
                            incident.Title = reader["Title"].ToString();
                            incident.Description = reader["Description"].ToString();
                            incidentList.Add(incident); // add to the list
                        }
                    } else { // default null value
                        //connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Incident incident;
                        while (reader.Read()) {
                            incident = new Incident();
                            incident.CustomerID = (int)reader["CustomerID"];
                            incidentList.Add(incident);
                        }
                    }
                } // command object gets recycled
            } // connection is closed
            return incidentList;
        }


        // Get all tech incidents that haven't been closed (e.g. DateClosed IS NULL)
        public static List<Incident> GetOpenTechIncidents(int techID) {
            List<Incident> incidentList = new List<Incident>();
            string selectStatement = "SELECT IncidentID, CustomerID, ProductCode, TechID, " +
                                     "       CONVERT(varchar(10), DateOpened, 106) as [DateOpened], " +
                                     "       CONVERT(varchar(10), DateClosed, 106) as [DateClosed], " +
                                     "       Title, Description " +
                                     "FROM Incidents WHERE TechID = @TechID " +
                                     "AND DateClosed IS NULL " +
                                     "ORDER BY DateOpened";
            using (SqlConnection connection = new SqlConnection(GetConnectionString())) {
                using (SqlCommand command = new SqlCommand(selectStatement, connection)) {
                    command.Parameters.AddWithValue("@TechID", techID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Incident incident;
                    while (reader.Read()) {
                        incident = new Incident(); // create a new incident
                        incident.IncidentID = (int)reader["IncidentID"];
                        incident.CustomerID = (int)reader["CustomerID"];
                        incident.ProductCode = reader["ProductCode"].ToString();
                        if (reader["TechID"] != DBNull.Value) {
                            incident.TechID = (int)reader["TechID"];
                        } else { incident.TechID = null; }
                        incident.DateClosed = (DateTime)reader["DateOpened"];
                        if (reader["DateClosed"] != DBNull.Value) {
                            incident.DateClosed = (DateTime)reader["DateClosed"];
                        } else { incident.DateClosed = null; }
                        incident.Title = reader["Title"].ToString();
                        incident.Description = reader["Description"].ToString();
                        incidentList.Add(incident); // add to the list
                    }
                } // command object gets recycled
            } // connection is closed
            return incidentList;
        }   
    }
}