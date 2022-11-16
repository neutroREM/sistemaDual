using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{

    public class BecaDual
    {
        public int BecaDualID { get; set; }

        public string? Fuente { get; set; }
        public string? TipoBeca { get; set; }
        public string? Periocidad { get; set; }
        public string? Duracion { get; set; }

        public ICollection<AlumnoDual>? AlumnosDuales { get; set; }
    }
}
