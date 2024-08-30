using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

//KULLANICI OLUŞTURMA ESNASINDA PROBLEM VAR, BU PROBLEM DAHA SONRA ÇÖZÜLECEKTİR

//namespace OneSignalWebApiv1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AddUser3Controller : ControllerBase
//    {
//        [HttpGet("GetUser3")]
//        public async Task<IActionResult> AddUser3()
//        {
//            var client = new HttpClient();
//            var request = new HttpRequestMessage
//            {
//                Method = HttpMethod.Post,
//                RequestUri = new Uri("https://api.onesignal.com/apps/1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65/users"),
//                Headers =
//                {
//                    { "accept", "application/json" },
//                },
//                Content = new StringContent("{\"properties\":{\"tags\":\"string\",\"language\":\"en\",\"timezone_id\":\"America\\\\/Los_Angeles\",\"lat\":90,\"long\":135,\"country\":\"US\",\"first_active\":1678215680,\"last_active\":1678215682,\"ip\":\"string\"},\"identity\":{\"external_id\":\"test_external_id\",\"onesignal_id\":\"string\"},\"subscriptions\":[{\"type\":\"iOSPush\",\"token\":\"pushToken,email,OR,phoneNumber\",\"enabled\":true,\"notification_types\":0,\"session_time\":60,\"session_count\":1,\"app_version\":\"1.0.0\",\"device_model\":\"iPhone 14\",\"device_os\":\"16.0.0\",\"test_type\":0,\"sdk\":\"5.0.0\",\"rooted\":false,\"web_auth\":\"string\",\"web_p256\":\"string\"}]}")
//                {
//                    Headers =
//        {
//            ContentType = new MediaTypeHeaderValue("application/json")
//        }
//                }
//            };
//            using (var response = await client.SendAsync(request))
//            {
//                response.EnsureSuccessStatusCode();
//                var body = await response.Content.ReadAsStringAsync();
//               System.Diagnostics.Debug.WriteLine(body);
//            }

//            return Ok();
//        }
//    }
//}
