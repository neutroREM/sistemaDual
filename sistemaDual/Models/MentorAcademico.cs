using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class MentorAcademico
    {
        public int MentorAcademicoID { get; set; }

        [StringLength(18)]
        public string? CURP { get; set; }

        [StringLength(20)]
        public string? Nombre { get; set; }

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
