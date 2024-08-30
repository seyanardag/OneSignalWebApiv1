using Microsoft.AspNetCore.Http.HttpResults;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;
using OneSignalWebApiv1.Context;
using System.Diagnostics;

namespace OneSignalWebApiv1.Services
{
    public class CustomScheduleReminderService
    {
        private readonly DefaultApi _client;
        private readonly string _appId;
        private readonly OneSignalDbContext _context;
        public CustomScheduleReminderService(string appId, string oneSignalApiKey, OneSignalDbContext context)
        {
            _appId = appId;
            var appConfig = new Configuration
            {
                BasePath = "https://onesignal.com/api/v1",
                AccessToken = oneSignalApiKey
            };
            _client = new DefaultApi(appConfig);
            _context = context;
        }


        public async Task CreateAndSendNotificationAsync(string heading, string message, List<string> playerIds)
        {
            // Bildirim oluşturma
            var notification = new Notification(appId: _appId)
            {
                // Bildirim başlığı                
                Headings = new StringMap { En = heading },
                // Bildirim içeriği
                Contents = new StringMap { En = message },
                // Hedef kitle           
                IncludeExternalUserIds = playerIds,


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
       
         //Dersi yaklaşan kullanıcıya bildirim gönderilmesi
        public Task SendNotificationToCustomScheduled(string heading, string message)
        {
            var startTimeSpan = TimeSpan.Zero;

            //Test amaçlı 10 saniye seçildi, normalde alt satırdaki 15 dakika aktif olacak
            var periodTimeSpan = TimeSpan.FromSeconds(10);
            //var periodTimeSpan = TimeSpan.FromMinutes(15);

            var timer = new System.Threading.Timer((e) =>
            {
                var context = new OneSignalDbContext();

                List<string> playerIds = new List<string>();

                //Öğrencinin kendi hazırladığı dersin başlamasına son 10 dk dan az kaldığının hesaplanması
                var last10minToSchedule = context.CustomSchedules.Where(x => x.ScheduleDate < DateTime.UtcNow.AddMinutes(10)).ToList();

                //Timer ın çalıştığını kontrol etmek için;
                System.Diagnostics.Debug.WriteLine("calisti");
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());

                    
                    if (last10minToSchedule.Any())
                    {
                        playerIds.AddRange(last10minToSchedule.Select(x => x.GUID.ToString()));                       
                        CreateAndSendNotificationAsync(heading, message, playerIds);
                    }

            }, null, startTimeSpan, periodTimeSpan);

            return Task.CompletedTask;

        }        

    }
}
