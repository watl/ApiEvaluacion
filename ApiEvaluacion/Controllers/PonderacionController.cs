using ApiEvaluacion.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonderacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PonderacionController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "GetPonderacionList")]
        public  IActionResult Get()
        {
            var pnd =  _context.Ponderacions.ToList();
            return Ok(pnd);
        }
        //pruebas de mas


        //Agregar nuevos metodos

    }
}
