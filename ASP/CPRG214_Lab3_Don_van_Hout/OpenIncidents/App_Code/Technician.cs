/*  
 * 
 * Author: Don van Hout
 * Date: July 2017
 * Purpose:  Lab assignment 3, CPRG 214, SAIT OOSD, Spring 2017
 * Description:  Technician Class
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenIncidents {
    public class Technician {
        public int TechID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // empty constructor
        public Technician() { }

        // constructor with values
        public Technician(int techID, string name, string email, string phone) {
            TechID = techID;
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}