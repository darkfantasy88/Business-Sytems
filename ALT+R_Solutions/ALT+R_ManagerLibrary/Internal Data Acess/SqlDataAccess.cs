using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALT_R_ManagerLibrary.Internal_Data_Acess
{
    internal class SqlDataAccess
    {
        private string GetConnectStringFromConfig(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public IEnumerable<T> RetrieveDataUsingConfig<T,U>(string storedProcedure,U paramaters,string connectionName)
        {
            
            var connectionString = GetConnectStringFromConfig(connectionName);

            using (IDbConnection dbConnection=new SqlConnection(connectionString))
            {
                var rows = dbConnection.Query<T>(storedProcedure, paramaters, commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }
        public IEnumerable<T> RetrieveData<T, U>(string storedProcedure, U paramaters, string connectionString)
        {


            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var rows = dbConnection.Query<T>(storedProcedure, paramaters, commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }
        public async void SaveDataUsingConfig(string storedProcedure,string connectionName)
        {
            var connectionString = GetConnectStringFromConfig(connectionName);

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.ExecuteAsync(storedProcedure,commandType: CommandType.StoredProcedure);                
            }
        }
        public async void SaveData(string storedProcedure, string connectionString)
        {

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.ExecuteAsync(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
