using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ResumeCollectingSystem.Models
{
    public static class CandidateInfoRepo
    {
        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static int Insert(CandidateInfo candidateInfo)
        {

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string cmdText;
                if (candidateInfo.PhoneNumber == null)
                {
                    cmdText = String.Format("INSERT INTO [dbo].[CandidateInfo]([FirstName],[LastName],[Email],[Major],[DegreeId],[GenderId],[PositionId],[IsResumeUploaded])VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');SELECT SCOPE_IDENTITY() ", candidateInfo.FirstName, candidateInfo.LastName, candidateInfo.Email, candidateInfo.Major, candidateInfo.DegreeId, candidateInfo.GenderId, candidateInfo.PositionId, candidateInfo.IsResumeUploaded);
                }
                else
                {
                    cmdText = String.Format("INSERT INTO [dbo].[CandidateInfo]([FirstName],[LastName],[Email],[PhoneNumber],[Major],[DegreeId],[GenderId],[PositionId],[IsResumeUploaded])VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');SELECT SCOPE_IDENTITY()", candidateInfo.FirstName, candidateInfo.LastName, candidateInfo.Email, candidateInfo.PhoneNumber, candidateInfo.Major, candidateInfo.DegreeId, candidateInfo.GenderId, candidateInfo.PositionId, candidateInfo.IsResumeUploaded);
                }
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}