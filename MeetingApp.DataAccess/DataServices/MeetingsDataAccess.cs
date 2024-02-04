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


		public Meetings GetMeetingsFromDBByID(string UserID, int MeetingID)
		{
			Meetings meeting = new Meetings();

			try
			{
				using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
				{

					string SqlQuery = "SELECT * FROM MeetingManagement.Meetings" +
						" WHERE MeetingOwner = '" + UserID + "' AND MeetingID = '" + MeetingID + "'";

                    meeting = dbConnection.QuerySingle<Meetings>(SqlQuery, commandType: CommandType.Text);
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}

			return meeting;
		}

		public string InsertMeetingRecordIntoDB(string UserID, Meetings UserInput, int MeetingID = -1)
        {
            string result = string.Empty;

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = string.Empty;
                    if (MeetingID != -1)
                    {
                        SqlQuery = @"UPDATE  MeetingManagement.Meetings
                                          SET MeetingTitle = @MeetingTitle, MeetingStartDate = @MeetingStartDate, MeetingFinishDate = @MeetingFinishDate, MeetingDescription = @MeetingDescription, MeetingDocumentName = @MeetingDocumentName, MeetingDocumentContent = @MeetingDocumentContent, MeetingOwner = @MeetingOwner
                                          WHERE MeetingID =" + MeetingID;
                    }
                    else
                    {
                        SqlQuery = @"INSERT INTO MeetingManagement.Meetings(MeetingTitle, MeetingStartDate, MeetingFinishDate, MeetingDescription, MeetingDocumentName, MeetingDocumentContent, MeetingOwner)
                                          VALUES(@MeetingTitle, @MeetingStartDate, @MeetingFinishDate, @MeetingDescription, @MeetingDocumentName, @MeetingDocumentContent, @MeetingOwner)";
                    }

                    dbConnection.Execute(SqlQuery,
                        new
                        {
                            MeetingTitle = UserInput.MeetingTitle != null ? UserInput.MeetingTitle : default(string),
                            MeetingStartDate = UserInput.MeetingStartDate,
                            MeetingFinishDate = UserInput.MeetingFinishDate,
                            MeetingDescription = UserInput.MeetingDescription.ToString() != null ? UserInput.MeetingDescription.ToString() : default(string),
                            MeetingDocumentName = UserInput.MeetingDocumentName.ToString() != null ? UserInput.MeetingDocumentName.ToString() : default(string),
                            MeetingDocumentContent = UserInput.MeetingDocumentContent != null ? UserInput.MeetingDocumentContent : default(byte[]), 
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