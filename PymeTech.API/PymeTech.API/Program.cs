using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PymeTech.API.Middleware;
using PymeTech.Application.Common.Behaviours;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Tenants.Queries.GetAllTenants;
using PymeTech.Infrastructure.Persistence;
using PymeTech.Infrastructure.Persistence.Repositories;
using PymeTech.Infrastructure.Persistence.Services;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//inyeccion de dependencias de MediaTr y Validetion IPipelineBehavior
builder.Services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(GetAllTenantsHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(GetAllTenantsValidator).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));





builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IPermisosRepository , PermisosRepository >();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();  
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtService, JwtService>();



builder.Services.AddDbContext<AppDbContext>(opcion => opcion.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])
            )
        };
    });




builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication(); // ← primero authentication
app.UseAuthorization();  // ← después authorization

//Aplicacion del Middleware 
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
