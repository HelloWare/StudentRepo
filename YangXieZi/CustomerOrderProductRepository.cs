using HWA.ECom.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Repository
{
    class CustomerOrderProductRepository
    {
        #region Fields
        private String _connectionString;
        #endregion

        #region Constructors
        public CustomerOrderProductRepository()
        {
        }
        public CustomerOrderProductRepository(String connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion

        //CRUD, 
        public Boolean Insert(CustomerOrderProduct customerOrderProduct)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrderProduct_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", customerOrderProduct.Id);
                cmd.Parameters.AddWithValue("CustomerOrderId", customerOrderProduct.CustomerOrderId);
                cmd.Parameters.AddWithValue("ProductId", customerOrderProduct.ProductId);
                cmd.Parameters.AddWithValue("Quantity", customerOrderProduct.Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", customerOrderProduct.UnitOfMeasure);
                cmd.Parameters.AddWithValue("Tax", customerOrderProduct.Tax);
                cmd.Parameters.AddWithValue("UnitOfMeasure", customerOrderProduct.UnitOfMeasure);
                cmd.Parameters.AddWithValue("LastModifiedDate", customerOrderProduct.LastModifiedDate);
                cmd.Parameters.AddWithValue("CreatedDate", customerOrderProduct.CreatedDate);
                cmd.Parameters.AddWithValue("CreatedBy", customerOrderProduct.CreatedBy);
                cmd.Parameters.AddWithValue("LastModifiedBy", customerOrderProduct.LastModifiedBy);
                //Add more parameters from SP

                Int32 id = cmd.ExecuteNonQuery();

                if (id > 0)
                {
                    customerOrderProduct.Id = id;
                    return true;
                }
            }
            return false;
        }

        public Boolean Update(CustomerOrderProduct customerOrderProduct)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrderProduct_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", customerOrderProduct.Id);
                cmd.Parameters.AddWithValue("CustomerOrderId", customerOrderProduct.CustomerOrderId);
                cmd.Parameters.AddWithValue("ProductId", customerOrderProduct.ProductId);
                cmd.Parameters.AddWithValue("Quantity", customerOrderProduct.Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", customerOrderProduct.UnitOfMeasure);
                cmd.Parameters.AddWithValue("Tax", customerOrderProduct.Tax);
                cmd.Parameters.AddWithValue("UnitOfMeasure", customerOrderProduct.UnitOfMeasure);
                cmd.Parameters.AddWithValue("LastModifiedDate", customerOrderProduct.LastModifiedDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", customerOrderProduct.LastModifiedBy);
                //Add more parameters from SP

                Int32 id = cmd.ExecuteNonQuery();

                if (id > 0)
                {
                    customerOrderProduct.Id = id;
                    return true;
                }
            }
            return false;
        }

        public Boolean Delete(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrderProduct_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);


                Int32 counts = cmd.ExecuteNonQuery();

                if (counts > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public CustomerOrderProduct Get(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_GetCustomerOrderProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                CustomerOrderProduct customerOrderProduct = new CustomerOrderProduct();
                while (reader.Read())
                {
                    customerOrderProduct.Id = id;
                    customerOrderProduct.CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]);
                    customerOrderProduct.ProductId = Convert.ToInt32(reader["ProductId"]);
                    customerOrderProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                    customerOrderProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    customerOrderProduct.Tax = Convert.ToDecimal(reader["Tax"]);
                    customerOrderProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                    customerOrderProduct.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    customerOrderProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    customerOrderProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    customerOrderProduct.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    //TO BE DONE, ORM process, map table data to class object

                }
                return customerOrderProduct;
            }
        }

        public List<CustomerOrderProduct> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from CustomerOrderProduct", con);


                SqlDataReader reader = cmd.ExecuteReader();
                List<CustomerOrderProduct> customerOrderProducts = new List<CustomerOrderProduct>();
                while (reader.Read())
                {
                    CustomerOrderProduct customerOrderProduct = new CustomerOrderProduct();
                    customerOrderProduct.CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]);
                    customerOrderProduct.ProductId = Convert.ToInt32(reader["ProductId"]);
                    customerOrderProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                    customerOrderProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    customerOrderProduct.Tax = Convert.ToDecimal(reader["Tax"]);
                    customerOrderProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                    customerOrderProduct.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    customerOrderProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    customerOrderProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    customerOrderProduct.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    customerOrderProducts.Add(customerOrderProduct);
                    //TO BE DONE, ORM process, map table data to class object

                }
                return customerOrderProducts;
            }
        }



    }
}