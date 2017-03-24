using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWA.ECom.Entity;

namespace HWA.ECom.Repository
{
    public class ProductRepository
    {
        #region Fields
        private string _connectionString;
        #endregion

        #region Constructor

        public ProductRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion

        public void Insert(Product product)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_Insert", con);//usp_Customer_Insert
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", product.Name);
                cmd.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("Description", product.Description);
                cmd.Parameters.AddWithValue("Sequence", product.Sequence);
                cmd.Parameters.AddWithValue("IsActive", product.IsActive);
                cmd.Parameters.AddWithValue("Comment", product.Comment);
                cmd.Parameters.AddWithValue("UnitOfMeasure", product.UnitOfMeasure);
                cmd.Parameters.AddWithValue("IconUrl", product.IconUrl);
                cmd.Parameters.AddWithValue("PictureUrl", product.PictureUrl);
                cmd.Parameters.AddWithValue("CategoryId", product.CategoryId);

                cmd.Parameters.AddWithValue("CreateBy", product.CreateBy);
                cmd.Parameters.AddWithValue("CreateDate", product.CreateDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", product.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", product.LastModifiedDate);

                cmd.ExecuteNonQuery();
            }

        }


        public Boolean Delete(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                Int32 count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    return true;
                }
            }
            return true;
        }


        public void Update(Product product)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", product.Id);
                cmd.Parameters.AddWithValue("Name", product.Name);
                cmd.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("Description", product.Description);
                cmd.Parameters.AddWithValue("Sequence", product.Sequence);
                cmd.Parameters.AddWithValue("IsActive", product.IsActive);
                cmd.Parameters.AddWithValue("Comment", product.Comment);
                cmd.Parameters.AddWithValue("UnitOfMeasure", product.UnitOfMeasure);
                cmd.Parameters.AddWithValue("IconUrl", product.IconUrl);
                cmd.Parameters.AddWithValue("PictureUrl", product.PictureUrl);
                cmd.Parameters.AddWithValue("CategoryId", product.CategoryId);

                cmd.Parameters.AddWithValue("CreateBy", product.CreateBy);
                cmd.Parameters.AddWithValue("CreateDate", product.CreateDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", product.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", product.LastModifiedDate);

                cmd.ExecuteNonQuery();

            }

        }


        public Product Get(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_Get", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                Product product = new Product();
                while (reader.Read())
                {
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.UnitPrice = reader.GetDecimal(2);
                    product.StockQuantity = reader.GetDecimal(3);
                    product.Description = reader.GetString(4);
                    product.Sequence = reader.GetInt32(5);
                    product.IsActive = reader.GetBoolean(6);
                    product.Comment = reader.GetString(7);

                    product.CreateBy = reader.GetString(8);
                    product.CreateDate = reader.GetDateTime(9);
                    product.LastModifiedBy = reader.GetString(10);
                    product.LastModifiedDate = reader.GetDateTime(11);

                    product.UnitOfMeasure = reader.GetString(12);
                    product.CategoryId = reader.GetInt32(13);
                    product.IconUrl = reader.GetString(14);             
                    product.PictureUrl = reader.GetString(15);          
                }
                return product;
            }

        }


        public List<Product> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.UnitPrice = reader.GetDecimal(2);
                    product.StockQuantity = reader.GetDecimal(3);
                    product.Description = reader.GetString(4);
                    product.Sequence = reader.GetInt32(5);
                    product.IsActive = reader.GetBoolean(6);
                    product.Comment = reader.GetString(7);

                    product.CreateBy = reader.GetString(8);
                    product.CreateDate = reader.GetDateTime(9);
                    product.LastModifiedBy = reader.GetString(10);
                    product.LastModifiedDate = reader.GetDateTime(11);

                    product.UnitOfMeasure = reader.GetString(12);
                    product.CategoryId = reader.GetInt32(13);
                    product.IconUrl = reader.GetString(14);
                    product.PictureUrl = reader.GetString(15);

                    

                    products.Add(product);
                }
                return products;
            }

        }

        public Product GetByCategoryId(Int32 categoryId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_GetByCategoryId", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CategoryId", categoryId);

                SqlDataReader reader = cmd.ExecuteReader();
                Product product = new Product();
                while (reader.Read())
                {
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.UnitPrice = reader.GetDecimal(2);
                    product.StockQuantity = reader.GetDecimal(3);
                    product.Description = reader.GetString(4);
                    product.Sequence = reader.GetInt32(5);
                    product.IsActive = reader.GetBoolean(6);
                    product.Comment = reader.GetString(7);

                    product.CreateBy = reader.GetString(8);
                    product.CreateDate = reader.GetDateTime(9);
                    product.LastModifiedBy = reader.GetString(10);
                    product.LastModifiedDate = reader.GetDateTime(11);

                    product.UnitOfMeasure = reader.GetString(12);
                    product.CategoryId = reader.GetInt32(13);
                    product.IconUrl = reader.GetString(14);
                    product.PictureUrl = reader.GetString(15);
                }
                return product;
            }

        }


        public List<Product> GetByProductNameAdm(string name)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_GetByProductName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", name);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.UnitPrice = reader.GetDecimal(2);
                    product.StockQuantity = reader.GetDecimal(3);
                    product.Description = reader.GetString(4);
                    product.Sequence = reader.GetInt32(5);
                    product.IsActive = reader.GetBoolean(6);
                    product.Comment = reader.GetString(7);

                    product.CreateBy = reader.GetString(8);
                    product.CreateDate = reader.GetDateTime(9);
                    product.LastModifiedBy = reader.GetString(10);
                    product.LastModifiedDate = reader.GetDateTime(11);

                    product.UnitOfMeasure = reader.GetString(12);
                    product.CategoryId = reader.GetInt32(13);
                    product.IconUrl = reader.GetString(14);
                    product.PictureUrl = reader.GetString(15);

                    products.Add(product);
                }
                return products;
            }

        }

        public List<Product> GetByProductNameUser(string name)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_GetByProductName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", name);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.UnitPrice = reader.GetDecimal(2);
                    product.StockQuantity = reader.GetDecimal(3);
                    product.Description = reader.GetString(4);
                    product.Sequence = reader.GetInt32(5);
                    product.IsActive = reader.GetBoolean(6);
                    product.Comment = reader.GetString(7);

                    product.CreateBy = reader.GetString(8);
                    product.CreateDate = reader.GetDateTime(9);
                    product.LastModifiedBy = reader.GetString(10);
                    product.LastModifiedDate = reader.GetDateTime(11);

                    product.UnitOfMeasure = reader.GetString(12);
                    product.CategoryId = reader.GetInt32(13);
                    product.IconUrl = reader.GetString(14);
                    product.PictureUrl = reader.GetString(15);

                    products.Add(product);
                }
                return products;
            }

        }
    }
}
