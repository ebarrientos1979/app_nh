using System;
using System.Collections.Generic;

namespace DAORepository.Models;

public partial class Ubicacion
{
    public string Idubicacion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

    public bool? Estado_reg { get; set; }
}
