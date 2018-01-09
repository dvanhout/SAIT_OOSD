/*
 *  Author:         Don van Hout
 *  Date:           July 2017
 *  Purpose:        CPRG 214 Lab 4, SAIT OOSD 2017 (spring track)
 *  Description:    
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IncidentsService {
    [ServiceContract]
    public interface IIncidentService {
        [OperationContract]
        List<Incident> GetOpenTechIncidents(int techID);

        // passing customerID - requires a name
        [OperationContract(Name = "GetCustomerIncidentsByID")]
        List<Incident> GetCustomerIncidents(int customerID);

        // overload - default 'null' value 
        [OperationContract(Name ="GetAllCustomerIncidents")]
        List<Incident> GetCustomerIncidents();
    }

    // incident class
    public class Incident {
        [DataMember]
        public int IncidentID { get; set; }

        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public int ? TechID { get; set; }

        [DataMember]
        public DateTime DateOpened { get; set; }

        [DataMember]
        public DateTime ? DateClosed { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
