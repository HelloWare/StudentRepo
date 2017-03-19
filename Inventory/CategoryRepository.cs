using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWA.ECom.Entity;
using System.Data.SqlClient;

namespace HWA.ECom.Repository
{
    public class CategoryRepository
    {
        #region Fields
        private string _connectionString;
        #endregion

        #region Constructor

        public CategoryRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion

        public void Insert(Category category)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_Insert", con);//usp_Customer_Insert
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", category.Name);
                cmd.Parameters.AddWithValue("Description", category.Description);
                cmd.Parameters.AddWithValue("IsActive", category.IsActive);
                cmd.Parameters.AddWithValue("Sequence", category.Sequence);
                cmd.Parameters.AddWithValue("CreateBy", category.CreateBy);
                cmd.Parameters.AddWithValue("CreateDate", category.CreateDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", category.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", category.LastModifiedDate);

                cmd.ExecuteNonQuery();
            }

        }


        public Boolean Delete(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_Delete", con);
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


        public void Update(Category category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", category.Id);
                cmd.Parameters.AddWithValue("Name", category.Name);
                cmd.Parameters.AddWithValue("Description", category.Description);
                cmd.Parameters.AddWithValue("IsActive", category.IsActive);
                cmd.Parameters.AddWithValue("Sequence", category.Sequence);
                cmd.Parameters.AddWithValue("CreateBy", category.CreateBy);
                cmd.Parameters.AddWithValue("CreateDate", category.CreateDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", category.LastModifiedBy);
                cmd.Parameters.AddWithValue("LastModifiedDate", category.LastModifiedDate);

                cmd.ExecuteNonQuery();

            }

        }


        public Category Get(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_Get", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                Category category = new Category();
                while (reader.Read())
                {
                    category.Id = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.Description = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Sequence = reader.GetInt32(4);
                    category.CreateBy = reader.GetString(5);
                    category.CreateDate = reader.GetDateTime(6);
                    category.LastModifiedBy = reader.GetString(7);
                    category.LastModifiedDate = reader.GetDateTime(8);
                    
                }
                return category;
            }

        }


        public List<Category> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Category> categorys = new List<Category>();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.Id = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.Description = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Sequence = reader.GetInt32(4);
                    category.CreateBy = reader.GetString(5);
                    category.CreateDate = reader.GetDateTime(6);
                    category.LastModifiedBy = reader.GetString(7);
                    category.LastModifiedDate = reader.GetDateTime(8);

                    categorys.Add(category);
                }
                return categorys;
            }

        }
    }
}
