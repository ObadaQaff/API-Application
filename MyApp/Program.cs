using AutoMapper;
using System.Reflection;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.services.Users;
using MyApp.Data;
using MyApp.Data.Repository;
using MyApp.Data.Repository.IRepository;
using MyApp.Domain.Cars;
using MyApp.Domain.Users;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
  builder.Services.AddFluentValidation(options =>
  {
      // Validate child properties and root collection elements
      options.ImplicitlyValidateChildProperties = true;
      options.ImplicitlyValidateRootCollectionElements = true;

      // Automatic registration of validators in assembly
      options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
  });

builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulteConnection")));
//  b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserServices, UserServices>(); builder.Services.AddScoped<IUserServices, UserServices>();


builder.Services.AddScoped<IRepositry<User>, Repositry<User>>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
