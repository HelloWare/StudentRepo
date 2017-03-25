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
        //private object products;
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
            //      using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EComConnection"].ConnectionString))
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_InsertShoppingCart", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CustomerId", shoppingCart.CustomerId);
                     cmd.Parameters.AddWithValue("GrandTotal", shoppingCart.GrandTotal);
                //if (shoppingCart.CreatedBy != null)
                    cmd.Parameters.AddWithValue("CreatedBy", "Deyi");
                    cmd.Parameters.AddWithValue("CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("LastModifiedBy", "Deyi");
                    cmd.Parameters.AddWithValue("LastModifiedDate", DateTime.Now);
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
                cmd.Parameters.AddWithValue("CustomerId", shoppingCart.CustomerId);
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
                    shoppingCart.Id = Convert.ToInt32(reader["Id"]);
                    //shoppingCart.CustomerId = customerId;
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
                    shoppingCart.Id = Convert.ToInt32(reader["Id"]);
                    //shoppingCart.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    shoppingCart.GrandTotal = Convert.ToDecimal(reader["GrandTotal"]);
                    shoppingCart.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    shoppingCart.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    shoppingCart.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    shoppingCart.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    shoppingCartList.Add(shoppingCart);
                }
                return shoppingCartList;
            }
        }
        // 1 List<ShoppingCartProduct> products   (done, products is shoppingcart name)
        //2  AddProduct(Product product, int qty)
        //        {
        //            ShoppingCartProduct scProduct = new ShoppingCartProduct(product, qty);
        //            this.products.Insert(scProduct);
        //        }
        //3  DeleteProduct(Product product)
        //        {
        //            ShoppingCartProduct scProduct = new ShoppingCartProduct(product, qty);
        //            this.products.delete(scProduct);
        //        }

        //4 CheckOut()
         //{
        //            ShoppingCartProduct scProduct = new ShoppingCartProduct(product, qty);
        //            this.products.delete(scProduct);
        //        }
        //5  EmptyShoppingCart()

        //public Boolean AddProduct(Product product, int qty)
        //{
        //    ShoppingCartProduct scProduct = new ShoppingCartProduct();
        //    this.products.Insert(scProduct);
        //    return ture;

        //}

    }
}
