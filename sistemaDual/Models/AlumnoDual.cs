using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{

    public class AlumnoDual
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AlumnoDualID { get; set; }

        public string? Matricula { get; set; }

        public string? Nombre { get; set; }

        public string? ApellidoP { get; set; }

        public string? ApellidoM { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Clave { get; set; }

        public string? Cuatrimestre { get; set; }

        public string? Tipo { get; set; }

        public Double? Promedio { get; set; }

        public DateTime? FechaRegistro { get; set; }

        //public DateTime? FechaEditar { get; set; }

        public bool? EsActivo { get; set; }

        public int? ProgramaEducativoID { get; set; }

        public int? BecaDualID { get; set; }

        public int? DomicilioID { get; set; }

        public int? EstatusID { get; set; }

        public int? RolID { get; set; }

        public Rol? Rol { get; set; }
        public Estatus? Estatus { get; set; }
        public Domicilio? Domicilio { get; set; }
        public BecaDual? BecaDual { get; set; }
        public ProgramaEducativo? ProgramaEducativo { get; set; }

        
        public ICollection<AlumnoMentor> AlumnoMentores { get; set; }
        public ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
        public ICollection<CatalagoProyecto> CatalagoProyectos { get; set; }


    }
}
