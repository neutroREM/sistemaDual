using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Domicilio
    {
        public int ID { get; set; }
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

        public ICollection<Universidad> Universidades { get; set; }
        public ICollection<AlumnoDual> AlumnosDuales { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
    }
}
