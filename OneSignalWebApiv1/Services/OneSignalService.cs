using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;
using System.Diagnostics;

namespace OneSignalWebApiv1.Services
{
    public class OneSignalService
    {
        private readonly DefaultApi _client;
        private string _appId;
        public OneSignalService(string appId, string oneSignalApiKey)
        {
            _appId = appId;
            var appConfig = new Configuration
            {
                BasePath = "https://onesignal.com/api/v1",
                AccessToken = oneSignalApiKey
            };
            _client = new DefaultApi(appConfig);
        }
            

        public async Task CreateAndSendNotificationAsync(string heading, string message, List<string> segments) 
        {
            // Bildirim oluşturma
            var notification = new Notification(appId: _appId)
            {
                // Bildirim başlığı                
                Headings = new StringMap { En = heading },
                // Bildirim içeriği
                Contents = new StringMap { En = message },
                // Hedef kitle           
                IncludedSegments = segments,

            };

            try
            {               
                CreateNotificationSuccessResponse result = await _client.CreateNotificationAsync(notification);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //Bütün kayıtlı kullanıcılara 
        public Task SendNotificationToTotalSubscribtions(string heading, string message)
        {
            var segments = new List<string> { "Total Subscriptions" };
            return CreateAndSendNotificationAsync(heading, message, segments);
         
        }

        //son 3 gündür giriş yapmayan kullanıcılara
        public Task SendNotificationToPassiveForLast3Days(string heading, string message) 
        {
            var segments = new List<string> { "son 3 gun aktif olmayanlar" };
            return CreateAndSendNotificationAsync(heading, message, segments);
        }



    }
}


