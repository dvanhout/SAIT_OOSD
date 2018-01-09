/*
 *  Author:         Don van Hout
 *  Date:           July 2017
 *  Purpose:        CPRG 214 Lab 4, SAIT OOSD 2017 (spring track)
 *  Description:    Webservice for getting customer incidents
 *                 
 */

using IncidentsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IncidentsService {
    public class IncidentService : IIncidentService {

        // gets incidents by customerID
        public List<Incident> GetCustomerIncidents(int customerID) {
            return IncidentDB.GetCustomerIncidents(customerID);
        }

        // overload...passing default to get all records
        public List<Incident> GetCustomerIncidents() {
            return IncidentDB.GetCustomerIncidents();
        }

        // gets all tech incidents by techID
        public List<Incident> GetOpenTechIncidents(int techID) {
            return IncidentDB.GetOpenTechIncidents(techID);
        }
    }
}
