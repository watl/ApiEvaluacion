using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartamentosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "GetDireccionesList")]
        public async Task<IActionResult> GetAsync()
        {
            var pnd = await _context.DepartamentoProyectos.ToListAsync();
            return Ok(pnd);
        }


    }
}
