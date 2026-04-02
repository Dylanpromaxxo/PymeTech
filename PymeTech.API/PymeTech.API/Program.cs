using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Tenants.Queries.GetAllTenants;
using PymeTech.Infrastructure.Persistence;
using PymeTech.Infrastructure.Persistence.Repositories;
using PymeTech.Application.Common.Behaviours;
using PymeTech.API.Middleware;


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



builder.Services.AddDbContext<AppDbContext>(opcion => opcion.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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

app.UseAuthorization();

//Aplicacion del Middleware 
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
