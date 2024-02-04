using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.BusinessObject.Entity
{
    public class Meetings
    {
        [Key] public int MeetingID { get; set; }
        public string MeetingTitle { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")] public DateTime MeetingStartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")] public DateTime MeetingFinishDate { get; set; }
        public string MeetingDescription { get; set; }
        public string MeetingDocument { get; set; }
        public string MeetingOwner{ get; set; }

    }
}
