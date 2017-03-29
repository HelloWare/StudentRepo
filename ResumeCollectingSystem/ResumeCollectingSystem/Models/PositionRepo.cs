using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ResumeCollectingSystem.Models
{
    public static class PositionRepo
    {

        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static IEnumerable<Position> GetAll()
        {
            List<Position> positions = new List<Position>();
            string cmdText = "Select * From [Position]";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Position position = new Position();
                        position.Id = Convert.ToInt32(reader["Id"]);
                        position.Name = Convert.ToString(reader["Name"]);
                        positions.Add(position);
                    }
                }
            }
            return positions;
        }
    }
}