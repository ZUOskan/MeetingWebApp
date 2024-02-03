using MeetingApp.BusinessObject.Entity;
using MeetingApp.DataAccess.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
