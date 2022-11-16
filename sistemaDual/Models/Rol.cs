namespace sistemaDual.Models
{
    public class Rol
    {
        public int RolID { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public ICollection<AlumnoDual>? AlumnosDuales { get; set; }

    }
}
