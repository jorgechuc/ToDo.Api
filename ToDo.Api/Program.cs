using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDo.Api.Data;
using ToDo.Api.Endpoints;
using ToDo.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Agrega el servicio para la conexión a la base de datos SQL Server
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration
        .GetConnectionString("DefaultConnection"))
);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapToDoItemsEndpoint();

app.Run();


