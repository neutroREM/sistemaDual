using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IMentorEmpresarialService
    {
        Task<List<MentorEmpresarial>> Lista();

        Task<MentorEmpresarial> Crear(MentorEmpresarial entidad, string urlPlantillaCorreo = "");

        Task<MentorEmpresarial> Editar(MentorEmpresarial entidad);

        Task<bool> Eliminar(int MentorEmpresarialID);

        Task<MentorEmpresarial> ObtenerXCredenciales(string correo, string clave);

        Task<MentorEmpresarial> ObtenerXCurp(string curp);

        Task<bool> GuardarPeril(MentorEmpresarial entidad);

        Task<bool> CambiarClave(int mentorEmpresarialID, string clave, string claveNueva);

        Task<bool> RestablecerClave(string correo, string urlPlantillaCorreo = "");
    }
}
