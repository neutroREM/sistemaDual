using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class Empresa
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmpresaID { get; set; }

        public string? RazonS { get; set; }

        public string? NombreC { get; set; }

        public string? SectorS { get; set; }

        public string? RepresentanteL { get; set; }

        public string? CorreoR { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaCambio { get; set; }
        
        public int DomicilioID { get; set; }

        public Domicilio? Domicilio { get; set; }

        public ICollection<MentorEmpresarial> MentoresEmpresariales { get; set; }
        public ICollection<CatalagoProyecto> CatalagoProyectos { get; set; }

    }
}
