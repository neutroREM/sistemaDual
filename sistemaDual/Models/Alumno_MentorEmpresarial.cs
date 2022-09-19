using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Alumno_MentorEmpresarial
    {
        [Key]
        public int id { get; set; }
        public string CURP_ALUMNO1 { get; set; }
        public string CURP_MENTOR_E1 { get; set; }

        public Alumno Alumno { get; set; }
        public MentorEmpresarial MentorEmpresarial { get; set; }
    }
}
