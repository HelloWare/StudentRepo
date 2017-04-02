using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ResumeCollectingSystem.Models
{
    public class UserRoleModel
    {
        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }

    public class UserRoleModelRepo
    {
        private string connectionString;
        public UserRoleModelRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Save(string userId, string roleId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = "INSERT INTO[dbo].[AspNetUserRoles] ([UserId],[RoleId])VALUES('"+userId+"','"+roleId+"')";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}