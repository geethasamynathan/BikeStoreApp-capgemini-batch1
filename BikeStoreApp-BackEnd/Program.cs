//using BikeStoreApp_BackEnd.Data;
using BikeStoreApp_BackEnd.Data;
using BikeStoreApp_BackEnd.IServices;
using BikeStoreApp_BackEnd.Profiles;
using BikeStoreApp_BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BikeStoreContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

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

//using BikeStoreApp_BackEnd.Authentication;
////using JWT_Auth_Demo.Authentication;
////using JWT_Auth_Demo.Models;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using BikeStoreApp_BackEnd.Models;
//using BikeStoreApp_BackEnd.IServices;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//{
//    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));
//    builder.Services.AddScoped<IUserRepository, UserRepository>();
//    // For Identity
//    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//          .AddEntityFrameworkStores<ApplicationDbContext>()
//          .AddDefaultTokenProviders();


//    // Adding Authentication
//    builder.Services.AddAuthentication(options =>
//    {
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    })

//    // Adding Jwt Bearer
//    .AddJwtBearer(options =>
//    {
//        options.SaveToken = true;
//        options.RequireHttpsMetadata = false;
//        options.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidAudience = builder.Configuration["JWT:Audience"],
//            ValidIssuer = builder.Configuration["JWT:Issuer"],
//            IssuerSigningKey = new SymmetricSecurityKey
//            (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//        };
//    });


//    builder.Services.AddControllers();
//    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//    builder.Services.AddEndpointsApiExplorer();
//    builder.Services.AddSwaggerGen();

//    var app = builder.Build();

//    // Configure the HTTP request pipeline.
//    if (app.Environment.IsDevelopment())
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI();
//    }

//    app.UseHttpsRedirection();
//    app.UseAuthentication();
//    app.UseAuthorization();

//    app.MapControllers();

//    app.Run();
//}