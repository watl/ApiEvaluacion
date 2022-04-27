
using ApiEvaluacion.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Helpers
{
    public class ApplicationDbContext : DbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }




    }
}
