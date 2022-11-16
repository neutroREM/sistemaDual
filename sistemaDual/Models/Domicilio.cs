using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Domicilio
    {
        public int DomicilioID { get; set; }

        public string? Direccion { get; set; }

        public string? Colonia { get; set; }

        public string? Municipio { get; set; }

        public string? CodigoPostal { get; set; }

        public string? Otros { get; set; }

        public ICollection<AlumnoDual>? AlumnosDual { get; set; }
        public ICollection<Empresa>? Empresas { get; set; }
        public ICollection<Universidad>? Universidades { get; set; }
    }
}
