using HWA.ECom.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Repository
{
    public class CustomerOrderProductRepository
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
                
                cmd.Parameters.AddWithValue("CustomerOrderId", customerOrderProduct.CustomerOrderId);
                cmd.Parameters.AddWithValue("ProductId", customerOrderProduct.ProductId);
                cmd.Parameters.AddWithValue("Quantity", customerOrderProduct.Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", customerOrderProduct.UnitPrice);
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
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrderProduct_Select", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                CustomerOrderProduct customerOrderProduct;
                while (reader.Read())
                {

                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        customerOrderProduct = new CustomerOrderProduct(reader.GetInt32(0), reader.GetInt32(1));


                        if (!reader.IsDBNull(2))
                        {
                            customerOrderProduct.Quantity = reader.GetDecimal(2);
                        }

                        if (!reader.IsDBNull(3))
                        {
                            customerOrderProduct.UnitPrice = reader.GetDecimal(3);
                        }

                        if (!reader.IsDBNull(4))
                        {
                            customerOrderProduct.Tax = reader.GetDecimal(4);
                        }

                        if (!reader.IsDBNull(5))
                        {
                            customerOrderProduct.UnitOfMeasure = reader.GetString(5);
                        }

                        if (!reader.IsDBNull(6))
                        {
                            customerOrderProduct.Subtotal = reader.GetDecimal(6);
                        }

                        if (!reader.IsDBNull(7))
                        {
                            customerOrderProduct.CreatedDate = reader.GetDateTime(7);
                        }

                        if (!reader.IsDBNull(8))
                        {
                            customerOrderProduct.LastModifiedDate = reader.GetDateTime(8);
                        }

                        if (!reader.IsDBNull(9))
                        {
                            customerOrderProduct.CreatedBy = reader.GetString(9);
                        }

                        if (!reader.IsDBNull(10))
                        {
                            customerOrderProduct.LastModifiedBy = reader.GetString(10);
                        }
                        return customerOrderProduct;

                    }
                    //TO BE DONE, ORM process, map table data to class object
                }
            }
            return null;
        }



        public List<CustomerOrderProduct> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from CustomerOrderProduct", con);


                SqlDataReader reader = cmd.ExecuteReader();
                //CustomerOrderProduct customerOrderProducts;
                List<CustomerOrderProduct> customerOrderProducts = new List<CustomerOrderProduct>();
                CustomerOrderProduct customerOrderProduct;

                while (reader.Read())
                {
                    //customerOrderProducts = new CustomerOrderProduct(reader.GetInt32(0), reader.GetInt32(1));

                    //customerOrderProduct.CustomerOrderId = reader.GetInt32(0);
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        customerOrderProduct = new CustomerOrderProduct(reader.GetInt32(0), reader.GetInt32(1));


                        if (!reader.IsDBNull(2))
                        {
                            customerOrderProduct.ProductId = reader.GetInt32(2);
                        }

                        if (!reader.IsDBNull(3))
                        {
                            customerOrderProduct.Quantity = reader.GetDecimal(3);
                        }

                        if (!reader.IsDBNull(4))
                        {
                            customerOrderProduct.UnitPrice = reader.GetDecimal(4);
                        }

                        if (!reader.IsDBNull(5))
                        {
                            customerOrderProduct.Tax = reader.GetDecimal(5);
                        }

                        if (!reader.IsDBNull(6))
                        {
                            customerOrderProduct.UnitOfMeasure = reader.GetString(6);
                        }

                        if (!reader.IsDBNull(7))
                        {
                            customerOrderProduct.Subtotal = reader.GetDecimal(7);
                        }

                        if (!reader.IsDBNull(8))
                        {
                            customerOrderProduct.CreatedDate = reader.GetDateTime(8);
                        }

                        if (!reader.IsDBNull(9))
                        {
                            customerOrderProduct.LastModifiedDate = reader.GetDateTime(9);
                        }

                        if (!reader.IsDBNull(10))
                        {
                            customerOrderProduct.CreatedBy = reader.GetString(10);
                        }

                        if (!reader.IsDBNull(11))
                        {
                            customerOrderProduct.LastModifiedBy = reader.GetString(11);
                        }

                        customerOrderProducts.Add(customerOrderProduct);
                        //TO BE DONE, ORM process, map table data to class object


                    }


                }
                return customerOrderProducts;
            }

        }
    }
}