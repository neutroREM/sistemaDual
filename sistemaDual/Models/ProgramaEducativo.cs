using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models
{
    

    public class ProgramaEducativo
    {
        public string ID { get; set; }
        
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string UniversidadID { get; set; }

        public Universidad Universidad { get; set; }

    }
}
