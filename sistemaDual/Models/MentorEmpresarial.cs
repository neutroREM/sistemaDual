using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class MentorEmpresarial
    {
        public int ID { get; set; }

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

        [Required]
        [Column("CorreoMentor")]
        [Display(Name = "Correo Mentor")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [Phone]
        [StringLength(12)]
        public int Telefono { get; set; }

        [StringLength(30)]
        public string Cargo { get; set; }
        public int EmpresaID { get; set; }
        public int ProgramaEducativoID { get; set; }

        public Empresa Empresa { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }    

        public ICollection<AlumnoMentor> AlumnoMentores { get; set; }

    }
}
