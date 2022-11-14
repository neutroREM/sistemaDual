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
        public async Task<IActionResult> Obtener()
        {
            GenericResponse<AsesorInstitucionalViewModel> response = new GenericResponse<AsesorInstitucionalViewModel>();
            try
            {
                AsesorInstitucionalViewModel asesorVM = _mapper.Map<AsesorInstitucionalViewModel>(await _asesorService.Obtener());
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

        [HttpPost]
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

    }
}
