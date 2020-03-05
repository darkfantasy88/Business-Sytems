using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALT_R_WebApi.Models
{
    public class PrisonerModel : IPrisonerModel
    {
        public int PrisonerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}