using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;
using OneSignalWebApiv1.Context;

namespace OneSignalWebApiv1.Services
{
    public class OneSignalServiceSpecificUsers
    {
        private readonly DefaultApi _client;
        private string _appId;
        public OneSignalServiceSpecificUsers(string appId, string oneSignalApiKey)
        {
            _appId = appId;
            var appConfig = new Configuration
            {
                BasePath = "https://onesignal.com/api/v1",
                AccessToken = oneSignalApiKey
            };
            _client = new DefaultApi(appConfig);
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
                // bu özellik depreceted olmuş ama hala kullanılabilior, doğrudan bunu karşılayan başka bir metod şu anda yok.
                IncludePlayerIds = playerIds

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
        //Manuel olarak belirlenen kullanıcılara bildirim gönderilmesi
        public Task SendNotificationSpecificUser(string heading, string message)
        {
            var playerIds = new List<string> { "089ca095-f63c-4650-8148-6bcb72ffb3d4" };
            return CreateAndSendNotificationAsync(heading, message, playerIds);

        }


        //Dersi yaklaşan kullanıcıya bildirim gönderilmesi
        public Task SendNotificationToCustomScheduled(string heading, string message)
        {
            var startTimeSpan = TimeSpan.Zero;
            heading = "DERS YAKLAŞTI";
            message = "Planlı dersiniz için son 15 dakika. Lütfen hazırlık yapınız";

            //Test amaçlı 10 saniye seçildi, normalde alt satırdaki 15 dakika aktif olacak
            var periodTimeSpan = TimeSpan.FromSeconds(10);
            //var periodTimeSpan = TimeSpan.FromMinutes(15);

            var timer = new System.Threading.Timer((e) =>
            {
                var context = new OneSignalDbContext();

                List<string> playerIds = new List<string>() { "089ca095-f63c-4650-8148-6bcb72ffb3d4" };

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
