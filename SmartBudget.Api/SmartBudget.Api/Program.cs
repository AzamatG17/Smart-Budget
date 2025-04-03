using MediatR;
using Scalar.AspNetCore;
using SmartBudget.Api.Extentions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApi(builder.Configuration);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
