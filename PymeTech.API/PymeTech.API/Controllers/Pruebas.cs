using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PymeTech.Infrastructure.Persistence;

namespace PymeTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pruebas : ControllerBase
    {
        public readonly AppDbContext _dbContext;


        public Pruebas(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tenants = _dbContext.Tenants.ToListAsync();
            return Ok(tenants);
        }
    }
}
