namespace sistemaDual.Models
{
    public class AsesorInstitucional
    {
        public string CURP{ get; set; }
        public string nombre { get; set; }
        public string apellido_p { get; set; }
        public string apellido_m { get; set; }

        public string CCT2 { get; set; }
        public string CLAVE_PROGRAMA3 { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
        public Universidad Universidad { get; set; }

        public List<CatalagoProyecto> CatalagoProyectoList { get; set; }
    }
}
