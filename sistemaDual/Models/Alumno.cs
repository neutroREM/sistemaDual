namespace sistemaDual.Models
{
    public class Alumno
    {
        public string CURP { get; set; }
        public int matricula { get; set; }
        public string nombre { get; set; }
        public string apellido_p { get; set; }
        public string apellido_m { get; set; }
        public string fecha_nac { get; set; }
        public string genero { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public string cuatrimentre { get; set; }
        public string promedio { get; set; }
        public string tipo_alumno { get; set; }

        public string CCT1 { get; set; }
        public int id_domicilio1 { get; set; }
        public string CLAVE_PROGRAMA2 { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
        public Domicilio Domicilio { get; set; }
        public Universidad Universidad { get; set; }

        public List<CatalagoProyecto> CatalagoProyectos { get; set; }
        public List<Alumno_MentorEmpresarial> Alumno_Mentores { get; set; }
        
    }
}
