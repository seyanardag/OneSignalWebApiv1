using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalWebApiv1.Services;

//namespace OneSignalWebApiv1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomScheduleReminderController : ControllerBase
//    {
//        private readonly CustomScheduleReminderService _customScheduleReminderService;

//        public CustomScheduleReminderController(CustomScheduleReminderService customScheduleReminderService)
//        {
//            _customScheduleReminderService = customScheduleReminderService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> CustomScheduleReminder()
//        {
//            _customScheduleReminderService.SendNotificationToCustomScheduled("başlık", "mesaj");
//            return Ok();
//        }


//    }
//}
