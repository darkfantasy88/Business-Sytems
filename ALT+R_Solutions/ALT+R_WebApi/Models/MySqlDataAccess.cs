using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ALT_R_WebApi.Models
{
    public class MySqlDataAccess
    {
        

        public static  IEnumerable<PrisonerModel> GetAllPrisoners()
        {
            var p=MySqlHelper.GetAllPrisoners("DB1");
            return p;
        }

        public static PrisonerModel GetAPrisonerByID(int id)
        {
            var p = MySqlHelper.GetPrisonerByID(id,"DB1");
            return p;
        }

        public static void CreatePrisoner(string firstName,string lastName)
        {
             MySqlHelper.InsertPrisoner(firstName,lastName,"DB1");
        }
    }
}