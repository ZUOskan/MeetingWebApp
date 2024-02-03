using Dapper;
using MeetingApp.BusinessObject.Entity;
using MeetingApp.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.DataAccess.DataServices
{
    public class MeetingsDataAccess : IMeetingsDataAccess
    {

        private readonly IDapperOrmHelper _dapperOrmHelper;
        public MeetingsDataAccess(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }

        public List<Meetings> GetMeetingsFromDB() 
        {
            List <Meetings> meetings = new List<Meetings>();

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "SELECT * FROM Meetings ";
                    meetings = dbConnection.Query<Meetings>(SqlQuery,commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex) 
            {
                string message = ex.Message;
            }

            return meetings;
        }
    }
}
