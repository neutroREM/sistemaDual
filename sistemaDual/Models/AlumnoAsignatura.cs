namespace sistemaDual.Models
{
    public class AlumnoAsignatura
    {
        public int AlumnoDualID { get; set; }
        public int AsignaturaID { get; set; }
        public Double? AsignaturaCalificacion { get; set; }

        public AlumnoDual? AlumnoDual { get; set; }
        public Asignatura? Asignatura { get; set; }
    }
}
