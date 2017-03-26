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

                cmd.Parameters.AddWithValue("CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("Name", product.Name);
                if (product.UnitPrice != null)
                    cmd.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
                if (product.StockQuantity != null)
                    cmd.Parameters.AddWithValue("StockQuantity", product.StockQuantity);
                if (product.Description != null)
                    cmd.Parameters.AddWithValue("Description", product.Description);
                if (product.UnitOfMeasure != null)
                    cmd.Parameters.AddWithValue("UnitOfMeasure", product.UnitOfMeasure);
             
                cmd.Parameters.AddWithValue("IsActive", product.IsActive);
                if (product.Sequence != null)
                    cmd.Parameters.AddWithValue("Sequence", product.Sequence);
                if (product.IconUrl != null)
                    cmd.Parameters.AddWithValue("IconUrl", product.IconUrl);
                if (product.PictureUrl != null)
                    cmd.Parameters.AddWithValue("PictureUrl", product.PictureUrl);
                if (product.Comment != null)
                    cmd.Parameters.AddWithValue("Comment", product.Comment);

                cmd.Parameters.AddWithValue("CreatedDate", product.CreatedDate);
                if (product.CreatedBy != null)
                    cmd.Parameters.AddWithValue("CreatedBy", product.CreatedBy);
                if (product.LastModifiedBy != null)
                    cmd.Parameters.AddWithValue("LastModifiedBy", product.LastModifiedBy);
                if (product.LastModifiedDate != null)
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
                cmd.Parameters.AddWithValue("CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("Name", product.Name);
                if (product.UnitPrice != null)
                    cmd.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
                if (product.StockQuantity != null)
                    cmd.Parameters.AddWithValue("StockQuantity", product.StockQuantity);
                if (product.Description != null)
                    cmd.Parameters.AddWithValue("Description", product.Description);
                if (product.UnitOfMeasure != null)
                    cmd.Parameters.AddWithValue("UnitOfMeasure", product.UnitOfMeasure);

                cmd.Parameters.AddWithValue("IsActive", product.IsActive);
                if (product.Sequence != null)
                    cmd.Parameters.AddWithValue("Sequence", product.Sequence);
                if (product.IconUrl != null)
                    cmd.Parameters.AddWithValue("IconUrl", product.IconUrl);
                if (product.PictureUrl != null)
                    cmd.Parameters.AddWithValue("PictureUrl", product.PictureUrl);
                if (product.Comment != null)
                    cmd.Parameters.AddWithValue("Comment", product.Comment);

                cmd.Parameters.AddWithValue("CreatedDate", product.CreatedDate);
                if (product.CreatedBy != null)
                    cmd.Parameters.AddWithValue("CreatedBy", product.CreatedBy);
                if (product.LastModifiedBy != null)
                    cmd.Parameters.AddWithValue("LastModifiedBy", product.LastModifiedBy);
                if (product.LastModifiedDate != null)
                    cmd.Parameters.AddWithValue("LastModifiedDate", product.LastModifiedDate);

                cmd.ExecuteNonQuery();

            }

        }


        public Product GetById(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_GetById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                Product product;
                while (reader.Read())
                {
                    product = new Product(reader.GetInt32(1));
                    product.Id = reader.GetInt32(0);
                    //product.CategoryId = reader.GetInt32(1);
                    product.Name = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        product.UnitPrice = reader.GetDecimal(3);
                    if (!reader.IsDBNull(4))
                        product.StockQuantity = reader.GetDecimal(4);
                    if (!reader.IsDBNull(5))
                        product.Description = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                        product.UnitOfMeasure = reader.GetString(6);
                    
                    product.IsActive = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                        product.Sequence = reader.GetInt32(8);
                    if (!reader.IsDBNull(9))
                        product.IconUrl = reader.GetString(9);
                    if (!reader.IsDBNull(10))
                        product.PictureUrl = reader.GetString(10);
                    if (!reader.IsDBNull(11))
                        product.Comment = reader.GetString(11);

                    product.CreatedDate = reader.GetDateTime(12);
                    if (!reader.IsDBNull(13))
                        product.CreatedBy = reader.GetString(13);
                    if (!reader.IsDBNull(14))
                        product.LastModifiedBy = reader.GetString(14);
                    if (!reader.IsDBNull(15))
                        product.LastModifiedDate = reader.GetDateTime(15);

                    return product;
                }

                return null;
                
            }

        }


        public Product GetByName(string name)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Product_GetByName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", name);

                SqlDataReader reader = cmd.ExecuteReader();
                Product product;
                while (reader.Read())
                {
                    product = new Product(reader.GetInt32(1));
                    product.Id = reader.GetInt32(0);
                    //product.CategoryId = reader.GetInt32(1);
                    product.Name = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        product.UnitPrice = reader.GetDecimal(3);
                    if (!reader.IsDBNull(4))
                        product.StockQuantity = reader.GetDecimal(4);
                    if (!reader.IsDBNull(5))
                        product.Description = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                        product.UnitOfMeasure = reader.GetString(6);

                    product.IsActive = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                        product.Sequence = reader.GetInt32(8);
                    if (!reader.IsDBNull(9))
                        product.IconUrl = reader.GetString(9);
                    if (!reader.IsDBNull(10))
                        product.PictureUrl = reader.GetString(10);
                    if (!reader.IsDBNull(11))
                        product.Comment = reader.GetString(11);

                    product.CreatedDate = reader.GetDateTime(12);
                    if (!reader.IsDBNull(13))
                        product.CreatedBy = reader.GetString(13);
                    if (!reader.IsDBNull(14))
                        product.LastModifiedBy = reader.GetString(14);
                    if (!reader.IsDBNull(15))
                        product.LastModifiedDate = reader.GetDateTime(15);

                    return product;

                }
                return null;
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
                    Product product = new Product(reader.GetInt32(1));
                    product.Id = reader.GetInt32(0);
                    product.CategoryId = reader.GetInt32(1);
                    product.Name = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        product.UnitPrice = reader.GetDecimal(3);
                    if (!reader.IsDBNull(4))
                        product.StockQuantity = reader.GetDecimal(4);
                    if (!reader.IsDBNull(5))
                        product.Description = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                        product.UnitOfMeasure = reader.GetString(6);

                    product.IsActive = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                        product.Sequence = reader.GetInt32(8);
                    if (!reader.IsDBNull(9))
                        product.IconUrl = reader.GetString(9);
                    if (!reader.IsDBNull(10))
                        product.PictureUrl = reader.GetString(10);
                    if (!reader.IsDBNull(11))
                        product.Comment = reader.GetString(11);

                    product.CreatedDate = reader.GetDateTime(12);
                    if (!reader.IsDBNull(13))
                        product.CreatedBy = reader.GetString(13);
                    if (!reader.IsDBNull(14))
                        product.LastModifiedBy = reader.GetString(14);
                    if (!reader.IsDBNull(15))
                        product.LastModifiedDate = reader.GetDateTime(15);


                    products.Add(product);
                }
                return products;
            }

        }
    }
}
