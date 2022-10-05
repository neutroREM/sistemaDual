namespace sistemaDual.Models
{
    public enum Periodo
    {
        I, II, III, IV, V, VI, VII, VIII, IX 
    }
    public class Asignatura
    {
        public int AsignaturaID { get; set; }

        public string Nombre { get; set; }
        public Periodo Periodo { get; set; }
        public string Competencia { get; set; }
        public string Actividad { get; set; }

        public ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; }


    }
}
