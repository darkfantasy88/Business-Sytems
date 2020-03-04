using ALT_R_Management_Library.Api;
using ALT_R_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiHelper.InitializeClient();
            //Console.Write("What is your first name:");
            //var data = GetData(Console.ReadLine()).Result;
            var data = GetData().Result;
            for (int i = 0; i < data.Count(); i++)
            {
                Console.WriteLine(data[i].ID);
                Console.WriteLine(data[i].LastName);
                Console.WriteLine(data[i].FirstName);
                Console.WriteLine("----------------------------------");
            }
            Console.Read();


        }

        static async Task<PrisonerModel> GetData(string fname)
        {
            var prioners= await MyApiProcessor.LoadData(fname);

            return prioners;
        }
        static async Task<IList<PrisonerModel>> GetData()
        {
            var prioners = await MyApiProcessor.LoadData();

            return prioners.ToList();
        }

    }
}
