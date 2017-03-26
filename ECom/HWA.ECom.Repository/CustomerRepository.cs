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
                //SqlCommand cmd = new SqlCommand("usp_Customer_Insert", con);//usp_Customer_Insert
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("UserName", customer.UserName);
                //cmd.Parameters.AddWithValue("FirstName", customer.FirstName);
                //cmd.Parameters.AddWithValue("LastName", customer.LastName);
                ////if(customer.CreatedBy != null)
                //cmd.Parameters.AddWithValue("CreatedBy", customer.CreatedBy);
                //cmd.Parameters.AddWithValue("CreatedDate", customer.CreatedDate);
                ////if (customer.LastModifiedBy != null)
                //cmd.Parameters.AddWithValue("LastModifiedBy", customer.LastModifiedBy);
                //cmd.Parameters.AddWithValue("LastModifiedDate", customer.LastModifiedDate);
                String commandText = String.Format("INSERT [dbo].[Customer] (UserName, FirstName, LastName, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", customer.UserName ?? "Default", customer.FirstName ?? "Defaulf FirstName", customer.LastName ?? "Default LastName", customer.CreatedBy ?? "Default User", customer.CreatedDate==null?DateTime.Now:customer.CreatedDate, customer.LastModifiedBy ?? "Default User", customer.LastModifiedDate == null ? DateTime.Now : customer.LastModifiedDate);

                SqlCommand cmd = new SqlCommand(commandText, con);

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
                //if (customer.CreatedBy != null)
                    cmd.Parameters.AddWithValue("CreatedBy", customer.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", customer.CreatedDate);
                //if (customer.CreatedBy != null)
                    cmd.Parameters.AddWithValue("LastModifiedBy", customer.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", DateTime.Now);

                cmd.ExecuteNonQuery();
            }

        }


        public Customer GetById(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Customer_GetById", con);
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
                   

                }
                return customer;
            }
 
        }


        public Customer GetByName(string name)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Customer_GetByName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UserName", name);

                SqlDataReader reader = cmd.ExecuteReader();
                Customer customer = new Customer();
                while (reader.Read())
                {
                    customer.Id = reader.GetInt32(0);
                    customer.UserName = reader.GetString(1);
                    customer.FirstName = reader.GetString(2);
                    customer.LastName = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                        customer.CreatedBy = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                        customer.CreatedDate = reader.GetDateTime(5);
                    if (!reader.IsDBNull(6))
                        customer.LastModifiedBy = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        customer.LastModifiedDate = reader.GetDateTime(7);


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
                    if (!reader.IsDBNull(1))
                        customer.UserName = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        customer.FirstName = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        customer.LastName = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                        customer.CreatedBy = reader.GetString(4);
                    customer.CreatedDate = reader.GetDateTime(5);
                    if (!reader.IsDBNull(6))
                        customer.LastModifiedBy = reader.GetString(6);
                    if(!reader.IsDBNull(7))
                        customer.LastModifiedDate = reader.GetDateTime(7);
 
                    customers.Add(customer);
                }
                return customers;
            }

        }
    }
}
