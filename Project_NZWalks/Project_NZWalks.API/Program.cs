using Microsoft.EntityFrameworkCore;
using Project_NZWalks.API.Data;
using Project_NZWalks.API.Mappings;
using Project_NZWalks.API.Repository;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connecting to DB
builder.Services.AddDbContext<NZWalksDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

//Injecting RegionalRepository
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

//Injecting AutoMapper
builder.Services.AddAutoMapper(cfg=> cfg.AddProfile<AutoMapperProfiles>());

//Injecting WalkRepository
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();
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
