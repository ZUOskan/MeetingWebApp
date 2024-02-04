using MeetingApp.Areas.Identity.Data;
using MeetingApp.BusinessLogic.LogicServices;
using MeetingApp.BusinessObject.Entity;
using MeetingApp.BusinessObject.EntityCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    [Authorize]
    public class MeetingsController : Controller
    {
        private readonly IMeetingsLogic _meetingsLogic;
        private readonly UserManager<ApplicationUser> _userManager;
        public MeetingsController(IMeetingsLogic meetingsLogic, UserManager<ApplicationUser> userManager)
        {
            _meetingsLogic = meetingsLogic;
            this._userManager = userManager;
        }

        [HttpGet]
        [ActionName("MeetingsList")]
        public IActionResult MeetingsList()
        {

            MeetingsModule model = new MeetingsModule();
            // Get the list of meetings from DB
            // Get UserID so we can filter the meetings list by the logged in User's meetings and not all meetings
            string UserID = _userManager.GetUserId(this.User);
            model.meetingsList = _meetingsLogic.GetMeetingsListLogic(UserID).ToList();
            
            return View(model);
        }

        [HttpGet]
        [ActionName("InsertMeeting")]
        public IActionResult InsertMeeting()
        {
            return View();
        }

        [HttpPost]
        [ActionName("PostMeeting")]
        public IActionResult PostMeeting(Meetings UserInput, IFormFile file)
        {
            string UserID = _userManager.GetUserId(this.User);
            //Insert the meeting into the DB
            string result = _meetingsLogic.InsertMeetingRecordToDBLogic(UserID, UserInput);
            if (result == "Meeting successfully recorded to the database.")
            {
                return RedirectToAction("MeetingsList", "Meetings");
            }
            else
            {
                TempData["ErrorTemp"] = result;
                return RedirectToAction("InsertMeeting", "Meetings");
            }
        }

		[HttpGet]
		[ActionName("MeetingDetails")]
		public IActionResult MeetingDetails(int MeetingID)
		{
			string UserID = _userManager.GetUserId(this.User);
            Meetings model = _meetingsLogic.GetMeetingsListLogic(UserID).ToList().FirstOrDefault(c => c.MeetingID == MeetingID);
            return View(model);
		}

        [HttpGet]
        [ActionName("DeleteMeeting")]
        public IActionResult DeleteMeeting(int MeetingID)
        {
            string UserID = _userManager.GetUserId(this.User);
            Meetings model = _meetingsLogic.GetMeetingsListLogic(UserID).ToList().FirstOrDefault(c => c.MeetingID == MeetingID);
            return View(model);
        }

        [HttpPost]
		[ActionName("DeleteMeetingConfirmed")]
		public IActionResult DeleteMeetingConfirmed(int MeetingID)
		{
			string UserID = _userManager.GetUserId(this.User);
			//Insert the meeting into the DB
			string result = _meetingsLogic.DeleteMeetingRecordFromDBLogic(MeetingID);
			if (result == "Meeting successfully deleted from the database.")
			{
				return RedirectToAction("MeetingsList", "Meetings");
			}
			else
			{
				TempData["ErrorTemp"] = result;
				return RedirectToAction("DeleteMeeting", "Meetings", new {MeetingID = MeetingID});
			}
		}


	}
}
