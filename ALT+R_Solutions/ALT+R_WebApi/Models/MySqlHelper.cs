using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALT_R_WebApi.Models
{
    internal static class MySqlHelper
    {
        private static string connectionstr_;
        public static string  ConnectionStr { get=>connectionstr_; internal set=>connectionstr_=value; }


        private static string ConnectionStrFromConfiguration(string name)
        {
            connectionstr_ = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return connectionstr_;
        }
        private static string ConnectionStrFromPath(string path)
        {
            connectionstr_ = path;
            return connectionstr_;
        }
        public static IEnumerable<PrisonerModel> GetAllPrisoners(string connectionName)
        {
            ConnectionStrFromConfiguration(connectionName);   
            if (connectionstr_ != null)
            {
                using (IDbConnection connection = new SqlConnection(connectionstr_))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    var prisoner = connection.Query<PrisonerModel>("dbo.GetAllPrisoners", commandType: CommandType.StoredProcedure);
                    return prisoner;
                }
            }
            else
            {
                throw new Exception("Connection String Cannot Be Empty");
            }
        }
        public static PrisonerModel GetPrisonerByID(int ID, string connectionName)
        {
            ConnectionStrFromConfiguration(connectionName);

            if (connectionstr_ != null)
            {
                using (IDbConnection connection = new SqlConnection(connectionstr_))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    var prisoner= connection.Query<PrisonerModel>("dbo.GetPrisonerByID", new { ID = ID }, commandType: CommandType.StoredProcedure);
                    return prisoner.FirstOrDefault();
                }
            }
            else
            {
                throw new Exception("Connection String Cannot Be Empty");
            }
        }
        public static void InsertPrisoner(string FirstName,string LastName,string connectionName)
        {
            ConnectionStrFromConfiguration(connectionName);

            if (connectionstr_ != null)
            {
                using (IDbConnection connection = new SqlConnection(connectionstr_))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    var ID = new Random().Next(10000, 99999);
                    var prisoner = connection.Query("dbo.InsertPrisoner", 
                        new { ID = ID, FNAME=FirstName,LNAME=LastName }, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                throw new Exception("Connection String Cannot Be Empty");
            }
        }
    }
}
