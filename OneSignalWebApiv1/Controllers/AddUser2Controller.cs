using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

//KULLANICI OLUŞTURMA ESNASINDA PROBLEM VAR, BU PROBLEM DAHA SONRA ÇÖZÜLECEKTİR

//namespace OneSignalWebApiv1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AddUser2Controller : ControllerBase
//    {


//        [HttpGet]
//        public async Task<IActionResult> AddUser()
//        {
//            var appId = "1af6fc63-a7de-4ccc-8f67-7a6a2a14bd65";
//            var apiKey = "N2Q5ZmYxNzgtYzEwZi00ZGM3LTliNDYtMzAzZTE1OTEyM2Iy"; // Gerçek API anahtarınızla değiştirin

//            var client = new HttpClient();
//            var request = new HttpRequestMessage
//            {
//                Method = HttpMethod.Post,
//                RequestUri = new Uri($"https://api.onesignal.com/apps/{appId}/users"),
//                Headers =
//                {
//                    { "accept", "application/json" },
//                    { "Authorization", $"Basic {apiKey}" }
//                },
//                Content = new StringContent(JsonSerializer.Serialize(new
//                {
//                    properties = new
//                    {
//                        tags = "string",
//                        language = "en",
//                        timezone_id = "America/Los_Angeles",
//                        latitude = 90, // 'lat' yerine 'latitude' kullanıldı
//                        longitude = 135, // 'long' yerine 'longitude' kullanıldı
//                        country = "US",
//                        first_active = 1678215680,
//                        last_active = 1678215682,
//                        ip = "string"
//                    },
//                    identity = new
//                    {
//                        external_id = "test_external_id",
//                        onesignal_id = "string"
//                    },
//                    subscriptions = new[]
//                    {
//                        new
//                        {
//                            type = "iOSPush",
//                            token = "pushToken,email,OR,phoneNumber",
//                            enabled = true,
//                            notification_types = 0,
//                            session_time = 60,
//                            session_count = 1,
//                            app_version = "1.0.0",
//                            device_model = "iPhone 14",
//                            device_os = "16.0.0",
//                            test_type = 0,
//                            sdk = "5.0.0",
//                            rooted = false,
//                            web_auth = "string",
//                            web_p256 = "string"
//                        }
//                    }
//                }), Encoding.UTF8, "application/json")
//            };

//            try
//            {
//                using (var response = await client.SendAsync(request))
//                {
//                    response.EnsureSuccessStatusCode();
//                    var body = await response.Content.ReadAsStringAsync();
//                    // Başarı durumunda yanıtı loglayın veya işleyin
//                    System.Diagnostics.Debug.WriteLine(body);
//                }
//            }
//            catch (HttpRequestException ex)
//            {
//                // Hata durumunda detaylı bir mesaj yazdırın
//                System.Diagnostics.Debug.WriteLine($"Hata: {ex.Message}");
//                return StatusCode(StatusCodes.Status500InternalServerError, "Bir hata oluştu.");
//            }

//            return Ok();
//        }
//    }


//    }

