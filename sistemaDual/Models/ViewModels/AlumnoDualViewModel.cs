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

        public string Direccion { get; set; }

        public string Colonia { get; set; }

        public string Municipio { get; set; }

        public string CodigoPostal { get; set; }

        public int Telefono { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

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
        public int RolID { get; set; }
        public int EstatusID { get; set; }

        public int? EsActivo { get; set; }
    }
}
