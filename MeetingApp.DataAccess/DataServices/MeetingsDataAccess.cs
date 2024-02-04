using Dapper;
using MeetingApp.BusinessObject.Entity;
using MeetingApp.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeetingApp.DataAccess.DataServices
{
    public class MeetingsDataAccess : IMeetingsDataAccess
    {

        private readonly IDapperOrmHelper _dapperOrmHelper;
        public MeetingsDataAccess(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }

        public List<Meetings> GetMeetingsFromDB(string UserID)
        {
            List<Meetings> meetings = new List<Meetings>();

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    
                    string SqlQuery = "SELECT * FROM MeetingManagement.Meetings" +
                        " WHERE MeetingOwner = '" + UserID + "'";

                    meetings = dbConnection.Query<Meetings>(SqlQuery, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return meetings;
        }

        public string InsertMeetingRecordIntoDB(string UserID, Meetings UserInput)
        {
            string result = string.Empty;

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = @"INSERT INTO MeetingManagement.Meetings(MeetingTitle, MeetingStartDate, MeetingFinishDate, MeetingDescription, MeetingDocument, MeetingOwner)VALUES(@MeetingTitle, @MeetingStartDate, @MeetingFinishDate, @MeetingDescription, @MeetingDocument, @MeetingOwner)";
                    dbConnection.Execute(SqlQuery,
                        new
                        {
                            MeetingTitle = UserInput.MeetingTitle != null ? UserInput.MeetingTitle : default(string),
                            MeetingStartDate= UserInput.MeetingStartDate,
                            MeetingFinishDate = UserInput.MeetingFinishDate,
                            MeetingDescription = UserInput.MeetingDescription.ToString() != null ? UserInput.MeetingDescription.ToString() : default(string),
                            MeetingDocument = UserInput.MeetingDocument != null ? UserInput.MeetingDocument.ToString() : default(string), 
                            MeetingOwner = UserID
                        }, commandType: CommandType.Text);
                    result = "Meeting successfully recorded to the database.";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
		public string DeleteMeetingRecordFromDB(int MeetingID)
		{
			string result = string.Empty;

			try
			{
				using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
				{
					string SqlQuery = @"DELETE FROM MeetingManagement.Meetings WHERE MeetingID = @MeetingID";
					dbConnection.Execute(SqlQuery,
						new
						{
							MeetingID = MeetingID != null ? MeetingID : default(int)
						}, commandType: CommandType.Text);
					result = "Meeting successfully deleted from the database.";
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
			return result;
		}
	}
}