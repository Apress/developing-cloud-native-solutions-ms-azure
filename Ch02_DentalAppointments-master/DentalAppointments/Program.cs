using DentalAppointments.Business;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAzureClients(
    client => client.AddServiceBusClient(builder.Configuration["ServiceBusConn"])
    );
builder.Services.AddSingleton<INotificationBusiness, NotificationBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
