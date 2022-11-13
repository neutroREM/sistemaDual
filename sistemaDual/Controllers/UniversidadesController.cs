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
using sistemaDual.Interfaces;
using sistemaDual.Models;
using sistemaDual.Models.ViewModels;
using sistemaDual.Utilidades.Response;

namespace sistemaDual.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUniversidadService _univeridadService;

        public UniversidadesController(IMapper mapper, IUniversidadService universidadService)
        {
            _mapper = mapper;
            _univeridadService = universidadService;

        }

        //
        public IActionResult Index()
        {
            return View();
        }

        //
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<UniversidadViewModel> universidadVM = _mapper.Map<List<UniversidadViewModel>>(await _univeridadService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = universidadVM });
        }

        //
        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<UniversidadViewModel> response = new GenericResponse<UniversidadViewModel>();
            try
            { 
                UniversidadViewModel universidadVM = JsonConvert.DeserializeObject<UniversidadViewModel>(modelo);

                Universidad universidad_creada = await _univeridadService.Crear(_mapper.Map<Universidad>(universidadVM));

                universidadVM = _mapper.Map<UniversidadViewModel>(universidad_creada);

                response.Estado = true;
                response.Objeto = universidadVM;

            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        //ERROROR
        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<UniversidadViewModel> response = new GenericResponse<UniversidadViewModel>();
            try
            {
                UniversidadViewModel universidadVM = JsonConvert.DeserializeObject<UniversidadViewModel>(modelo);
                Universidad universidad_editada = await _univeridadService.Editar(_mapper.Map<Universidad>(universidadVM));

                universidadVM = _mapper.Map<UniversidadViewModel>(universidad_editada);

                response.Estado = true;
                response.Objeto = universidadVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        //
        [HttpDelete]
        public async Task<IActionResult> Eliminar(string universidadID)
        {
            GenericResponse<string> response = new GenericResponse<string>();
            try
            {
                response.Estado = await _univeridadService.Eliminar(universidadID);
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
