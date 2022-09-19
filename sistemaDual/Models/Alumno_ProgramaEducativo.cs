using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Alumno_ProgramaEducativo
    {
        [Key]
        public int id { get; set; }
        public string CURP_ALUMNO7 { get; set; }
        public string CLAVE_PROGRAMA6 { get; set; }

        public Alumno Alumno { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
    }
}
