using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoomMeeting.Models
{
    public class MeetingModel
    {
        public string Topic { get; set; }
        public bool Location { get; set; }
        public string HostId { get; set; }
        public string Id { get; set; }
    }
}