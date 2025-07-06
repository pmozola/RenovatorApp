using Microsoft.AspNetCore.HttpOverrides;
using RenovatorApp.Application.IoC;
using RenovatorApp.Auth;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRenovatorAuthorization(builder.Configuration);
builder.Services.AddRenovatorAppServices();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseForwardedHeaders();

app.UseHttpsRedirection();

app.UseRenovatorAuth();

app.MapControllers();

app.Run();