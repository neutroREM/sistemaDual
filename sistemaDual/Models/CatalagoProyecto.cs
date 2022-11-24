using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
   
    public class CatalagoProyecto
    {
        public int CatalagoProyectoID { get; set; }

        public string? NumeroProyecto { get; set; }

        public string? NombreProyecto { get; set; }

        public string? Etapa { get; set; }

        public string? AreaConocimiento { get; set; }

        public int? NumHoras { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaTermino { get; set; }

        public DateTime? FechaCambioEstatus { get; set; }

        public int? AlumnoDualID { get; set; }
        public int? EmpresaID { get; set; }
        public int? ProgramaEducativoID { get; set; }
        public int? AsesorInstitucionalID { get; set; }
        public int? ResponsableInstitucionalID { get; set; }
        
        public ResponsableInstitucional? ResponsableInstitucional { get; set; }
        public AsesorInstitucional? AsesorInstitucional { get; set; }
        public ProgramaEducativo? ProgramaEducativo { get; set; }
        public AlumnoDual? AlumnoDual { get; set; }
        public Empresa? Empresa { get; set; }

    }
}
