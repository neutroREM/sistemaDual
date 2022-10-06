using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDual.Models.ViewModels
{
    public class UniversidadViewModel
    {
        public string UniversidadID { get; set; }

        public string NombreU { get; set; }

        public int DomicilioID { get; set; }
        

        
    }
}
