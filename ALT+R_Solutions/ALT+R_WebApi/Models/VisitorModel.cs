using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALT_R_WebApi.Models
{
    public class VisitorModel
    {
        public int VisitorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public VisitorType VisitorType { get; set; }
        public DateTime DateOfVisit { get; set; }
        public int MonthlyVisits { get; set; }
        public int PrisonerID { get; set; }
    }

    public enum VisitorType
    {
        Relative,General
    }
}