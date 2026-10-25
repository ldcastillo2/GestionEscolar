using System.ComponentModel.DataAnnotations;

namespace GestionEscolar.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}