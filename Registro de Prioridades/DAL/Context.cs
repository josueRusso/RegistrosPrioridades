using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Registro_de_Prioridades.Entidades;
namespace Registro_de_Prioridades.DAL
{
    public class Context : DbContext
    {
        public DbSet<Prioridad> Prioridad { get; set; }
        
        public Context(DbContextOptions<Context> options) : base(options) { }
        
    }
}
