using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class AsesorInstitucional
    {
        public int AsesorInstitucionalID { get; set; }

        [StringLength(18)]
        public string? CURP { get; set; }

        [StringLength(20)]
        public string? NombreA { get; set; }

        [StringLength(20)]
        public string? ApellidoP { get; set; }

        [StringLength(20)]
        public string? ApellidoM { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public int? ProgramaEducativoID { get; set; }
        public ProgramaEducativo? ProgramaEducativo { get; set; }
    }
}
