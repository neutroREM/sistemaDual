using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Domicilio
    {
        public int DomicilioID { get; set; }
        [StringLength(60)]
        public string Direccion { get; set; }
        [StringLength(30)]
        public string Colonia { get; set; }
        [StringLength(30)]
        public string Municipio { get; set; }
        [StringLength(5)]
        public string CodigoPostal { get; set; }
        [StringLength(30)]
        public string? Otros { get; set; }

        public string? AlumnoDualID { get; set; }
        public string? UniversidadID { get; set; }
        public string? EmpresaID { get; set; }

        public AlumnoDual AlumnoDual { get; set; }
        public Universidad Universidad { get; set; }
        public Empresa Empresa { get; set; }
    }
}
