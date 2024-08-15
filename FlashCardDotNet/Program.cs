using FlashCardDotNet.Controllers;
using FlashCardDotNet.Data;
using FlashCardDotNet.Repositories;
using FlashCardDotNet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CardRepositoryContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLserverConnection")));
builder.Services.AddTransient<CardControllerInterface, CardController>();
builder.Services.AddTransient<CardServiceInterface, CardService>();
builder.Services.AddTransient<CardRepositoryInterface, CardRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
