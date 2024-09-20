namespace PrjRRHH.Dto
{
    public class EmpleadoDto
    {
        public string Idempleado { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Nombre { get; set; } = null!;        
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string Idcargo { get; set; } = null!;
        public int Iddepartamento { get; set; }        
        public string? Jefe { get; set; }
    }
}
