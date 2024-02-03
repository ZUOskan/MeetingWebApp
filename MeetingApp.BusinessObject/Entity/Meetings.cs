using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.BusinessObject.Entity
{
    public class Meetings
    {
        public int MeetingID { get; set; }
        public string MeetingTitle { get; set; }
        public DateTime MeetingStartDate { get; set; }
        public DateTime MeetingFinishDate { get; set; }
        public string MeetingDescription { get; set; }
        public string MeetingDocument { get; set; }
        public int AttendeeID { get; set; }

    }
}
