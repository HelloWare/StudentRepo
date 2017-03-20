using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWA.ECom.Entity;

namespace HWA.ECom.Repository
{
    public class StatusRepository
    {

        #region Fields
        private String _connectionString;
        #endregion

        #region Constructors
        public StatusRepository()
        {

        }
        public StatusRepository(String connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion
        public Status GetById(Int32 Id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from  [dbo].[Status] where Id="+Id, con);


                cmd.Parameters.AddWithValue("Id", Id);

                SqlDataReader reader = cmd.ExecuteReader();
                Status status = new Status();
               
                while (reader.Read())
                {
                    status.Id = Id;
                    status.Name = Convert.ToString(reader["Name"]);

                    status.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    status.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    status.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    status.LastModifiedDate= Convert.ToDateTime(reader["LastModifiedDate"]);
                    //TO BE DONE, ORM process, map table data to class object

                }
                return status;
            }
        }
    }
}
