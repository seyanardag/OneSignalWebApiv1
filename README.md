# OneSignalWebApiv1.1

NOTLAR;  

-OneSignalService: Genel bildirim gönderilmesi ve segment bazlı bildirim gönderilmesi için kullanılacaktır.

-OneSignalServiceSpecificUsers:Hedef olarak belirlenen kişilere (örneğin ders programında dersi yaklaşan kişiye gibi) bildirim gönderilmesi için kullanılacaktır.

-Daha sonra bu iki servis (OneSignalService ve OneSignalServiceSpecificUsers) overload metodlar olarak birleştirilecektir.


Diğer Notlar;

-Şu anda sadece NotificationController üzerinden bildirim gönderme işlemleri yapılmaktadır. Diğer yoruma alınan AddUser, AddUser2 gibi controller lar henüz tamamlanmamış olup deneme aşamasındadır.

-Uygulamada bu aşamada bazı değişkenlere manuel olarak değer verilmiştir, örneğin belirli kullanıcılara bildirim gönderilmesi esnasında SendNotificationToCustomScheduled metodu altında playerIds değişkenine daha önce sisteme kaydolan hesabın ID sinin verilmesi gibi. 
