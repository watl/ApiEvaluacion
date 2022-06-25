using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PreguntasController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "GetPreguntasList")]
        public async Task<IActionResult> GetAsync()
        {
            var pnd = await _context.Pregunta.ToListAsync();
            return Ok(pnd);
        }



    }
}
