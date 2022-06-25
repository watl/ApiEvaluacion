using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ApiEvaluacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PreguntaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetPreguntaList")]
        public async  Task<IActionResult> GetAsync()
        {
           var preguta= await _context.Pregunta.ToListAsync();
            return Ok(preguta);
        }
    }
}
