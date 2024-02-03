using MeetingApp.BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.BusinessObject.EntityCommon
{
    public class MeetingsModule
    {
        public List<Users>? usersList { get; set; }
        public List<Meetings>? meetingsList {  get; set; }
    }
}
