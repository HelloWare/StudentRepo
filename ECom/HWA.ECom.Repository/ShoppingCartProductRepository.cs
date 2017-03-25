using HWA.ECom.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.Ecom.Repository
{
    public class ShoppingCartProductRepository
    {
        #region Fields
        private String _connectionString;
        #endregion

        #region Constructors
        public ShoppingCartProductRepository()
        {
        }
        public ShoppingCartProductRepository(String connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion

        public Boolean Create(ShoppingCartProduct shoppingCartProduct)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_InsertShoppingCartProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ShoppingCartId", shoppingCartProduct.ShoppingCartId);
                cmd.Parameters.AddWithValue("ProductId", shoppingCartProduct.ProductId);
                cmd.Parameters.AddWithValue("Quantity", shoppingCartProduct.Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", shoppingCartProduct.UnitPrice);
                cmd.Parameters.AddWithValue("UnitOfMeasure", shoppingCartProduct.UnitOfMeasure);
                cmd.Parameters.AddWithValue("SubTotal", shoppingCartProduct.SubTotal);
                cmd.Parameters.AddWithValue("CreatedBy", shoppingCartProduct.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", shoppingCartProduct.CreatedDate);
                SqlParameter retval = cmd.Parameters.Add("Return", SqlDbType.Int);
                retval.Direction = System.Data.ParameterDirection.ReturnValue;
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
            }
            return false;
        }

        public Boolean Update(ShoppingCartProduct shoppingCartProduct)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_UpdateShoppingCartProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", shoppingCartProduct.Id);
                cmd.Parameters.AddWithValue("ShoppingCartId", shoppingCartProduct.ShoppingCartId);
                cmd.Parameters.AddWithValue("ProductId", shoppingCartProduct.ProductId);
                cmd.Parameters.AddWithValue("Quantity", shoppingCartProduct.Quantity);
                cmd.Parameters.AddWithValue("UnitPrice", shoppingCartProduct.UnitPrice);
                cmd.Parameters.AddWithValue("UnitOfMeasure", shoppingCartProduct.UnitOfMeasure);
                cmd.Parameters.AddWithValue("SubTotal", shoppingCartProduct.SubTotal);
                cmd.Parameters.AddWithValue("LastModifiedBy", shoppingCartProduct.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", shoppingCartProduct.LastModifiedDate);
                SqlParameter retval = cmd.Parameters.Add("Return", SqlDbType.Int);
                retval.Direction = System.Data.ParameterDirection.ReturnValue;
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
            }
            return false;
        }

        public Boolean Delete(Int32 Id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_DeleteShoppingCartProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", Id);
                SqlParameter retval = cmd.Parameters.Add("Return", SqlDbType.Int);
                retval.Direction = System.Data.ParameterDirection.ReturnValue;
                Int32 counts = cmd.ExecuteNonQuery();
                if (counts > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public ShoppingCartProduct SelectById(Int32 Id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_GetShoppingCartProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                ShoppingCartProduct shoppingCartProduct;
                while (reader.Read())
                {
                    shoppingCartProduct = new ShoppingCartProduct(Convert.ToInt32(reader["ShoppingCartId"]), Convert.ToInt32(reader["ProductId"]));
                    shoppingCartProduct.Id = Convert.ToInt32(reader["Id"]);
                    //shoppingCartProduct.ShoppingCartId = Convert.ToInt32(reader["ShoppingCartId"]);
                    //shoppingCartProduct.ProductId = Convert.ToInt32(reader["ProductId"]);
                    if (!reader.IsDBNull(4))
                    {
                        shoppingCartProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        shoppingCartProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        shoppingCartProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        shoppingCartProduct.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        shoppingCartProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        shoppingCartProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    if (!reader.IsDBNull(10))
                    {
                        shoppingCartProduct.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    }
                    if (!reader.IsDBNull(11))
                    {
                        shoppingCartProduct.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    }
                    return shoppingCartProduct;
                }
                return null;
            }
        }

        public List<ShoppingCartProduct> Search(Int32 shoppingCartId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_SearchShoppingCartProductByShoppingCartId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ShoppingCartId", shoppingCartId);
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShoppingCartProduct> shoppingCartProductList = new List<ShoppingCartProduct> { };
                ShoppingCartProduct shoppingCartProduct;// = new ShoppingCartProduct();
                while (reader.Read())
                {
                    shoppingCartProduct = new ShoppingCartProduct(Convert.ToInt32(reader["ShoppingCartId"]), Convert.ToInt32(reader["ProductId"]));
                    if (!reader.IsDBNull(1)) { }
                    shoppingCartProduct.Id = Convert.ToInt32(reader["Id"]);

                    //shoppingCartProduct.ShoppingCartId = Convert.ToInt32(reader["ShoppingCartId"]);
                    //shoppingCartProduct.ProductId = Convert.ToInt32(reader["ProductId"]);
                    if (!reader.IsDBNull(4))
                    {
                        shoppingCartProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        shoppingCartProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        shoppingCartProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        shoppingCartProduct.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        shoppingCartProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        shoppingCartProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    if (!reader.IsDBNull(10))
                    {
                        shoppingCartProduct.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    }
                    if (!reader.IsDBNull(11))
                    {
                        shoppingCartProduct.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    }
                    shoppingCartProductList.Add(shoppingCartProduct);
                }
                return shoppingCartProductList;
            }
        }
    }
}
        
    