using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models.ViewModels
{
    public class ResponsableInstitucionalViewModel
    {
        public int ResposableInstitucionalID { get; set; }

        public string CURP { get; set; }

        public string NombreR { get; set; }
        
        public string ApellidoP { get; set; }
        
        public string ApellidoM { get; set; }
       
        public string Correo { get; set; }

        public int Telefono { get; set; }

        public string Cargo { get; set; }

        public string UniversidadID { get; set; }

        public string NombreU { get; set; }
    }
}
