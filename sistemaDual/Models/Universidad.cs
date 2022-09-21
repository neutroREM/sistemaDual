using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class Universidad
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CCT { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        public int DomicilioID { get; set; }

        public Domicilio Domicilio { get; set; }

        public ICollection<ProgramaEducativo> ProgramaEducativos { get; set; }
        public ICollection<ResponsableInstitucional> ResponsablesInstitucionales { get; set; }
    }
}
