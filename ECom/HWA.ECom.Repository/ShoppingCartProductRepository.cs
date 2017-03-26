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
        private string _connectionString;
        public ShoppingCartProductRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public Boolean Create(ShoppingCartProduct shoppingCartProduct)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_InsertShoppingCartProduct", con);
                cmd.CommandType =CommandType.StoredProcedure;
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
                cmd.Parameters.AddWithValue("ModifiedBy", "Deyi");
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.Now);
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

        public  ShoppingCartProduct SelectById(Int32 Id)
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
                    if(reader["Quantity"] !=null) shoppingCartProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                    if (reader["UnitPrice"] != null) shoppingCartProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    if (reader["UnitOfMeasure"] != null) shoppingCartProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                    if (reader["SubTotal"] != null) shoppingCartProduct.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                    if (reader["CreatedBy"] != null) shoppingCartProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    shoppingCartProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (reader["ModifiedBy"] != null) shoppingCartProduct.LastModifiedBy = Convert.ToString(reader["ModifiedBy"]);
                    if (reader["ModifiedDate"] != null) shoppingCartProduct.LastModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                    return shoppingCartProduct;
                }
                return null;
            }
        }

        public  List<ShoppingCartProduct> Search(Int32 shoppingCartId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_SearchShoppingCartProductByShoppingCartId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ShoppingCartId", shoppingCartId);
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShoppingCartProduct> shoppingCartProductList = new List<ShoppingCartProduct> { };
                ShoppingCartProduct shoppingCartProduct;
                while (reader.Read())
                {
                    shoppingCartProduct = new ShoppingCartProduct(Convert.ToInt32(reader["ShoppingCartId"]), Convert.ToInt32(reader["ProductId"]));
                    shoppingCartProduct.Id = Convert.ToInt32(reader["Id"]);
                    if (reader["Quantity"] != null) shoppingCartProduct.Quantity = Convert.ToDecimal(reader["Quantity"]);
                    if (reader["UnitPrice"] != null) shoppingCartProduct.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    if (reader["UnitOfMeasure"] != null) shoppingCartProduct.UnitOfMeasure = Convert.ToString(reader["UnitOfMeasure"]);
                    if (reader["SubTotal"] != null) shoppingCartProduct.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                    if (reader["CreatedBy"] != null) shoppingCartProduct.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    shoppingCartProduct.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (reader["ModifiedBy"] != null) shoppingCartProduct.LastModifiedBy = Convert.ToString(reader["ModifiedBy"]);
                    if (reader["ModifiedDate"] != null) shoppingCartProduct.LastModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                    shoppingCartProductList.Add(shoppingCartProduct);
                }
                return shoppingCartProductList;
            }
        }
    }
}
