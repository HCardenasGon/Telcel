using System;
using System.Collections.Generic;

namespace DL;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public int IdPuesto { get; set; }
    
    public string? DescripcionPuesto { get; set; }

    public int IdDepartamento { get; set; }

    public string? DescripcionDepartamento { get; set; }

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual Puesto IdPuestoNavigation { get; set; } = null!;
}
