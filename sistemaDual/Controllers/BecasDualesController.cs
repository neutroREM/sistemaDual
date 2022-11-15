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
    public class BecasDualesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBecaDualService _becaService;

        public BecasDualesController(IMapper mapper, IBecaDualService becaService)
        {
           _mapper = mapper;
            _becaService = becaService;
        }

     
        public IActionResult Index()
        {
              return View();
        }

        //
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<BecaDualViewModel> becaVM = _mapper.Map<List<BecaDualViewModel>>(await _becaService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = becaVM });
        }

        //
        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<BecaDualViewModel> response = new GenericResponse<BecaDualViewModel>();
            try
            {
                BecaDualViewModel becaVM = JsonConvert.DeserializeObject<BecaDualViewModel>(modelo);

                BecaDual beca_creada = await _becaService.Crear(_mapper.Map<BecaDual>(becaVM));
                becaVM = _mapper.Map<BecaDualViewModel>(beca_creada);

                response.Estado = true;
                response.Objeto = becaVM;
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
            GenericResponse<BecaDualViewModel> response = new GenericResponse<BecaDualViewModel>();
            try
            {
                BecaDualViewModel becaVM = JsonConvert.DeserializeObject<BecaDualViewModel>(modelo);

                BecaDual beca_editada = await _becaService.Editar(_mapper.Map<BecaDual>(becaVM));
                becaVM = _mapper.Map<BecaDualViewModel>(beca_editada);

                response.Estado = true;
                response.Objeto = becaVM;
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
        public async Task<IActionResult> Eliminar(int becaDualID)
        {
            GenericResponse<BecaDualViewModel> response = new GenericResponse<BecaDualViewModel>();
            try
            {
                response.Estado = await _becaService.Eliminar(becaDualID);
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
