using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models.ViewModels
{
    public class CatalagoProyectoViewModel
    {
        public int CatalagoProyectoID { get; set; }

        public string? NumeroProyecto { get; set; }

        public string? NombreProyecto { get; set; }

        public string? Etapa { get; set; }

        public string? AreaConocimiento { get; set; }

        public int? NumHoras { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public string? FechaInicio { get; set; }

        public string? FechaTermino { get; set; }

        public int? AlumnoDualID { get; set; }

        public string? CURP { get; set; }

        public string? NombreA { get; set; }

        public int? EmpresaID { get; set; }

        public string? NombreC { get; set; }

        public int? ProgramaEducativoID { get; set; }

        public string? NombreP { get; set; }

        public int? AsesorInstitucionalID { get; set; }

        public string? NombreAsesor{ get; set; }

        public int? ResponsableInstitucionalID { get; set; }

        public string? NombreResponsable { get; set; }


    }
}
