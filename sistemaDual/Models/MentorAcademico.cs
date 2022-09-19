using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class MentorAcademico
    {
        [Key]
        public string CURP{ get; set; }
        public string nombre { get; set; }
        public string apellido_p { get; set; }
        public string apellido_m { get; set; }

    
        public string CLAVE_PROGRAMA4 { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
    }
}
