namespace sistemaDual.Interfaces
{
    public interface IDashBoardService
    {
        Task<int> TotalProyectosUltimaSemana();

        Task<int> TotalAlumnosUltimaSemana();

        Task<int> TotalProgramasEducativos();

        Task<int> TotalEmpresas();

        Task<Dictionary<string, int>> ProyectosUltimaSemana();

        Task<Dictionary<string, int>> AlumnosUltimaSemana();
    }
}
