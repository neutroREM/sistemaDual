using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class ResponsableInstitucional
    {

        [Required]
        [Display(Name = "CURP")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ResponsableInstitucionalID { get; set; }

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

        public string UniversidadID { get; set; }
        public Universidad Universidad { get; set; }
    }
}
