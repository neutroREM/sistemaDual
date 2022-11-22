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
    public class AsesoresInstitucionalesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAsesorInstitucionalService _asesorService;
        private readonly IProgramaEducativoService _programaService;

        public AsesoresInstitucionalesController(IMapper mapper, IAsesorInstitucionalService asesorService, IProgramaEducativoService programaService)
        {
            _mapper = mapper;
            _asesorService = asesorService;
            _programaService = programaService;
        }


        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListaProgramas()
        {
            List<ProgramaEducativoViewModel> programaVM = _mapper.Map<List<ProgramaEducativoViewModel>>(await _programaService.Lista());
            return StatusCode(StatusCodes.Status200OK, programaVM);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<AsesorInstitucionalViewModel> asesorVM = _mapper.Map<List<AsesorInstitucionalViewModel>>(await _asesorService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = asesorVM });
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<AsesorInstitucionalViewModel> response = new GenericResponse<AsesorInstitucionalViewModel>();
            try
            {
                AsesorInstitucionalViewModel asesorVM = JsonConvert.DeserializeObject<AsesorInstitucionalViewModel>(modelo);
                AsesorInstitucional asesor_crear = await _asesorService.Crear(_mapper.Map<AsesorInstitucional>(asesorVM));

                asesorVM = _mapper.Map<AsesorInstitucionalViewModel>(asesor_crear);

                response.Estado = true;
                response.Objeto = asesorVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }


        [HttpPut]
        public async Task<IActionResult> GuardarCambios([FromForm] string modelo)
        {
            GenericResponse<AsesorInstitucionalViewModel> response = new GenericResponse<AsesorInstitucionalViewModel>();
            try
            {
                AsesorInstitucionalViewModel asesorVM = JsonConvert.DeserializeObject<AsesorInstitucionalViewModel>(modelo);
                AsesorInstitucional asesor_editar = await _asesorService.GuardarCambios(_mapper.Map<AsesorInstitucional>(asesorVM));

                asesorVM = _mapper.Map<AsesorInstitucionalViewModel>(asesor_editar);

                response.Estado = true;
                response.Objeto = asesorVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int asesorInstitucionalID)
        {
            GenericResponse<AsesorInstitucionalViewModel> response = new GenericResponse<AsesorInstitucionalViewModel>();
            try
            {

                response.Estado = await _asesorService.Eliminar(asesorInstitucionalID);
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
