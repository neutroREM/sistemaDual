using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class MentorEmpresarial
    {
        [Required]
        [StringLength(18)]
        [Display(Name = "CURP")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MentorEmpresarialID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido Paterno")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoP { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido Materno")]
        public string ApellidoM { get; set; }

        [Required]
        [Display(Name = "Correo Mentor")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(12)]
        public int Telefono { get; set; }

        [Required]
        [StringLength(30)]
        public string Cargo { get; set; }

        public string EmpresaID { get; set; }
        public Empresa Empresa { get; set; }

        public ICollection<AlumnoMentor> AlumnoMentores { get; set; }

    }
}
