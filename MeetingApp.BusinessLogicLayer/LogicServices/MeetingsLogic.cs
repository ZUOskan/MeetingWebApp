using MeetingApp.BusinessObject.Entity;
using MeetingApp.DataAccess.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeetingApp.BusinessLogic.LogicServices
{
    public class MeetingsLogic : IMeetingsLogic
    {
        private readonly IMeetingsDataAccess _meetingsDataAccess;
        public MeetingsLogic(IMeetingsDataAccess meetingsDataAccess)
        {
            _meetingsDataAccess = meetingsDataAccess;
        }   

        public List <Meetings> GetMeetingsListLogic(string UserID)
        { 
            List <Meetings> output = new List<Meetings> ();

            output = _meetingsDataAccess.GetMeetingsFromDB(UserID);
            return output;
        }
		public Meetings GetMeetingsByIDLogic(string UserID, int MeetingID)
		{
			Meetings output = new Meetings();

			output = _meetingsDataAccess.GetMeetingsFromDBByID(UserID, MeetingID);
			return output;
		}


		public string InsertMeetingRecordToDBLogic(string UserID, Meetings UserInput, int MeetingID = -1)
        {
            string result = string.Empty;

            
            //if  (UserInput.MeetingStartDate.Date <  DateTime.Now.Date) 
            //{
            //    result = "Start date cannot be earlier than today.";
            //    return result;
            //}

            if (UserInput.MeetingStartDate > UserInput.MeetingFinishDate)
            {
                result = "Start date cannot be later than finish date";
                return result;
            }
            if (MeetingID != -1)
            {
                result = _meetingsDataAccess.InsertMeetingRecordIntoDB(UserID, UserInput, MeetingID);
            }
            else
            {
                result = _meetingsDataAccess.InsertMeetingRecordIntoDB(UserID, UserInput);
            }

            if (result == "Meeting successfully recorded to the database.")
            {
                return result;
            }
            else
            {
                result = "There was an error saving the meeting.";
                return result;
            }
        }

		public string DeleteMeetingRecordFromDBLogic(int MeetingID)
        {
            string result = string.Empty;
			result = _meetingsDataAccess.DeleteMeetingRecordFromDB(MeetingID);
			if (result == "Meeting successfully deleted from the database.")
			{
				return result;
			}
			else
			{
				result = "There was an error deleting the meeting.";
				return result;
			}
		}


	}
}
