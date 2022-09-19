using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Universidad
    {
        [Key]
        public string CCT { get; set; }
        public string nombre { get; set; }
       
        public int id_domicilio2 { get; set; }
        public Domicilio Domicilio { get; set; }

        public List<ProgramaEducativo> ProgramasEducativos { get; set; }
        public List<ResponsableInstitucional> ResponsablesInstitucionales { get; set; }
    }
}
