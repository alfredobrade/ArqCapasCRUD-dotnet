using System;
using System.Collections.Generic;

namespace ProyectoCRUD.Models;

public partial class Contacto : BaseEntity
{

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
