using ALT_R_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace ALT_R_Management_Library.Api
{
    public class MyApiProcessor
        
    {
       
        public static async Task<PrisonerModel> LoadPrisonerByID(int id)
        {
            var uri = $"http://localhost:49574/api/prisoner/gbid/{ id }/";
            using (HttpResponseMessage responseMessage=await ApiHelper.MyApiClient.GetAsync(uri))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    PrisonerModel prisoner = await responseMessage.Content.ReadAsAsync<PrisonerModel>();
                    return prisoner;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
        public static async Task<IEnumerable<PrisonerModel>> LoadPrisonerData()
        {
            var uri = "http://localhost:49574/api/prisoner/ga";
            using (HttpResponseMessage responseMessage = await ApiHelper.MyApiClient.GetAsync(uri))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    IEnumerable<PrisonerModel> prisoner = await responseMessage.Content.ReadAsAsync<IEnumerable<PrisonerModel>>();
                    return prisoner;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public static async Task<HttpStatusCode> InsertPrisoner(string fname,string lname)
        {
            var uri = "http://localhost:49574/api/prisoner/postprisoner";

            var data = new PrisonerModel()
            {
                ID = 0,
                FirstName = fname,
                LastName = lname,
            };
            using (HttpResponseMessage responseMessage = await ApiHelper.MyApiClient.PostAsJsonAsync(uri,data))
            { 
                
                if (responseMessage.IsSuccessStatusCode)
                {
                    
                    return responseMessage.StatusCode;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
