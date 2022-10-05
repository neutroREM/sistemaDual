using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    

    public class ProgramaEducativo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre del programa")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Version del programa")]
        [StringLength(15)]
        public string Version { get; set; }

        public string? UniversidadID { get; set; }
        public Universidad? Universidad { get; set; }

        public ICollection<AlumnoDual> AlumnosDuales { get; set; }
        public ICollection<MentorAcademico> MentoresAcademicos { get; set; }
        public ICollection<AsesorInstitucional> AsesoresInstitucionales { get; set; }


    }
}
