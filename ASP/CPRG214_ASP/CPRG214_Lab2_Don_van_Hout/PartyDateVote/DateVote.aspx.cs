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
    public partial class DateVote : System.Web.UI.Page {

        // list of party dates
        DateTime date1 = new DateTime(2017, 07, 10);
        DateTime date2 = new DateTime(2017, 07, 17);
        DateTime date3 = new DateTime(2017, 07, 21);

        int day1Count, day2Count, day3Count;

        // load the variables and reset the labels
        protected void Page_Load(object sender, EventArgs e) {
            // set the calendar 'selectable' dates
            if (Application["day1Count"] != null)
                day1Count = (int)Application["day1Count"];
            if (Application["day2Count"] != null)
                day2Count = (int)Application["day2Count"];
            if (Application["day3Count"] != null)
                day3Count = (int)Application["day3Count"];

            lblError.Text = ""; // reset error message if needed
            lblMessage.Text = "";
        }

        // increment dates based on selected date
        protected void btnSubmit_Click(object sender, EventArgs e) {
            // check for selected date and increment appropriate date count
            if (calDate.SelectedDate == date1) {
                day1Count++;
                Application["day1Count"] = day1Count;
            } else if (calDate.SelectedDate == date2) {
                day2Count++;
                Application["day2Count"] = day2Count;
            } else if (calDate.SelectedDate == date3) { 
                day3Count++;
                Application["day3Count"] = day3Count;
            } else { // no date selected don't submit... return to this page
                lblError.Text = "No date selected, please choose a date and resubmit";
                return;
            }
            // go to results display page
            Response.Redirect("~/Results.aspx");
        }

        protected void calDate_SelectionChanged(object sender, EventArgs e) {         
            lblMessage.Text = "Your date choice: " + calDate.SelectedDate.ToShortDateString();
            lblError.Text = "";
        }

        protected void calDate_DayRender(object sender, DayRenderEventArgs e) {
            // set party dates to selectable dates and highlight
            if ((e.Day.Date != date1) &
                (e.Day.Date != date2) &
                (e.Day.Date != date3)) {
                e.Day.IsSelectable = false;
            } else {
                e.Cell.BackColor = System.Drawing.Color.White;
                e.Cell.ForeColor = System.Drawing.Color.Blue;
            }
        }
    }
}