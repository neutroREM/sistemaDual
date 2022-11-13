using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class MentorEmpresarial
    {

        public int MentorEmpresarialID { get; set; }

        [StringLength(18)]
        public string? CURP { get; set; }

        [StringLength(20)]
        public string? Nombre { get; set; }

        [StringLength(20)]
        public string? ApellidoP { get; set; }

        [StringLength(20)]
        public string? ApellidoM { get; set; }

        public string? Correo { get; set; }

        public string? Clave { get; set; }

        public string? Telefono { get; set; }

        [StringLength(30)]
        public string? Cargo { get; set; }

        public string? EmpresaID { get; set; }
        public Empresa? Empresa { get; set; }

        public ICollection<AlumnoMentor> AlumnoMentores { get; set; }

    }
}
