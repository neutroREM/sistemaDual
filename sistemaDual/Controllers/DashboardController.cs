using Microsoft.AspNetCore.Mvc;
using sistemaDual.Interfaces;
using sistemaDual.Models.ViewModels;
using sistemaDual.Utilidades.Response;

namespace sistemaDual.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashBoardService _dashService;

        public DashboardController(IDashBoardService dashService)
        {
            _dashService = dashService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //
        [HttpGet]
        public async Task<IActionResult> ObtenerResumen()
        {
            GenericResponse<DashBoardVM> response = new GenericResponse<DashBoardVM>();

            try
            {
                DashBoardVM dashBoardVM = new DashBoardVM();

                dashBoardVM.TotalAlumnos = await _dashService.TotalAlumnosUtimaSemana();
                dashBoardVM.TotalProgramas = await _dashService.TotalProyectosUltimoMes();
                dashBoardVM.TotalProgramas = await _dashService.TotalProgramasEducativos();
                dashBoardVM.TotalEmpresas = await _dashService.TotalEmpresas();

                List<AlumnosSemanaVM> listAlumnoSemana = new List<AlumnosSemanaVM>();
                List<ProyectosMesVM> ListaproyectosMes = new List<ProyectosMesVM>();

                foreach (KeyValuePair<string, int> item in await _dashService.ProyectoUltimoMes())
                {
                    ListaproyectosMes.Add(new ProyectosMesVM()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }

                foreach(KeyValuePair<string, int> item in await _dashService.AlumnosUltimaSemana())
                {
                    listAlumnoSemana.Add(new AlumnosSemanaVM()
                    {
                        NombreA = item.Key,
                        Promedio = item.Value
                    });

                    dashBoardVM.ProyectosMesVM = ListaproyectosMes;
                    dashBoardVM.AlumnosSemanaVM = listAlumnoSemana;
                }

                response.Estado = true;
                response.Objeto = dashBoardVM;

            }
            catch (Exception ex)
            {
                response.Estado = true;
                response.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
