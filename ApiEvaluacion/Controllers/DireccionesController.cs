using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DireccionesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "GetDireccionesList")]
        public async Task<IActionResult> GetAsync()
        {
            var pnd = await _context.Direcciones.ToListAsync();
            return Ok(pnd);
        }


    }
}
