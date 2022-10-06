using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models.ViewModels
{
    public class AlumnoDualViewModel
    {
        public string AlumnoDualID { get; set; }

        public string Matricula { get; set; }

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public int Telefono { get; set; }

        public Cuatrimestre Cuatrimestre { get; set; }

        public Tipo Tipo { get; set; }

        public Double Promedio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public DateTime? FechaReingreso { get; set; }

        public DateTime? FechaEgreso { get; set; }

        public DateTime? FechaContratado { get; set; }

        public int ProgramaEducativoID { get; set; }
        public int BecaDualID { get; set; }
        public int DomicilioID { get; set; }
    }
}
