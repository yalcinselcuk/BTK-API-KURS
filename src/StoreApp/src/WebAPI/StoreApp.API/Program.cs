using Microsoft.EntityFrameworkCore;
using NLog;
using StoreApp.Infrastructure.Data;
using StoreApp.Infrastructure.Repositories;
using StoreApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookRepository, EFBookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<BookDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddSingleton<ILoggerService, LoggerService>();

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
