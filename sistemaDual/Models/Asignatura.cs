namespace sistemaDual.Models
{

    public class Asignatura
    {
        public int AsignaturaID { get; set; }

        public string? NombreAsignatura { get; set; }

        public string? Periodo { get; set; }

        public string? Competencia { get; set; }

        public string? Actividad { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaCambios { get; set; }

        public ICollection<AlumnoAsignatura>? AlumnoAsignaturas { get; set; }


    }
}
