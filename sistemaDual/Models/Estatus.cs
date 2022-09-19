using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Estatus
    {
        [Key]
        public string CLAVE { get; set; }
        public string activo { get; set; }
        public string egresado { get; set; }
        public string baja_definitiva_med { get; set; }
        public string baja_temporal_med { get; set; }
        public string baja_definitiva_ies { get; set; }
        public string baja_temporal_ies { get; set; }
        public string cambio_empresa { get; set; }

        public List<Alumno> Alumnos { get; set; }
    }
}
