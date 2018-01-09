/*  
 * 
 * Author: Don van Hout
 * Date: July 2017
 * Purpose:  Lab assignment 3, CPRG 214, SAIT OOSD, Spring 2017
 * Description:  Incident class
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenIncidents {
    public class Incident {
        // fields
        public int IncidentID { get; set; }
        public string CustomerName { get; set; }
        public string ProductCode { get; set; }
        public int ? TechID { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime ? DateClosed { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // empty constructor
        public Incident() { }

        // constructor with values
        public Incident(int incidentID, string customerName, string productCode, 
                        int techID, DateTime dateOpened, DateTime? dateClosed, 
                        string title, string description) {
            IncidentID = incidentID;
            CustomerName = customerName;
            ProductCode = productCode;
            TechID = techID; /* ?? -1 ?? */
            DateOpened = dateOpened;
            DateClosed = dateClosed /* ?? <somevalue> */;
            Title = title;
            Description = description;
        }
    }
}