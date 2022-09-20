using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    public class Universidad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        
        public string Nombre { get; set; }
        public int DomicilioID { get; set; }

        public Domicilio Domicilio { get; set; }

        public ICollection<ProgramaEducativo> ProgramaEducativos { get; set; }
    }
}
