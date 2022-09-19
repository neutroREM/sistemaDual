using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class MentorEmpresarial
    {
        [Key]
        public string CURP { get; set; }
        public string nombre { get; set; }
        public string apellido_p { get; set; }
        public string apellido_m { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public int telefono { get; set; }
        public string cargo { get; set; }
        
        public string RFC_EMPRESA1 { get; set; }
        public string CLAVE_PROGRAMA5 { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
        public Empresa Empresa { get; set; }

        public List<CatalagoProyecto> CatalagoProyectoList { get; set; }
        public List<Alumno_MentorEmpresarial> Mentor_Alumnos { get; set; }
    }
}
