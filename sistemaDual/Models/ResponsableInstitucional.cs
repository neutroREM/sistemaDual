using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class ResponsableInstitucional
    {
        public int ResponsableInstitucionalID { get; set; }

        public string? CURP { get; set; }    

        public string? NombreR { get; set; }

        public string? ApellidoP { get; set; }

        public string? ApellidoM { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Cargo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int? UniversidadID { get; set; }

        public Universidad? Universidad { get; set; }

        public ICollection<CatalagoProyecto>? CatalagoProyectos { get; set; }
    }
}
