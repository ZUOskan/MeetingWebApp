using MeetingApp.BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.DataAccess.DataServices
{
    public interface IMeetingsDataAccess
    {
        List<Meetings> GetMeetingsFromDB(string UserID);
        string InsertMeetingRecordIntoDB(string UserID, Meetings UserInput);
        string DeleteMeetingRecordFromDB(int MeetingID);


    }
}
