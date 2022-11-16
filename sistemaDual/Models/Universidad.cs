using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class Universidad
    {

        public int UniversidadID { get; set; }

        public string? CCT { get; set; }

        public string? NombreU { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaCambio { get; set; }

        public int? DomicilioID { get; set; }

        public Domicilio? Domicilio { get; set; }

        public ICollection<ProgramaEducativo>? ProgramaEducativos { get; set; }
        public ICollection<ResponsableInstitucional>? ResponsablesInstitucionales { get; set; }
        
    }
}
