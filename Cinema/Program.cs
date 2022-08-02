using AutoMapper;
using AutoWrapper;
using Cinema;
using Cinema.Configurations;
using Cinema.DB;
using Cinema.EntityBases;
using Cinema.Map;
using Cinema.Models;
using Cinema.Models.DTOs;
using Cinema.Repositories;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(cors => { cors.AddPolicy("AllowOrign", options => options.AllowAnyOrigin()); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
    jwt.SaveToken = true; // allow us to store jwt in header
    jwt.TokenValidationParameters = new TokenValidationParameters()// allows us to check that token was generated in our application, it is not any random token
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false, // for deployment, switch to true
        ValidateAudience = false, // for deployment, switch to true
        RequireExpirationTime = false, // for deployment, switch to true, when refresh token is added
        ValidateLifetime = true, // switch to false

    };
});
var config = new MapperConfiguration(cfr =>
{
    cfr.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();
builder.Services.AddSignalR();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaDB"));
});


var app = builder.Build();
app.UseApiResponseAndExceptionWrapper();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(cors => cors
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();