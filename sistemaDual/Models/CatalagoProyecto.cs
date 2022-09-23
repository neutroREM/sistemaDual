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
        public string Nombre { get; set; }
        public string Etapa { get; set; }

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

        [DisplayFormat(NullDisplayText = "No estatus")]
        public Estatus? Estatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCambioEstatus { get; set; }

        public int AlumnoDualID { get; set; }
        public int EmpresaID { get; set; }
        public int ProgramaEducativoID { get; set; }

        public ProgramaEducativo ProgramaEducativo { get; set; }
        public AlumnoDual AlumnoDual { get; set; }
        public Empresa Empresa { get; set; }

    }
}
