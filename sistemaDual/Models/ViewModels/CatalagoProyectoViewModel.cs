using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models.ViewModels
{
    public class CatalagoProyectoViewModel
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Etapa { get; set; }

        public string AreaConocimiento { get; set; }

        public int NumHoras { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaTermino { get; set; }

        public Estatus Estatus { get; set; }

        public DateTime FechaCambioEstatus { get; set; }

        public string AlumnoDualID { get; set; }
        public string EmpresaID { get; set; }
    }
}
