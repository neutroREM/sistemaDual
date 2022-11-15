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
    public class AsignaturasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAsignaturaService _asignaturaService;

        public AsignaturasController(IMapper mapper, IAsignaturaService asignaturaService)
        {
            _mapper = mapper;
            _asignaturaService = asignaturaService;
        }


        public IActionResult Index()
        {
              return View();
        }


        //
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<AsignaturaViewModel> asignaturaVM = _mapper.Map<List<AsignaturaViewModel>>(await _asignaturaService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = asignaturaVM });
        }

        //
        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<AsignaturaViewModel> response = new GenericResponse<AsignaturaViewModel>();
            try
            {
                AsignaturaViewModel asignaturaVM = JsonConvert.DeserializeObject<AsignaturaViewModel>(modelo);

                Asignatura asignatura_creada = await _asignaturaService.Crear(_mapper.Map<Asignatura>(asignaturaVM));
                asignaturaVM = _mapper.Map<AsignaturaViewModel>(asignatura_creada);

                response.Estado = true;
                response.Objeto = asignaturaVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        //
        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<AsignaturaViewModel> response = new GenericResponse<AsignaturaViewModel>();
            try
            {
                AsignaturaViewModel asignaturaVM = JsonConvert.DeserializeObject<AsignaturaViewModel>(modelo);

                Asignatura asignatura_editada = await _asignaturaService.Editar(_mapper.Map<Asignatura>(asignaturaVM));
                asignaturaVM = _mapper.Map<AsignaturaViewModel>(asignatura_editada);

                response.Estado = true;
                response.Objeto = asignaturaVM;
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
        public async Task<IActionResult> Eliminar(int asignaturaID)
        {
            GenericResponse<AsignaturaViewModel> response = new GenericResponse<AsignaturaViewModel>();
            try
            {
                response.Estado = await _asignaturaService.Eliminar(asignaturaID);
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
