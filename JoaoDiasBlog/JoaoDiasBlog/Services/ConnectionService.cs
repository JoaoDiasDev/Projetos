using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JoaoDiasBlog.Services
{
    public class ConnectionService
    {

        private SqlConnection myConnection;
        private IConfiguration _configuration;

        public ConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
            myConnection = new SqlConnection(connectionString);
            if (myConnection.State != ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        internal SqlConnection DbConnection()
        {
            return myConnection;
        }
    }
}
