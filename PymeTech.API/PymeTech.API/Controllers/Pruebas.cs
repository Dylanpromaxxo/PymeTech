using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var tenants = _dbContext.Permisos.ToList();
            return Ok(tenants);
        }
    }
}
