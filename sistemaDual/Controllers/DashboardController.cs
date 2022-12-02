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

                dashBoardVM.TotalAlumnos = await _dashService.TotalAlumnosUltimaSemana();
                dashBoardVM.TotalProyectos = await _dashService.TotalProyectosUltimaSemana();
                dashBoardVM.TotalProgramas = await _dashService.TotalProgramasEducativos();
                dashBoardVM.TotalEmpresas = await _dashService.TotalEmpresas();

                List<AlumnosSemanaVM> listAlumnoSemana = new List<AlumnosSemanaVM>();
                List<ProyectoSemanaVM> listaProyectosSemana= new List<ProyectoSemanaVM>();

                foreach (KeyValuePair<string, int> item in await _dashService.ProyectosUltimaSemana())
                {
                    listaProyectosSemana.Add(new ProyectoSemanaVM()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }

                foreach(KeyValuePair<string, int> item in await _dashService.AlumnosUltimaSemana())
                {
                    listAlumnoSemana.Add(new AlumnosSemanaVM()
                    {
                        Alumno = item.Key,
                        Cantidad = item.Value
                    });

                    dashBoardVM.ProyectoSemana= listaProyectosSemana;
                    dashBoardVM.AlumnosSemana = listAlumnoSemana;
                }

                response.Estado = true;
                response.Objeto = dashBoardVM;

            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
