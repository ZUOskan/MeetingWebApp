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

        public List <Meetings> GetMeetingsListLogic()
        { 
            List <Meetings> output = new List<Meetings> ();

            output = _meetingsDataAccess.GetMeetingsFromDB();
            return output;
        }

        public string InsertMeetingRecordToDB(Meetings UserInput)
        {
            string result = string.Empty;
            if  (UserInput.MeetingStartDate.Date <  DateTime.Now.Date) 
            {
                result = "Start date cannot be earlier than today.";
                return result;
            }
            if (UserInput.MeetingStartDate > UserInput.MeetingFinishDate)
            {
                result = "Start date cannot be later than finish date";
                return result;
            }

            result = _meetingsDataAccess.InsertMeetingRecordIntoDB(UserInput);
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


        //Usersa taşınacak
        private static bool IsEmailValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
