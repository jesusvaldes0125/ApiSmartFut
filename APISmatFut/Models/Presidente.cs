using System;
using System.Collections.Generic;

namespace APISmatFut.Models;

public partial class Presidente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int EquipoId { get; set; }

    public virtual Equipo Equipo { get; set; } = null!;
}
