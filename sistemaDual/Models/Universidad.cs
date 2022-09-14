namespace sistemaDual.Models
{
    public class Universidad
    {
        public string CCT { get; set; }
        public string nombre { get; set; }
        public string id_domicilio { get; set; }

        public int id_domicilio2 { get; set; }
        public Domicilio Domicilio { get; set; }

        public List<Alumno> Alumnos { get; set; }
        public List<ProgramaEducativo> ProgramasEducativos { get; set; }
        public List<MentorAcademico> MentoresAcademicos { get; set; }
        public List<AsesorInstitucional> AsesoresInstitucionales { get; set; }
        public List<ResponsableInstitucional> ResponsablesInstitucionales { get; set; }
    }
}
