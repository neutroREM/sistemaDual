namespace sistemaDual.Models
{
    public class ProgramaEducativo
    {
        public string CLAVE { get; set; }
        public string nombre { get; set; }
        public string version { get; set; }

        public string CCT3 { get; set; }
        public Universidad Universidad { get; set; }

        public List<Alumno> AlumnoList { get; set; }
        public List<MentorEmpresarial> MentorEmpresarialList { get; set; }
        public List<MentorAcademico> MentorAcademicoList { get; set; }
        public List<CatalagoProyecto> CatalagoProyectoList { get; set; }
        public List<AsesorInstitucional> AsesorInstitucionalList { get; set; }
        public List<Asignatura> AsignaturaList { get; set; }
        

    }
}
