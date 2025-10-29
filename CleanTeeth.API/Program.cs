using CleanTeath.Application;
using CleanTeeth.API.Jobs;
using CleanTeeth.API.Middlewares;
using CleanTeeth.Persistence;
using CleanTeeth.Security;
using CleanTeeth.Security.Models;
using CleanTeeth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddSecurityServices();

// Jobs
builder.Services.AddHostedService<AppointmentReminderJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapIdentityApi<User>();

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
