namespace sistemaDual.Models
{
    public class AlumnoMentor
    {
        public int AlumnoDualID { get; set; }
        public int MentorEmpresarialID { get; set; }

        public AlumnoDual AlumnoDual { get; set; }
        public MentorEmpresarial MentorEmpresarial { get; set; }
    }
}
