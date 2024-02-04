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
        Meetings GetMeetingsByIDLogic(string UserID, int MeetingID);

		string InsertMeetingRecordToDBLogic(string UserID, Meetings UserInput, int MeetingID = -1);
        string DeleteMeetingRecordFromDBLogic(int MeetingID);

	}
}
