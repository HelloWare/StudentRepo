using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWA.ECom.Entity;

namespace HWA.ECom.Repository
{
    public class CustomerRepository
    {
        #region Fields
        private string _connectionString;
        #endregion

        #region Constructor
       
        public CustomerRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion

        //CRUD

        //public List<Customer> SelectsAll()
        //{
        //    SqlConnection con = new SqlConnection(_connectionString);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_Customer_GetAll", con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //    SqlDataReader reader = cmd.ExecuteReader();
        //    List<Customer> customers = new List<Customer>();
        //    while (reader.Read())
        //    {
        //        Customer customer = new Customer();

        //        customer.Id = reader.GetInt32(0);
        //        customer.FirstName = reader.GetString(1);
        //        customer.LastName = reader.GetString(2);

        //        customers.Add(customer);
        //    }
        //    con.Close();

        //    return customers;
        //}

        public void Insert(Customer customer)
        {
            
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Customer_Insert", con);//usp_Customer_Insert
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UserName", customer.UserName);
                cmd.Parameters.AddWithValue("FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("LastName", customer.LastName);
                cmd.Parameters.AddWithValue("CreateBy", customer.CreatedBy);
                cmd.Parameters.AddWithValue("CreateDate", customer.CreatedDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", customer.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", customer.LastModifiedDate);

                cmd.ExecuteNonQuery();
            }           

        }


        public Boolean Delete(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Customer_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id",id);

                Int32 count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    return true;
                }
            }
            return true;
        }


        public void Update(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Customer_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", customer.Id);
                cmd.Parameters.AddWithValue("UserName", customer.UserName);
                cmd.Parameters.AddWithValue("FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("LastName", customer.LastName);
                cmd.Parameters.AddWithValue("CreateBy", customer.CreatedBy);
                cmd.Parameters.AddWithValue("CreateDate", customer.CreatedDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", customer.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", DateTime.Now);

                cmd.ExecuteNonQuery();
               
            }

        }


        public Customer Get(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Customer_Get", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                Customer customer = new Customer();
                while (reader.Read())
                {
                    customer.Id = reader.GetInt32(0);
                    customer.UserName = reader.GetString(1);
                    customer.FirstName = reader.GetString(2);
                    customer.LastName = reader.GetString(3);
                    if(!reader.IsDBNull(4))
                    customer.CreatedBy = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                        customer.CreatedDate = reader.GetDateTime(5);
                    if (!reader.IsDBNull(6))
                        customer.LastModifiedBy = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        customer.LastModifiedDate = reader.GetDateTime(7);
                    //customer.Id = Convert.ToInt32(reader["Id"]);
                    //customer.UserName = Convert.ToString(reader["UserName"]);
                    //customer.FirstName = Convert.ToString(reader["FirstName"]);
                    //customer.LastName = Convert.ToString(reader["LastName"]);
                    //customer.CreatedBy = Convert.ToString(reader["CreateBy"]);
                    //customer.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    //customer.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    //customer.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);

                }
                return customer;
            }
 
        }


        public List<Customer> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Customer_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Customer> customers = new List<Customer>();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = reader.GetInt32(0);
                    customer.UserName = reader.GetString(1);
                    customer.FirstName = reader.GetString(2);
                    customer.LastName = reader.GetString(3);
                    customer.CreatedBy = reader.GetString(4);
                    customer.CreatedDate = reader.GetDateTime(5);
                    customer.LastModifiedBy = reader.GetString(6);
                    customer.LastModifiedDate = reader.GetDateTime(7);
 
                    customers.Add(customer);
                }
                return customers;
            }

        }
    }
}
