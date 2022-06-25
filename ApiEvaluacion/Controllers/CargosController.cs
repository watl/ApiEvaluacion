using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CargosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "GetCargosList")]
        public async Task<IActionResult> GetAsync()
        {
            var pnd = await _context.Cargos.ToListAsync();
            return Ok(pnd);
        }


    }
}
