using HWA.ECom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HWA.Ecom.Repository
{


    public class ShoppingCartRepository
    {
        #region Fields
        private String _connectionString;
        #endregion

        #region Constructors
        public ShoppingCartRepository()
        {
        }
        public ShoppingCartRepository(String connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion
        public Boolean Insert(ShoppingCart shoppingCart)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_InsertShoppingCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CustomerId", shoppingCart.CustomerId);
                cmd.Parameters.AddWithValue("GrandTotal", shoppingCart.GrandTotal);
                cmd.Parameters.AddWithValue("CreatedBy", shoppingCart.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", shoppingCart.CreatedDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", shoppingCart.CreatedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", shoppingCart.CreatedDate);
                SqlParameter retval = cmd.Parameters.Add("Return", SqlDbType.Int);
                retval.Direction = System.Data.ParameterDirection.ReturnValue;
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
            }
            return false;
        }

        public Boolean Update(ShoppingCart shoppingCart)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_UpdateShoppingCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("CustomerId", shoppingCart.CustomerId); removed from SP
                cmd.Parameters.AddWithValue("GrandTotal", shoppingCart.GrandTotal);
                cmd.Parameters.AddWithValue("LastModifiedBy", shoppingCart.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", shoppingCart.LastModifiedDate);
                SqlParameter retval = cmd.Parameters.Add("Return", SqlDbType.Int);
                retval.Direction = System.Data.ParameterDirection.ReturnValue;
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
            }
            return false;
        }

        public Boolean Delete(int shoppingCartId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_DeleteShoppingCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", shoppingCartId);
                SqlParameter retval = cmd.Parameters.Add("Return", SqlDbType.Int);
                retval.Direction = System.Data.ParameterDirection.ReturnValue;
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
            }
            return false;
        }

        public ShoppingCart GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_SelectByIdShoppingCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                ShoppingCart shoppingCart;// = new ShoppingCart();
                while (reader.Read())
                {
                    shoppingCart = new ShoppingCart(Convert.ToInt32(reader["CustomerId"]));
                    shoppingCart.Id = id;
                    //shoppingCart.CustomerId = ;
                    shoppingCart.GrandTotal = Convert.ToDecimal(reader["GrandTotal"]);
                    shoppingCart.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    shoppingCart.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    shoppingCart.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    shoppingCart.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    return shoppingCart;

                }
                return null;
            }
        }

        public ShoppingCart GetByCustomerId(int customerId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_SelectByCustomerIdShoppingCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", customerId);
                SqlDataReader reader = cmd.ExecuteReader();
                ShoppingCart shoppingCart;// = new ShoppingCart();
                while (reader.Read())
                {

                    shoppingCart = new ShoppingCart(customerId);
                    if (!reader.IsDBNull(1))
                    { shoppingCart.Id = Convert.ToInt32(reader["Id"]); }
                    //shoppingCart.CustomerId = customerId;
                    if (!reader.IsDBNull(3))
                    {
                        shoppingCart.GrandTotal = Convert.ToDecimal(reader["GrandTotal"]);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        shoppingCart.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        shoppingCart.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        shoppingCart.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        shoppingCart.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    }
                    return shoppingCart;

                }
                return null;
            }
        }

        public List<ShoppingCart> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_SelectAllShoppingCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShoppingCart> shoppingCartList = new List<ShoppingCart> { };
                ShoppingCart shoppingCart;// = new ShoppingCart();
                while (reader.Read())
                {
                    shoppingCart = new ShoppingCart(Convert.ToInt32(reader["CustomerId"]));
                    if (!reader.IsDBNull(1))
                    {
                        shoppingCart.Id = Convert.ToInt32(reader["Id"]);
                    }
                    //shoppingCart.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    if (!reader.IsDBNull(3))
                    {
                        shoppingCart.GrandTotal = Convert.ToDecimal(reader["GrandTotal"]);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        shoppingCart.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        shoppingCart.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        shoppingCart.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        shoppingCart.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    }
                    shoppingCartList.Add(shoppingCart);
                }
                return shoppingCartList;
            }
        }
    }
}
