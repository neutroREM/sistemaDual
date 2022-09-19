using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Alumno_Asignatura
    {
        [Key]
        public int id { get; set; }
        public string CURP_ALUMNO3 { get; set; }
        public string CLAVE_ASIGNATURA1 { get; set; }

        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
    }
}
