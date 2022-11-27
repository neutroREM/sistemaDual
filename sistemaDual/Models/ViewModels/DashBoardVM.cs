namespace sistemaDual.Models.ViewModels
{
    public class DashBoardVM
    {
        public int TotalAlumnos { get; set; }

        public int TotalProgramas { get; set; }

        public int TotalEmpresas { get; set; }

        public int TotalProyectos { get; set; }

        public List<AlumnosSemanaVM> AlumnosSemanaVM { get; set; }

        public List<ProyectosMesVM> ProyectosMesVM { get; set; }
    }
}
