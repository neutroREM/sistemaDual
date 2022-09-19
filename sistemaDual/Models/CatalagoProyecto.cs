using System.ComponentModel.DataAnnotations;

namespace sistemaDual.Models
{
    public class CatalagoProyecto
    {
        [Key]
        public string CLAVE { get; set; }
        public string nombre { get; set; }
        public string etapa { get; set; }
        public string area_conocimiento { get; set; }
        public int num_hora_dual { get; set; }

        public string CLAVE_PROGRAMA1 { get; set; }
        public string CURP_ASESOR_I { get; set; }
        public string CURP_MENTOR_E2 { get; set; }
        public string CURP_RESPONSABLE { get; set; }
        public string CURP_ALUMNO2 { get; set; }
        public string RFC_EMPRESA2 { get; set; }
        public Empresa Empresa { get; set; }
        public Alumno Alumno { get; set; }
        public ResponsableInstitucional ResponsableInstitucional { get; set; }
        public MentorEmpresarial MentorEmpresarial { get; set; }
        public AsesorInstitucional AsesorInstitucional { get; set; }
        public ProgramaEducativo ProgramaEducativo { get; set; }
    }
}
