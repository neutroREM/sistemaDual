using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class MentorAcademico
    {
        [Required]
        [StringLength(18)]
        [Display(Name = "CURP")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MentorAcademicoID { get; set; }

        [Required]
        [StringLength(20)]

        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoP { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido Materno")]
        public string ApellidoM { get; set; }

        public int? ProgramaEducativoID { get; set; }
        public ProgramaEducativo? ProgramaEducativo { get; set; }
    }
}
