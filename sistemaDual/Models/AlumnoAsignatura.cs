namespace sistemaDual.Models
{
    public class AlumnoAsignatura
    {
        public string AlumnoDualID { get; set; }
        public string AsignaturaID { get; set; }
        public Double? AsignaturaAmount { get; set; }

        public AlumnoDual AlumnoDual { get; set; }
        public Asignatura Asignatura { get; set; }
    }
}
