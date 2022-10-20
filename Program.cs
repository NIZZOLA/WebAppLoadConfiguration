using Microsoft.Extensions.Options;
using System.Configuration;
using WebAppSample;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;
builder.Services.Configure<MyConfigurationClass>(config.GetSection("AppParameters"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/test", ( IOptions<MyConfigurationClass> options) =>
{
    var config = options.Value;
    
    return config;
})
.WithName("Test");

app.Run();

public record MyConfiguration( string Language, string DefaultExchange, string DateTimeFormat );