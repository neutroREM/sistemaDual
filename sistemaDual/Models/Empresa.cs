using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class Empresa
    {
      
        [Required]
        [StringLength(13)]
        [Display(Name = "RFC")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmpresaID { get; set; }

        [Required]
        [Display(Name = "Razon Social")]
        [StringLength(30)]
        public string RazonS { get; set; }

        [Required]
        [Display(Name = "Nombre Comercial")]
        [StringLength(30)]
        public string NombreC { get; set; }

        [Required]
        [Display(Name = "Sector Social")]
        [StringLength(30)]
        public string SectorS { get; set; }

        [Required]
        [Display(Name = "Representante Legal")]
        [StringLength(30)]
        public string RepresentanteL { get; set; }

        [Required]
        [Display(Name = "Correo Representante")]
        [EmailAddress]
        public string CorreoR { get; set; }
      
        public int DomicilioID { get; set; }
        public Domicilio Domicilio { get; set; }
        
        public ICollection<MentorEmpresarial> MentoresEmpresariales { get; set; }
        public ICollection<CatalagoProyecto> CatalagoProyectos { get; set; }

    }
}
