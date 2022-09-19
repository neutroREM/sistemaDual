using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class BecaDual
    {
        [Key]
        public string CLAVE { get; set; }
        public string fuente { get; set; }
        public string tipo_beca { get; set; }
        public string periocidad { get; set; }
        public string duracion { get; set; }

        public List<Alumno> Alumnos { get; set; }
    }
}
