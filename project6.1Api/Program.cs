using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using project6._1Api.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
});
builder.Services.AddDbContext<database>(options =>
    options.UseSqlite("Data Source=C:\\Users\\Gebruiker\\source\\repos\\project6.1Api\\bin\\Files\\database.db"));
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


//init db
//sqlitedb.InitializeDatabase();

//db faker
//sqlitedb.TransactionFaker();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


