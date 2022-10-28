 using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IAlumnoService
    {
        Task<List<AlumnoDual>> Lista();

        Task<AlumnoDual> Crear(AlumnoDual entidad, string urlPlantillaCorreo = "");

        Task<AlumnoDual> Editar(AlumnoDual entidad);

        Task<bool> Eliminar(string AlumnoDualID);

        Task<AlumnoDual> ObtenerXCredenciales(string correo, string clave);

        Task<AlumnoDual> ObtenerXCurp(string curp);

        Task<bool> GuardarPeril(AlumnoDual entidad);

        Task<bool> CambiarClave (string alumnoID, string clave, string claveNueva);

        Task<bool> RestablecerClave (string correo, string urlPlantillaCorreo = "");
    }
}
