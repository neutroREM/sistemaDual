using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public enum TipoBeca
    {
        Economica,
        Especie
    }
    public class BecaDual
    {
        public int ID { get; set; }

        public string Fuente { get; set; }
        public TipoBeca TipoBeca { get; set; }
        public string Periocidad { get; set; }

        [DataType(DataType.Duration)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Duracion { get; set; }

        public ICollection<AlumnoDual> AlumnosDuales { get; set; }
    }
}
