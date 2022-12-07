using FluentValidation.AspNetCore;
using Base.Api.Application.Extensions;
using Base.Common.Models.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add Custom Serilog
builder.Host.UseCustomSerilog();


// Add services to the container
builder.Services
    .AddControllers();

// Enable FluentValidation
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Calling Custom AddApplicationRegistration For FluentValidation and MetiatR services.
builder.Services.AddApplicationRegistration();

// Enable HealthCheck
builder.Services.AddHealthChecks();

builder.Services.AddHttpClient(HttpConstants.TextApiClientName);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adding HealthCheck endpoint for monitoring
app.UseCustomHealthCheck();

// Adding Custom Middlewares
app.UseCustomMiddleWares();

// Adding Response Caching 
app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
