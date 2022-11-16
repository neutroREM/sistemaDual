using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models.ViewModels
{
    public class AlumnoDualViewModel
    {
        public int AlumnoDualID { get; set; }

        public string? CURP { get; set; }

        public string? Matricula { get; set; }

        public string? Nombre { get; set; }

        public string? ApellidoP { get; set; }

        public string? ApellidoM { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public int? RolID { get; set; }

        public string? Descripcion { get; set; }

        public int? EsActivo { get; set; }

        
    }
}
