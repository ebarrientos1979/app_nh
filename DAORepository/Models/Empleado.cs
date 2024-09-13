using System;
using System.Collections.Generic;

namespace DAORepository.Models;

public partial class Empleado
{
    public string Idempleado { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateTime Fecingreso { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string Idcargo { get; set; } = null!;

    public int Iddepartamento { get; set; }

    public decimal Sueldo { get; set; }

    public decimal? Comision { get; set; }

    public string? Jefe { get; set; }

    public virtual Cargo IdcargoNavigation { get; set; } = null!;

    public virtual Departamento IddepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> InverseJefeNavigation { get; set; } = new List<Empleado>();

    public virtual Empleado? JefeNavigation { get; set; }

    public bool? Estado_reg { get; set; }
}
