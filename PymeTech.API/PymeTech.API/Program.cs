using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Application.Feature.Tenants.Queries.GetAllTenants;
using PymeTech.Infrastructure.Persistence;
using PymeTech.Infrastructure.Persistence.Repositories;
using PymeTech.Infrastructure.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(typeof(GetAllTenantsHandler).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(GetAllTenantsValidator).Assembly);

builder.Services.AddScoped<ITenantRepository, TenantRepository>(); 



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

app.MapControllers();

app.Run();
