using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public class ResponsablesInstitucionalesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IResponsableInstitucionalService _responsableService;
        private readonly IUniversidadService _universidadService;

        public ResponsablesInstitucionalesController(IResponsableInstitucionalService responsableService, IMapper mapper, IUniversidadService universidadService)
        {
            _responsableService = responsableService;
            _mapper = mapper;
            _universidadService = universidadService;
        }


        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListaUniversidades()
        {
            List<UniversidadViewModel> universidadVM = _mapper.Map<List<UniversidadViewModel>>(await _universidadService.Lista());
            return StatusCode(StatusCodes.Status200OK, universidadVM);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<ResponsableInstitucionalViewModel> respVM = _mapper.Map<List<ResponsableInstitucionalViewModel>>(await _responsableService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = respVM });
        }



        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<ResponsableInstitucionalViewModel> response = new GenericResponse<ResponsableInstitucionalViewModel>();
            try
            {
                ResponsableInstitucionalViewModel responsableVM = JsonConvert.DeserializeObject<ResponsableInstitucionalViewModel>(modelo);
                ResponsableInstitucional responsable_editar = await _responsableService.Crear(_mapper.Map<ResponsableInstitucional>(responsableVM));

                responsableVM = _mapper.Map<ResponsableInstitucionalViewModel>(responsable_editar);

                response.Estado = true;
                response.Objeto = responsableVM;
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
            GenericResponse<ResponsableInstitucionalViewModel> response = new GenericResponse<ResponsableInstitucionalViewModel>();
            try
            {
                ResponsableInstitucionalViewModel responsableVM = JsonConvert.DeserializeObject<ResponsableInstitucionalViewModel>(modelo);
                ResponsableInstitucional responsable_editar = await _responsableService.GuardarCambios(_mapper.Map<ResponsableInstitucional>(responsableVM));

                responsableVM = _mapper.Map<ResponsableInstitucionalViewModel>(responsable_editar);

                response.Estado = true;
                response.Objeto = responsableVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }


        [HttpDelete]
        public async Task<IActionResult> Eliminar(int responsableInstitucionalID)
        {
            GenericResponse<AsesorInstitucionalViewModel> response = new GenericResponse<AsesorInstitucionalViewModel>();
            try
            {

                response.Estado = await _responsableService.Eliminar(responsableInstitucionalID);
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
