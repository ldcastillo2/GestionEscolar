
using System.ComponentModel.DataAnnotations;

namespace GestionEscolar.Models
{
    public class Maestro
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
