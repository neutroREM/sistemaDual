using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class Universidad
    {

        [Required]
        [StringLength(10)]
        [Display(Name = "CCT")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UniversidadID { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nombre Universidad")]
        public string NombreU { get; set; }

        public int? DomicilioID { get; set; }
        public Domicilio? Domicilio { get; set; }

        public ICollection<ProgramaEducativo> ProgramaEducativos { get; set; }
        public ICollection<ResponsableInstitucional> ResponsablesInstitucionales { get; set; }
        
    }
}
