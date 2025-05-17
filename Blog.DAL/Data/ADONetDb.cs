using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Data
{
    public static class ADONetDb
    {
        private static string _connectionString = "Data Source=Ranjay-PC;Initial Catalog=BlogDb;Integrated Security=True;Trust Server Certificate=True";
        //private readonly IConfiguration _configuration;
        public static DataSet ExecuteSp(string SPName, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SPName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing stored procedure: " + ex.Message, ex);
            }
        }
    }
}
