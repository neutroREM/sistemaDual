using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class ResponsableInstitucional
    {
        public int ResponsableInstitucionalID { get; set; }

        [StringLength(18)]
        public string? CURP { get; set; }    

        [StringLength(20)]
        public string? NombreR { get; set; }

        [StringLength(20)]
        public string? ApellidoP { get; set; }

        [StringLength(20)]
        public string? ApellidoM { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        [StringLength(30)]
        public string? Cargo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int? UniversidadID { get; set; }
        public Universidad? Universidad { get; set; }
    }
}
