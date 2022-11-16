using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDual.Data;
using sistemaDual.Models;
using sistemaDual.Models.ViewModels;
using AutoMapper;
using Newtonsoft.Json;
using sistemaDual.Interfaces;
using sistemaDual.Utilidades.Response;

namespace sistemaDual.Controllers
{
    public class AlumnosDualesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAlumnoService _alumnoService;
        private readonly IRolService _rolService;

        public AlumnosDualesController(IMapper mapper, IAlumnoService alumnoService, IRolService rolService)
        {
            _mapper = mapper;
            _alumnoService = alumnoService;
            _rolService = rolService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: AlumnosDuales/ListaRoles
        [HttpGet]
        public async Task<IActionResult> ListaRoles()
        {
            List<RolViewModel> rolViewModels = _mapper.Map<List<RolViewModel>>(await _rolService.Lista());
            return StatusCode(StatusCodes.Status200OK, rolViewModels);
        }

        // GET: AlumnosDuales/Lista
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<AlumnoDualViewModel> alumnoViewModels = _mapper.Map<List<AlumnoDualViewModel>>(await _alumnoService.Lista());
            return StatusCode(StatusCodes.Status200OK, new {data = alumnoViewModels});
        }

        // POST: AlumnosDuales/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string modelo)
        {
            GenericResponse<AlumnoDualViewModel> response = new GenericResponse<AlumnoDualViewModel>();
            
            try
            {
                AlumnoDualViewModel alumnoDualVM = JsonConvert.DeserializeObject<AlumnoDualViewModel>(modelo);

                string urlPlantillaCorreo = $"{this.Request.Scheme}://{this.Request.Host}/Plantilla/EnviarClave?correo=[correo]&clave=[clave]";

                AlumnoDual alumno_creado = await _alumnoService.Crear(_mapper.Map<AlumnoDual>(alumnoDualVM), urlPlantillaCorreo);

                alumnoDualVM = _mapper.Map<AlumnoDualViewModel>(alumno_creado);

                response.Estado = true;
                response.Objeto = alumnoDualVM;
            }
            catch(Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }


        // POST: AlumnosDuales/Editar
        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<AlumnoDualViewModel> response = new GenericResponse<AlumnoDualViewModel>();

            try
            {
                AlumnoDualViewModel alumnoDualVM = JsonConvert.DeserializeObject<AlumnoDualViewModel>(modelo);
                AlumnoDual alumno_editado = await _alumnoService.Editar(_mapper.Map<AlumnoDual>(alumnoDualVM));

                alumnoDualVM = _mapper.Map<AlumnoDualViewModel>(alumno_editado);
                response.Estado = true;
                response.Objeto = alumnoDualVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }



        // DELETE: AlumnosDuales/Eliminar/AlumnoDualID
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int alumnoDualID)
        {
            GenericResponse<string> response = new GenericResponse<string>();

            try
            {
                response.Estado = await _alumnoService.Eliminar(alumnoDualID);
            }
            catch(Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }

        
    }
}
