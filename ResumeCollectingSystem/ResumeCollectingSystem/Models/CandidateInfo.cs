using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeCollectingSystem.Models
{
    public class CandidateInfo
    {
        public CandidateInfo(string FirstName, string LastName, string Email, string Major, int DegreeId, int GenderId, int PositionId, bool IsResumeUploaded)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Major = Major;
            this.DegreeId = DegreeId;
            this.GenderId = GenderId;
            this.PositionId = PositionId;
            this.IsResumeUploaded = IsResumeUploaded;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }

        [Display(Name = "Degree")]
        public int DegreeId { get; set; }
        public int GenderId { get; set; }
        public int PositionId { get; set; }
        public bool IsResumeUploaded { get; set; }
    }
}