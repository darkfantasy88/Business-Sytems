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
            CreatePrioners_STUPID();



            var data = GetData();
            for (int i = 0; i < data.Count(); i++)
            {
                Console.WriteLine(data[i].ID);
                Console.WriteLine(data[i].LastName);
                Console.WriteLine(data[i].FirstName);
                Console.WriteLine("----------------------------------");
            }
            Console.Read();


        }

        static void CreatePrioners_STUPID()
        {
            //for (int i = 0; i < 3; i++)
            //{
                Console.Write("First Name: ");
                var fname=Console.ReadLine();
                Console.Clear();
                Console.Write("Last Name: ");
                var lname = Console.ReadLine();
                InsertData(fname, lname);
            //}
        }

        static PrisonerModel GetData(int id)
        {
            var prioners= MyApiProcessor.LoadPrisonerByID(id).Result;

            return prioners;
        }
        static IList<PrisonerModel> GetData()
        {
            var prioners = MyApiProcessor.LoadPrisonerData().Result;

            return prioners.ToList();
        }

        static void InsertData(string fname,string lname)
        {
            MyApiProcessor.InsertPrisoner(fname,lname);
        }
    }
}
