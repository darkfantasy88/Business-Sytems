using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ALT_R_Management_Library.Api
{
    public static class ApiHelper
    {
        public static HttpClient MyApiClient { get; set; }

        public static void InitializeClient()
        {
            MyApiClient = new HttpClient();
            //MyApiClient.BaseAddress = new Uri("http://localhost:49574/");
            MyApiClient.DefaultRequestHeaders.Clear();
            MyApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
