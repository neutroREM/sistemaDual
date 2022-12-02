namespace sistemaDual.Models.ViewModels
{
    public class DashBoardVM
    {
        public int TotalAlumnos { get; set; }

        public int TotalProgramas { get; set; }

        public int TotalEmpresas { get; set; }

        public int TotalProyectos { get; set; }

        public List<AlumnosSemanaVM>? AlumnosSemana { get; set; }

        public List<ProyectoSemanaVM>? ProyectoSemana { get; set; }
    }
}
