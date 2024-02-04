using MeetingApp.BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.BusinessLogic.LogicServices
{
    public interface IMeetingsLogic
    {
        List<Meetings> GetMeetingsListLogic(String UserID);
        string InsertMeetingRecordToDBLogic(string UserID, Meetings UserInput);
        string DeleteMeetingRecordFromDBLogic(int MeetingID);

	}
}
