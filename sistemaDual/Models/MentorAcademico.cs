namespace sistemaDual.Models
{
    public class MentorAcademico
    {
        public string CURP{ get; set; }
        public string nombre { get; set; }
        public string apellido_p { get; set; }
        public string apellido_m { get; set; }

        public string CCT4 { get; set; }
        public string CLAVE_PROGRAMA4 { get; set; }
        public Universidad Universidad { get; set; }
    }
}
