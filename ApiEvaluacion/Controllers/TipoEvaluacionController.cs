using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TipoEvaluacionController:  ControllerBase
    {
        private readonly ApplicationDbContext _context;     
        public TipoEvaluacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTipoEvaluacionList")]
        public async Task<IActionResult> GetAsync()
        { 
            var emp = await _context.Tpevaluacions.ToListAsync();
            return Ok(emp);
        }



    }
}
