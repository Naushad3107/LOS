using LOS.Data;
using LOS.Mapper;
using LOS.Repository;
using LOS.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRole, RoleService>();
builder.Services.AddScoped<IUserRole, UserRoleService>();
builder.Services.AddScoped<ICountries, CountriesService>();
builder.Services.AddScoped<IState, StateService>();
builder.Services.AddScoped<ICities, CitiesService>();
builder.Services.AddScoped<IPincode, PincodeService>();
builder.Services.AddScoped<IToken, TokenService>();
builder.Services.AddScoped<IAuth, AuthService>();

builder.Services.AddAutoMapper(typeof(MappingData));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        var cfg = builder.Configuration.GetSection("JwtSettings");
        var key = Encoding.ASCII.GetBytes(cfg["SecretKey"]!);

        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = cfg["Issuer"],
            ValidateAudience = true,
            ValidAudience = cfg["Audience"],



        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
