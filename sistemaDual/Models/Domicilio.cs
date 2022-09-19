using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Domicilio
    {
        [Key]
        public int id { get; set; }
        public string direccion { get; set; }
        public string colonia { get; set; }
        public string localidad { get; set; }
        public string municipio { get; set; }
        public string CP { get; set; }
        public string otros { get; set; }

        public List<Alumno> Alumnos { get; set; }
        public List<Universidad> Universidades { get; set; }
        public List<Empresa> Empresas { get; set; }
    }
}
