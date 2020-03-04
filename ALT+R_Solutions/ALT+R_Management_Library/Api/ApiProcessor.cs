using ALT_R_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ALT_R_Management_Library.Api
{
    public class MyApiProcessor
        
    {
       
        public static async Task<PrisonerModel> LoadData(string firstname)
        {
            var uri = $"http://localhost:49574/api/prisoner/gfn/{ firstname }/";
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
        public static async Task<IEnumerable<PrisonerModel>> LoadData()
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
    }
}
