using System.Security.Policy;

namespace sistemaDual.Models.ViewModels
{
    public class EmpresaViewModel
    {
        public int EmpresaID { get; set; }

        public string? RFC { get; set; }
        
        public string? RazonS { get; set; }

        public string? NombreC { get; set; }

        public string? SectorS { get; set; }

        public string? RepresentanteL { get; set; }

        public string? CorreoR { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaCambio { get; set; }

    }
}
