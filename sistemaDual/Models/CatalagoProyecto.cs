using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
   
    public class CatalagoProyecto
    {
        public int CatalagoProyectoID { get; set; }

        public string? NumeroProyecto { get; set; }

        [StringLength(50)]
        public string? NombreProyecto { get; set; }

        [StringLength(20)]
        public string? Etapa { get; set; }

        [StringLength(20)]
        public string? AreaConocimiento { get; set; }

        public int? NumHoras { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaTermino { get; set; }

        public DateTime? FechaCambioEstatus { get; set; }

        public int? AlumnoDualID { get; set; }
        public int? EmpresaID { get; set; }
        public int? ProgramaEducativoID { get; set; }
        
        public ProgramaEducativo? ProgramaEducativo { get; set; }
        public AlumnoDual? AlumnoDual { get; set; }
        public Empresa? Empresa { get; set; }

    }
}
