using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using openComputingLab.Data;
using openComputingLab.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//veze prema bazi podataka...
builder.Services.AddDbContext <AppDbContext> (o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    Console.WriteLine("Development");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
