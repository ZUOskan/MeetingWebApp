using MeetingApp.BusinessLogic.LogicServices;
using MeetingApp.BusinessObject.Entity;
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
        public IActionResult MeetingsList()
        {
            // Get the list of meetings from DB
            List<Meetings> output = new List<Meetings>();

            output = _meetingsLogic.GetMeetingsListLogic().ToList();
            
            return View();
        }
    }
}
