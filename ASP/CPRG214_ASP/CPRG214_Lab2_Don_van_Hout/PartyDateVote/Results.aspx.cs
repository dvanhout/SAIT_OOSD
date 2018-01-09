// Author: Don van Hout
// Created:  July 2017
// For:  CPRG214 - Lab2 - OOSD - SAIT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyDateVote {

    public partial class Results : System.Web.UI.Page {
        // variables for day tallys
        int day1Tally, day2Tally, day3Tally;

        // display tally's
        protected void Page_Load(object sender, EventArgs e) {    
            if (Application["day1Count"] != null) {
                day1Tally = (int)Application["day1Count"];
                lblDay1Tally.Text = day1Tally.ToString();
            }
            if (Application["day2Count"] != null) {
                day2Tally = (int)Application["day2Count"];
                lblDay2Tally.Text = day2Tally.ToString();
            }
            if (Application["day3Count"] != null) {
                day3Tally = (int)Application["day3Count"];
                lblDay3Tally.Text = day3Tally.ToString();
            }
        }
    }
}