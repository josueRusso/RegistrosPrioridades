using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Registro_de_Prioridades.Entidades
{
    public class Prioridad
    {
        [Key] public int PrioridadId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime  DiasCompromiso  { get; set; } = DateTime.Now;
    }
}
