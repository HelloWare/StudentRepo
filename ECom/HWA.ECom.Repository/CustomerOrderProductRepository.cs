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
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrderProduct_Select", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                CustomerOrderProduct customerOrderProduct;
                while (reader.Read())
                {

                    if (!reader.IsDBNull(1) && !reader.IsDBNull(2))
                    {
                        customerOrderProduct = new CustomerOrderProduct(Convert.ToInt32(reader["CustomerOrderId"]), Convert.ToInt32(reader["ProductId"]));

                        if (!reader.IsDBNull(0))
                            customerOrderProduct.Id = Convert.ToInt32(reader["Id"]);

                        if (!reader.IsDBNull(3))
                        {
                            customerOrderProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                        }

                        if (!reader.IsDBNull(4))
                        {
                            customerOrderProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                        }

     

                        if (!reader.IsDBNull(5))
                        {
                            customerOrderProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                        }

                        if (!reader.IsDBNull(6))
                        {
                            customerOrderProduct.Tax = Convert.ToDecimal(reader["Tax"]);
                        }

                        if (!reader.IsDBNull(7))
                        {
                            customerOrderProduct.Subtotal = Convert.ToString(reader["Subtotal"]);
                        }

                        if (!reader.IsDBNull(8))
                        {
                            customerOrderProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        }

                        if (!reader.IsDBNull(9))
                        {
                            customerOrderProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                        }

                   
                        if (!reader.IsDBNull(10))
                        {
                            customerOrderProduct.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                        }

                        if (!reader.IsDBNull(11))
                        {
                            customerOrderProduct.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
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
                    if (!reader.IsDBNull(1) && !reader.IsDBNull(2))
                    {
                        customerOrderProduct = new CustomerOrderProduct(Convert.ToInt32(reader["CustomerOrderId"]), Convert.ToInt32(reader["ProductId"]));

                        if (!reader.IsDBNull(0))
                            customerOrderProduct.Id = Convert.ToInt32(reader["Id"]);
                        if (!reader.IsDBNull(3))
                        {
                            customerOrderProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                        }

                        if (!reader.IsDBNull(4))
                        {
                            customerOrderProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                        }



                        if (!reader.IsDBNull(5))
                        {
                            customerOrderProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                        }

                        if (!reader.IsDBNull(6))
                        {
                            customerOrderProduct.Tax = Convert.ToDecimal(reader["Tax"]);
                        }

                        if (!reader.IsDBNull(7))
                        {
                            customerOrderProduct.Subtotal = Convert.ToString(reader["Subtotal"]);
                        }

                        if (!reader.IsDBNull(8))
                        {
                            customerOrderProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        }

                        if (!reader.IsDBNull(9))
                        {
                            customerOrderProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                        }


                        if (!reader.IsDBNull(10))
                        {
                            customerOrderProduct.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                        }

                        if (!reader.IsDBNull(11))
                        {
                            customerOrderProduct.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
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