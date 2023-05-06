namespace ProyectoCRUD.WebApplication.Models.ViewModels
{
    public class VMContacto
    {
        public int IdContacto { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public string? FechaNacimiento { get; set; } //cambio de tipo a string

        //public DateTime? FechaRegistro { get; set; } ya no se usa este valor en la vista
    }
}
