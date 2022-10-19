namespace sistemaDual.Interfaces
{
    public interface IUtilidadesService
    {
        string GenerarClave();

        string ConvertirSha256(string clave);
    }
}
