namespace sistemaDual.Models
{
    public class ResponsableInstitucional
    {
        public string CURP { get; set; }
        public string nombre { get; set; }
        public string apellido_p { get; set; }
        public string apellido_m { get; set; }
        public string cargo { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }

        public string CCT5 { get; set; }
        public Universidad Universidad { get; set; }

        public List<CatalagoProyecto> CatalagoProyectoList { get; set; }
    }
}
