using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Alumno
    {
        [Key]
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
        public DateTime fecha_registro { get; set; } = DateTime.Now;
        public DateTime fecha_ingreso_dual { get; set; } 
        public DateTime fecha_ingreso_reingreso { get; set; }
        public DateTime fecha_egreso { get; set; }
        public DateTime fecha_contratado { get; set; }


        public int id_domicilio1 { get; set; }
        public string CLAVE_BECA1 { get; set; }
        public string CLAVE_ESTATUS1 { get; set; }
        public Estatus Estatus { get; set; }
        public BecaDual BecaDual { get; set; }
        public Domicilio Domicilio { get; set; }

        
        public List<Alumno_ProgramaEducativo> Alumno_ProgramaEducativos { get; set; }
        public List<CatalagoProyecto> CatalagoProyectos { get; set; }
        public List<Alumno_MentorEmpresarial> Alumno_Mentores { get; set; }
        public List<Alumno_Asignatura> Alumno_Asignaturas { get; set; }
        
    }
}
