using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class Empresa
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "RFC")]
        [StringLength(13)]
        public string Rfc { get; set; }

        [Required]
        [Column("RazonSocial")]
        [Display(Name = "Razon Social")]
        [StringLength(30)]
        public string Razon { get; set; }

        [Required]
        [Column("NombreComercial")]
        [Display(Name = "Nombre Comercial")]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Sector Social")]
        [StringLength(30)]
        public string Sector { get; set; }

        [Required]
        [Column("RepresentanteLegal")]
        [Display(Name = "Representante Legal")]
        [StringLength(30)]
        public string Representante { get; set; }

        [Required]
        [Column("CorreoRepresentante")]
        [Display(Name = "Correo Representante")]
        [EmailAddress]
        public string Correo { get; set; }
        public int DomicilioID { get; set; }

        public Domicilio Domicilio { get; set; }

        public ICollection<MentorEmpresarial> MentoresEmpresariales { get; set; }
        
    }
}
