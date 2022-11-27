namespace sistemaDual.Interfaces
{
    public interface IDashBoardService
    {
        Task<int> TotalProyectosUltimoMes();

        Task<int> TotalAlumnosUtimaSemana();

        Task<int> TotalProgramasEducativos();

        Task<int> TotalEmpresas();

        Task<Dictionary<string, int>> ProyectoUltimoMes();

        Task<Dictionary<string, int>> AlumnosUltimaSemana();
    }
}
