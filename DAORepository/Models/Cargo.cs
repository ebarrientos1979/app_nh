using System;
using System.Collections.Generic;

namespace DAORepository.Models;

public partial class Cargo
{
    public string Idcargo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public decimal SueldoMin { get; set; }

    public decimal SueldoMax { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
