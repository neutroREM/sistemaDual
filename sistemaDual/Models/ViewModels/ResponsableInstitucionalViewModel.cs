using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models.ViewModels
{
    public class ResponsableInstitucionalViewModel
    {
        public string ResposableInstitucionalID { get; set; }

        public string Nombre { get; set; }
        
        public string ApellidoP { get; set; }
        
        public string ApellidoM { get; set; }
       
        public string Correo { get; set; }

        public int Telefono { get; set; }

        public string Cargo { get; set; }

        public string UniversidadID { get; set; }
    }
}
