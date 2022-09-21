using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class AsesorInstitucional
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "CURP")]
        public string Curp { get; set; }

        [Required]
        [StringLength(20)]
        [Column("NombreCompleto")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        [Column("ApellidoPaterno")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoP { get; set; }

        [Required]
        [StringLength(20)]
        [Column("ApellidoMaterno")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoM { get; set; }
        public int ProgramaEducativoID { get; set; }

        public ProgramaEducativo ProgramaEducativo { get; set; }
    }
}
