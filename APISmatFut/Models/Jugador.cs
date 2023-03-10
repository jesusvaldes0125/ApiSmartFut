using System;
using System.Collections.Generic;

namespace APISmatFut.Models;

public partial class Jugador
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string NumeroCamiseta { get; set; } = null!;

    public DateTime Edad { get; set; }

    public int EquipoId { get; set; }

    public virtual Equipo oEquipo { get; set; } = null!;
}
