#region References
using HWA.ECom.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
#endregion

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

        #region Methods
        public void Insert(Category category)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_Insert", con);//usp_Customer_Insert
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", category.Name);
                if (category.Description != null)
                    cmd.Parameters.AddWithValue("Description", category.Description);
                cmd.Parameters.AddWithValue("IsActive", category.IsActive);
                cmd.Parameters.AddWithValue("Sequence", category.Sequence);
                if (category.CreatedBy != null)
                    cmd.Parameters.AddWithValue("CreateBy", category.CreatedBy);
                cmd.Parameters.AddWithValue("CreateDate", category.CreatedDate);
                if (category.CreatedBy != null)
                    cmd.Parameters.AddWithValue("LastModifiedBy", category.LastModifiedBy);
                if (category.LastModifiedDate != null)
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
                if (category.Description != null)
                    cmd.Parameters.AddWithValue("Description", category.Description);
                cmd.Parameters.AddWithValue("IsActive", category.IsActive);
                cmd.Parameters.AddWithValue("Sequence", category.Sequence);
                if (category.CreatedBy != null)
                    cmd.Parameters.AddWithValue("CreateBy", category.CreatedBy);
                cmd.Parameters.AddWithValue("CreateDate", category.CreatedDate);
                if (category.CreatedBy != null)
                    cmd.Parameters.AddWithValue("LastModifiedBy", category.LastModifiedBy);
                if (category.LastModifiedDate != null)
                    cmd.Parameters.AddWithValue("LastModifiedDate", category.LastModifiedDate);

                cmd.ExecuteNonQuery();

            }

        }


        public Category GetById(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_GetById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                Category category = new Category();
                while (reader.Read())
                {
                    category.Id = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        category.Description = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Sequence = reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                        category.CreatedBy = reader.GetString(5);
                    category.CreatedDate = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7))
                        category.LastModifiedBy = reader.GetString(7);
                    if (!reader.IsDBNull(8))
                        category.LastModifiedDate = reader.GetDateTime(8);

                }
                return category;
            }

        }


        public Category GetByName(string name)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_Category_GetByName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Name", name);

                SqlDataReader reader = cmd.ExecuteReader();
                Category category = new Category();
                while (reader.Read())
                {
                    category.Id = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        category.Description = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Sequence = reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                        category.CreatedBy = reader.GetString(5);
                    category.CreatedDate = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7))
                        category.LastModifiedBy = reader.GetString(7);
                    if (!reader.IsDBNull(8))
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
                    if (!reader.IsDBNull(2))
                        category.Description = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Sequence = reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                        category.CreatedBy = reader.GetString(5);
                    category.CreatedDate = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7))
                        category.LastModifiedBy = reader.GetString(7);
                    if (!reader.IsDBNull(8))
                        category.LastModifiedDate = reader.GetDateTime(8);

                    categorys.Add(category);
                }
                return categorys;
            }

        }
        #endregion
    }
}