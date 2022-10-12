using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models.ViewModels
{
    public class UniversidadViewModel
    {
        public string UniversidadID { get; set; }

        public string NombreU { get; set; }

        public string Direccion { get; set; }

        public string Colonia { get; set; }

        public string Municipio { get; set; }
        
        public string CodigoPostal { get; set; }
        
        public string NombrePE { get; set; }

        public string Version { get; set; }

        public string? ResposableID { get; set; }

        public string? NombreRI { get; set; }

        public string? ApellidoP { get; set; }

        public string? ApellidoM { get; set; }

        public string? Correo { get; set; }

        public int? Telefono { get; set; }

        public string? Cargo { get; set; }

    }
}
