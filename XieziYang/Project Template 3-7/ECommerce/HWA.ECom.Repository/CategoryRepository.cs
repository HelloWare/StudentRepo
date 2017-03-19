using HWA.ECom.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Repository
{
    public class CategoryRepository
    {
        #region Fields
        private String _connectionString;
        #endregion

        #region Constructors
        public CategoryRepository()
        {
        }
        public CategoryRepository(String connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion

        //CRUD, 
        public Boolean Insert(Category category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_InsertCategory", con);
                cmd.Parameters.AddWithValue("Name", category.Name);
                cmd.Parameters.AddWithValue("Description", category.Description);
                cmd.Parameters.AddWithValue("IsActive", category.IsActive);
                cmd.Parameters.AddWithValue("Sequence", category.Sequence);
                //Add more parameters from SP

                Int32 id = cmd.ExecuteNonQuery();

                if (id > 0)
                {
                    category.Id = id;
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
                SqlCommand cmd = new SqlCommand("usp_ECom_DeleteCategory", con);
                cmd.Parameters.AddWithValue("Id", id);

                Int32 counts = cmd.ExecuteNonQuery();

                if (counts > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Category Get(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_GetCategory", con);
                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                Category category = new Category();
                while (reader.Read())
                {
                    category.Id = Convert.ToInt32(reader["Id"]);
                    category.Name = Convert.ToString(reader["Name"]);
                    //TO BE DONE, ORM process, map table data to class object

                }
                return category;
            }
        }

    }
}
