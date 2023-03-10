using System;
using System.Collections.Generic;

namespace APISmatFut.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Presidente { get; set; }

    public string? ImagenEquipo { get; set; }

    public virtual ICollection<Jugador> Jugadors { get; } = new List<Jugador>();

    public virtual ICollection<Presidente> Presidentes { get; } = new List<Presidente>();
}
