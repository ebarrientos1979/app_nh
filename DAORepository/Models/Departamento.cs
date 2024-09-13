using System;
using System.Collections.Generic;

namespace DAORepository.Models;

public partial class Departamento
{
    public int Iddepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public string Idubicacion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Ubicacion IdubicacionNavigation { get; set; } = null!;
}
