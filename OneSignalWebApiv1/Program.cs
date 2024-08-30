using OneSignalWebApiv1.Context;
using OneSignalWebApiv1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddDbContext<OneSignalDbContext>();






builder.Services.AddScoped<CustomScheduleReminderService>(provider =>
{
    var configuration = builder.Configuration;
    var appId = configuration.GetSection("OneSignalKeys")["AppId"];
    var apiKey = configuration.GetSection("OneSignalKeys")["RestApiKey"];
    var dbContext = provider.GetRequiredService<OneSignalDbContext>();

    return new CustomScheduleReminderService(appId!, apiKey!, dbContext);
});

//builder.Services.AddHostedService<NotificationSchedulerService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient();


//OneSignald AppId ve RestApiKey in eklenmesi
var oneSignalAppId = builder.Configuration.GetSection("OneSignalKeys")["AppId"];
var oneSignalApiKey = builder.Configuration.GetSection("OneSignalKeys")["RestApiKey"];
builder.Services.AddSingleton(new OneSignalService(oneSignalAppId!, oneSignalApiKey!));
builder.Services.AddSingleton(new OneSignalServiceSpecificUsers(oneSignalAppId!, oneSignalApiKey!));


//Zamanlayýcý servisi eklenmesi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
