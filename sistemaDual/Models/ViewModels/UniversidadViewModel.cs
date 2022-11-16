using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models.ViewModels
{
    public class UniversidadViewModel
    {
        public int UniversidadID { get; set; }

        public string? CCT { get; set; }

        public string? NombreU { get; set; }

        public int? DomicilioID { get; set; }

        public string? Direccion { get; set; }

        public string? Colonia { get; set; }

        public string? Municipio { get; set; }
        
        public string? CodigoPostal { get; set; }

    }
}
