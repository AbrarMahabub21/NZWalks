using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Project_NZWalks.API.Data;
using Project_NZWalks.API.Mappings;
using Project_NZWalks.API.Repository;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

// Adding Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Added User Authentication before Authorization

app.UseAuthorization();

app.MapControllers();

app.Run();
