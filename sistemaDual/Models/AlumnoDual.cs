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
        public int ID { get; set; }

        [Required]
        [StringLength(18)]
        [Display(Name = "CURP")]
        public string Curp { get; set; }

        [Required]
        [StringLength(10)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(20)]
        [Column("NombreCompleto")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        [Column("ApellidoPaterno")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoP { get; set; }

        [Required]
        [StringLength(20)]
        [Column("ApellidoMaterno")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoM { get; set; }

        [Required]
        [Phone]
        [StringLength(12)]
        public int Telefono { get; set; }

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

        [Display(Name = "Nombre Completo")]
        public string NombreComp
        {
            get
            {
                return Nombre + " " + ApellidoP + " " + ApellidoM;
            }
        }

        public int DomicilioID { get; set; }
        public int ProgramaEducativoID { get; set; }
        public int BecaDualID { get; set; }

        public BecaDual BecaDual { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
        public Domicilio Domicilio { get; set; }

        public ICollection<AlumnoMentor> AlumnoMentores { get; set; }
        public ICollection<CatalagoProyecto> CatalagoProyectos { get; set; }


    }
}
