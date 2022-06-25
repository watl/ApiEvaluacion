using Microsoft.AspNetCore.Mvc;
using ApiEvaluacion.Helpers;
using Microsoft.EntityFrameworkCore;


namespace ApiEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EvaluacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetEvaluacionList")]
        public async Task<IActionResult> GetAsync()
        {
            var evaluaciones =  await (from e in  _context.Funcionarios join a in _context.Evaluaciodetalles 
                                  on e.FunId equals a.FunId join i in _context.Detallepregunta on a.KeyEvdt 
                                  equals i.Fkdtevalua join u in _context.Pregunta on i.FkPreguntaId equals u.Id 
                                 join c in _context.Cargos on e.CarId equals c.CarId join d in _context.Direcciones
                                 on e.DirId equals d.DirId join p in _context.Ponderacions on u.Id equals p.Id
                                      
                                      select new
                                      {
                                          nombre = e.FunNombre + ' ' + e.FunApellidos,
                                          cargo = c.CarNombre,
                                          direcion = d.DirNombre,
                                          pregunta= u.Descripcion,
                                          ponderacion= p.Descripcion

                                      }).ToListAsync() ;
            return Ok(evaluaciones);
        }
    }
}
