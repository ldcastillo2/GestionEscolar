namespace GestionEscolar.Models
{
    public class Aula
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int Capacidad { get; set; }
        public string Descripcion { get; set; } = "";
        public string Tipo { get; set; } = "";
    }
}
