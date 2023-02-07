using CustomerCare.Api.Middleware;
using CustomerCare.Application.Interfaces;
using CustomerCare.Application.Services;
using CustomerCare.Application.Validations;
using CustomerCare.Domain.Entities;
using CustomerCare.Infrastructure.Context;
using CustomerCare.Infrastructure.Repositories;
using CustomerCare.Infrastructure.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("UserDB")));

builder.Services.AddScoped<IApplicationContext, ApplicationContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await AssureDatabase(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

async Task AssureDatabase(IServiceProvider services)
{
    var service = services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();

    await service.Database.EnsureCreatedAsync();
    await service.Database.MigrateAsync();
}