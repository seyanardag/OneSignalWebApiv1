using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalApi.Model;
using System.Text;

//KULLANICI OLUŞTURMA ESNASINDA PROBLEM VAR, BU PROBLEM DAHA SONRA ÇÖZÜLECEKTİR

//namespace OneSignalWebApiv1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AddUserController : ControllerBase
//    {
//        private readonly HttpClient _httpClient;

//        public AddUserController(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        [HttpPost("create-user")]
//        public async Task<IActionResult> CreateUser()
//        {

//            string appId = "your_app_id";
//            string oneSignalApiKey = "your_api_key";

//            var json = @"
//            {
//                ""properties"": {
//                    ""country"": ""US"",
//                    ""tags"": {
//                        ""favorite_team"": ""Lakers""
//                    },
//                    ""language"": ""EN""
//                },
//                ""identity"": {
//                    ""external_id"": ""test""
//                }
//            }";

//            var requestUri = new Uri($"https://api.onesignal.com/apps/{"1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65"}/users");

//            var request = new HttpRequestMessage
//            {
//                Method = HttpMethod.Post,
//                RequestUri = requestUri,
//                Headers =
//                {
//                    { "accept", "application/json" },
//                    { "Authorization", $"Basic {"N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy"}" } // API anahtarınızı Authorization header'a ekleyin
//                },
//                Content = new StringContent(json, Encoding.UTF8, "application/json")
//            };

//            try
//            {

//                var response = await _httpClient.SendAsync(request);
//                response.EnsureSuccessStatusCode();


//                var body = await response.Content.ReadAsStringAsync();
//                return Ok(body);
//            }
//            catch (HttpRequestException e)
//            {
//                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, e.Message);
//            }
//        }
//    }
//}
