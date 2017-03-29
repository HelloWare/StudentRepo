using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ResumeCollectingSystem.Models
{
    public static class DegreeRepo
    {

        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static IEnumerable<Degree> GetAll()
        {
            List<Degree> degrees = new List<Degree>();
            string cmdText = "Select * From [Degree]";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Degree degree = new Degree();
                        degree.Id = Convert.ToInt32(reader["Id"]);
                        degree.Name = Convert.ToString(reader["Name"]);
                        degrees.Add(degree);
                    }
                }
            }
            return degrees;
        }
    }
}