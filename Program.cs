using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReactProject.Models;
using ReactProject.Repository;

var builder = WebApplication.CreateBuilder(args);

// Accessing Configuration object from the builder
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string DBType = configuration["ConnectionString:DBType"];
if (string.IsNullOrEmpty(DBType) || DBType == "PGSQL")
{
    builder.Services.AddDbContext<StudentDbContext>(opts => opts.UseNpgsql(configuration["ConnectionString:StudentDbContext"]));
}
else
{
    builder.Services.AddDbContext<StudentDbContext>(opts => opts.UseSqlServer(configuration["ConnectionString:StudentDbContext"]));
}
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddCors(options =>
   {
       options.AddPolicy("AllowOrigin",
           builder =>
           {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
           });
   });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowOrigin");

// Specify HTTPS port for redirection
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();