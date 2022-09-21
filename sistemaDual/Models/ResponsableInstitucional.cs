using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class ResponsableInstitucional
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
        public int UniversidadID { get; set; }

        public Universidad Universidad { get; set; }
    }
}
