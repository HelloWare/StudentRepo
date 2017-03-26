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

<<<<<<< HEAD
                    if (reader["CustomerOrderId"] != null && reader["ProductId"] != null)
=======
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee
                    {
                        customerOrderProduct = new CustomerOrderProduct(reader.GetInt32(0), reader.GetInt32(1));

<<<<<<< HEAD
                        if (reader["Id"] != null)
                            customerOrderProduct.Id = Convert.ToInt32(reader["Id"]);
=======

                        if (!reader.IsDBNull(2))
                        {
                            customerOrderProduct.Quantity = reader.GetDecimal(2);
                        }
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee

                        if (reader["Quantity"] != null)
                        {
                            customerOrderProduct.UnitPrice = reader.GetDecimal(3);
                        }

                        if (reader["UnitPrice"] != null)
                        {
                            customerOrderProduct.Tax = reader.GetDecimal(4);
                        }

<<<<<<< HEAD
     

                        if (reader["UnitOfMeasure"] != null)
=======
                        if (!reader.IsDBNull(5))
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee
                        {
                            customerOrderProduct.UnitOfMeasure = reader.GetString(5);
                        }

                        if (reader["Tax"] != null)
                        {
                            customerOrderProduct.Subtotal = reader.GetString(6);
                        }

                        if (reader["Subtotal"] != null)
                        {
                            customerOrderProduct.CreatedDate = reader.GetDateTime(7);
                        }

                        if (reader["CreatedDate"] != null)
                        {
                            customerOrderProduct.LastModifiedDate = reader.GetDateTime(8);
                        }

                        if (reader["CreatedBy"] != null)
                        {
                            customerOrderProduct.CreatedBy = reader.GetString(9);
                        }

<<<<<<< HEAD
                   
                        if (reader["LastModifiedBy"] != null)
                        {
                            customerOrderProduct.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                        }

                        if (reader["LastModifiedDate"] != null)
                        {
                            customerOrderProduct.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
=======
                        if (!reader.IsDBNull(10))
                        {
                            customerOrderProduct.LastModifiedBy = reader.GetString(10);
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee
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
<<<<<<< HEAD
                    if (reader["CustomerOrderId"] != null && reader["ProductId"] != null)
=======
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee
                    {
                        customerOrderProduct = new CustomerOrderProduct(reader.GetInt32(0), reader.GetInt32(1));


                        if (!reader.IsDBNull(2))
                        {
                            customerOrderProduct.ProductId = reader.GetInt32(2);
                        }

<<<<<<< HEAD
                        if (reader["Id"] != null)
                            customerOrderProduct.Id = Convert.ToInt32(reader["Id"]);

                        if (reader["Quantity"] != null)
=======
                        if (!reader.IsDBNull(3))
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee
                        {
                            customerOrderProduct.Quantity = reader.GetDecimal(3);
                        }

                        if (reader["UnitPrice"] != null)
                        {
                            customerOrderProduct.UnitPrice = reader.GetDecimal(4);
                        }

<<<<<<< HEAD


                        if (reader["UnitOfMeasure"] != null)
=======
                        if (!reader.IsDBNull(5))
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee
                        {
                            customerOrderProduct.Tax = reader.GetDecimal(5);
                        }

                        if (reader["Tax"] != null)
                        {
                            customerOrderProduct.UnitOfMeasure = reader.GetString(6);
                        }

                        if (reader["Subtotal"] != null)
                        {
                            customerOrderProduct.Subtotal = reader.GetString(7);
                        }

                        if (reader["CreatedDate"] != null)
                        {
                            customerOrderProduct.CreatedDate = reader.GetDateTime(8);
                        }

                        if (reader["CreatedBy"] != null)
                        {
                            customerOrderProduct.LastModifiedDate = reader.GetDateTime(9);
                        }

<<<<<<< HEAD

                        if (reader["LastModifiedBy"] != null)
=======
                        if (!reader.IsDBNull(10))
>>>>>>> 679b3203449c7465444df5a538d58d2754e223ee
                        {
                            customerOrderProduct.CreatedBy = reader.GetString(10);
                        }

                        if (reader["LastModifiedDate"] != null)
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