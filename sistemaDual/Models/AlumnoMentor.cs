namespace sistemaDual.Models
{
    public class AlumnoMentor
    {
        public string AlumnoDualID { get; set; }
        public int MentorEmpresarialID { get; set; }

        public AlumnoDual AlumnoDual { get; set; }
        public MentorEmpresarial MentorEmpresarial { get; set; }
    }
}
