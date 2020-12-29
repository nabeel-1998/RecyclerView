using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject_PU.Helper
{
    class Data
    {
        public string IssueImage { get; set; }
        public string UserImage { get; set; }
        public string UserName { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueStatement { get; set; }


        public int GetElevatedDates()
        {
            var ElevatedDays = (IssueDate.Date - DateTime.Now.Date).Days;
            return ElevatedDays;
        }

        public string ElevatedDays
        {
            get { return ElevatedDays; }
            set
            {
                if (GetElevatedDates() == 0)
                {
                    ElevatedDays = "Today";
                }
                else
                {
                    ElevatedDays = GetElevatedDates() + "Days";
                }
            }
        }
    }
}