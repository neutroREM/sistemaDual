using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    

    public class ProgramaEducativo
    {
        public int ProgramaEducativoID { get; set; }

        [StringLength(30)]
        public string? NombreP { get; set; }

        [StringLength(15)]
        public string? Version { get; set; }

        public int? UniversidadID { get; set; }

        public Universidad? Universidad { get; set; }

        public ICollection<AlumnoDual>? AlumnosDuales { get; set; }
        public ICollection<MentorAcademico>? MentoresAcademicos { get; set; }
        public ICollection<AsesorInstitucional>? AsesoresInstitucionales { get; set; }


    }
}
