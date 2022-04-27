using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
    
        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetEmpleadosList")]
        public async Task<IActionResult> GetAsync()
        {
            var emp = await _context.Empleados.ToListAsync();
            return Ok(emp);
        }

    }
}
