using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ResumeCollectingSystem.Models
{
    public static class GenderRepo
    {

        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static IEnumerable<Gender> GetAll()
        {
            List<Gender> genders = new List<Gender>();
            string cmdText = "Select * From [Gender]";
            using (SqlConnection con = new SqlConnection(conString))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Gender gender = new Gender();
                        gender.Id = Convert.ToInt32(reader["Id"]);
                        gender.Name = Convert.ToString(reader["Name"]);
                        genders.Add(gender);
                    }
                }
            }
            return genders;
        }
    }
}