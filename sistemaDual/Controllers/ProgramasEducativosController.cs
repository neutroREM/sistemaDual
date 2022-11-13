using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistemaDual.Data;
using sistemaDual.Implementation;
using sistemaDual.Interfaces;
using sistemaDual.Models;
using sistemaDual.Models.ViewModels;
using sistemaDual.Utilidades.Response;

namespace sistemaDual.Controllers
{
    public class ProgramasEducativosController : Controller
    {
        private readonly IProgramaEducativoService _programaService;
        private readonly IUniversidadService _universidadService;
        private readonly IMapper _mapper;

        public ProgramasEducativosController(IProgramaEducativoService programaService, IMapper mapper, IUniversidadService universidadService)
        {
            _programaService = programaService;
            _universidadService = universidadService;
            _mapper = mapper;   
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: MentoresEmpresariales/ListaUniversidades
        [HttpGet]
        public async Task<IActionResult> ListaUniversidades()
        {
            List<UniversidadViewModel> empresaVM = _mapper.Map<List<UniversidadViewModel>>(await _universidadService.Lista());
            return StatusCode(StatusCodes.Status200OK, empresaVM);
        }

        public async Task<IActionResult> Lista()
        {
            List<ProgramaEducativoViewModel> programaVM = _mapper.Map<List<ProgramaEducativoViewModel>>(await _programaService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = programaVM });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<ProgramaEducativoViewModel> response = new GenericResponse<ProgramaEducativoViewModel>();
            try
            {
                ProgramaEducativoViewModel programaVM = JsonConvert.DeserializeObject<ProgramaEducativoViewModel>(modelo);

                ProgramaEducativo programa_creado = await _programaService.Crear(_mapper.Map<ProgramaEducativo>(programaVM));

                programaVM = _mapper.Map<ProgramaEducativoViewModel>(programa_creado);

                response.Estado = true;
                response.Objeto = programaVM;

            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }



        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<ProgramaEducativoViewModel> response = new GenericResponse<ProgramaEducativoViewModel>();
            try
            {
                ProgramaEducativoViewModel programaVM = JsonConvert.DeserializeObject<ProgramaEducativoViewModel>(modelo);

                ProgramaEducativo programa_editado = await _programaService.Editar(_mapper.Map<ProgramaEducativo>(programaVM));

                programaVM = _mapper.Map<ProgramaEducativoViewModel>(programa_editado);

                response.Estado = true;
                response.Objeto = programaVM;

            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int programaEducativoID)
        {
            GenericResponse<ProgramaEducativoViewModel> response = new GenericResponse<ProgramaEducativoViewModel>();
            try
            {

                response.Estado = await _programaService.Eliminar(programaEducativoID);

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
