using ALT_R_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ALT_R_WebApi.Controllers
{
    public class PrisonerController : ApiController
    {
        List<PrisonerModel> prisoners = new List<PrisonerModel>()
        { new PrisonerModel() {ID=12, FirstName="Rohan",LastName="Cooper" },
            new PrisonerModel() {ID=42, FirstName="Avianna",LastName="Williams" },
        new PrisonerModel() {ID=223, FirstName="Toni-Ann",LastName="Wright" },
        new PrisonerModel() {ID=34, FirstName="Lilli-Ann",LastName="Longmore" }};
      
        // GET: api/Prioner
        [Route("api/prisoner/ga")]
        [HttpGet]
        public IEnumerable<PrisonerModel> GetAll()
        {
            //return prisoners;
            return MySqlDataAccess.GetAllPrisoners();
            
        }

        // GET: api/Prioner/5
        [Route("api/prisoner/gbid/{id}")]
        [HttpGet]
        public PrisonerModel GetByID(int id)
        {
            //return prisoners.Where(id_=> id_.ID==id).FirstOrDefault();
            return MySqlDataAccess.GetAPrisonerByID(id);
        }

        // POST: api/Prioner
        [HttpPost]
        [Route("api/prisoner/postprisoner")]
        public void PostPrisoner([FromBody]PrisonerModel model)
        {
            //prisoners.Add(value);
            MySqlDataAccess.CreatePrisoner(model.FirstName, model.LastName);
        }

        // PUT: api/Prioner/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prioner/5
        [HttpDelete]
        public void Delete(int id)
        {
            prisoners.Remove(prisoners.Where(p => p.ID == id).FirstOrDefault());
        }
    }
}
