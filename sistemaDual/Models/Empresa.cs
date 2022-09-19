using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class Empresa
    {
        [Key]
        public string RFC { get; set; }
        public string id_domicilio { get; set; }
        public string razon_social { get; set; }
        public string nombre_comercial { get; set; }
        public string sector { get; set; }
        public string representante_legal { get; set; }
        public string correo { get; set; }

        public int id_domicilio3 { get; set; }
        public Domicilio Domicilio { get; set; }

        public List<MentorEmpresarial> MentoresEmpresariales { get; set; }
        public List<CatalagoProyecto> CatalagoProyectos { get; set; }   
    }
}
