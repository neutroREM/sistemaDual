using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public enum Estatus
    {
        Activo,
        Egresado,
        BajaDefinitivaMED,
        BajaTemporalMED,
        BajaDefinitivaIES,
        BajaTemporalIES

    }
    public class CatalagoProyecto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre del proyecto")]
        public string Nombre { get; set; }

        [StringLength(20)]
        [Display(Name = "Etapa proyecto")]
        public string Etapa { get; set; }

        [StringLength(20)]
        [Display(Name = "Area Conocimiento")]
        public string AreaConocimiento { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public int NumHoras { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaTermino { get; set; }

        public Estatus? Estatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCambioEstatus { get; set; }

        public string? AlumnoDualID { get; set; }
        public string? EmpresaID { get; set; }
        
        public AlumnoDual? AlumnoDual { get; set; }
        public Empresa? Empresa { get; set; }

    }
}
