namespace sistemaDual.Models
{
    public class Asignatura
    {
        public string CLAVE { get; set; }
        public string nombre { get; set; }
        public string periodo { get; set; }
        public string competencia { get; set; }
        public string actividad { get; set; }

        public string CLAVE_PROGRAMA6 { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
    }
}
