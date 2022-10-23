using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    
    public enum Tipo
    {
        NuevoIngreso,
        Reingreso
    }
    public enum Cuatrimestre
    {
        Primero,
        Segundo,
        Tercero,
        Cuarto,
        Quinto,
        Sexto,
        Septimo,
        Octavo,
        Noveno,
        Decimo
    }
    public class AlumnoDual
    {

        [Required]
        [StringLength(18)]
        [Display(Name = "CURP")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AlumnoDualID { get; set; }

        [Required]
        [StringLength(10)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoP { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Apellido Materno")]
        public string ApellidoM { get; set; }

        [Required]
        [StringLength(12)]
        public int Telefono { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

        [Required]
        public Cuatrimestre Cuatrimestre { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        [Required]
        public Double Promedio { get; set; }

        //Dates
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaIngreso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaReingreso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEgreso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaContratado { get; set; }

        public int? EsActivo { get; set; }

        public int? ProgramaEducativoID { get; set; }
        public int? BecaDualID { get; set; }
        public int? DomicilioID { get; set; }
        public int? EstatusID { get; set; }
        public int? RolID { get; set; }

        public Rol Rol { get; set; }
        public Estatus Estatus { get; set; }
        public Domicilio Domicilio { get; set; }
        public BecaDual? BecaDual { get; set; }
        public ProgramaEducativo? ProgramaEducativo { get; set; }

        
        public ICollection<AlumnoMentor> AlumnoMentores { get; set; }
        public ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
        public ICollection<CatalagoProyecto> CatalagoProyectos { get; set; }


    }
}
