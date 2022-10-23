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

        public string Correo { get; set; }

        public string Cuatrimestre { get; set; }

        public string Tipo { get; set; }

        public Double Promedio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int? EsActivo { get; set; }

        public int ProgramaEducativoID { get; set; }

        public int RolID { get; set; }

        public int DomicilioID { get; set; }

        public int EstatusID { get; set; }

        public int BecaDualID { get; set; }

        

        
        
    }
}
