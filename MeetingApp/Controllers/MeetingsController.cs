using MeetingApp.BusinessLogic.LogicServices;
using MeetingApp.BusinessObject.Entity;
using MeetingApp.BusinessObject.EntityCommon;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IMeetingsLogic _meetingsLogic;
        public MeetingsController(IMeetingsLogic meetingsLogic)
        {
            _meetingsLogic = meetingsLogic;
        }

        [HttpGet]
        [ActionName("MeetingsList")]
        public IActionResult MeetingsList()
        {

            MeetingsModule model = new MeetingsModule();
            // Get the list of meetings from DB

            model.meetingsList = _meetingsLogic.GetMeetingsListLogic().ToList();
            
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
        public IActionResult PostMeeting(Meetings UserInput)
        {
            //Insert the meeting into the DB
            string result = _meetingsLogic.InsertMeetingRecordToDB(UserInput);
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


    }
}
