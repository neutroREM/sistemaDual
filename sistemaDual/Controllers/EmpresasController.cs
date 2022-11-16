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
    public class EmpresasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaService _empresaService;

        public EmpresasController(IMapper mapper, IEmpresaService empresaService)
        {
            _mapper = mapper;
            _empresaService = empresaService;   
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
            List<EmpresaViewModel> empresaViewModels = _mapper.Map<List<EmpresaViewModel>>(await _empresaService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = empresaViewModels });
        }

        //
        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<EmpresaViewModel> response = new GenericResponse<EmpresaViewModel>();
            try
            {
                EmpresaViewModel empresaVM = JsonConvert.DeserializeObject<EmpresaViewModel>(modelo);

                Empresa empresa_creada = await _empresaService.Crear(_mapper.Map<Empresa>(empresaVM));

                empresaVM = _mapper.Map<EmpresaViewModel>(empresa_creada);

                response.Estado = true;
                response.Objeto = empresaVM;

            }catch(Exception ex)
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
            GenericResponse<EmpresaViewModel> response = new GenericResponse<EmpresaViewModel>();

            try
            {
                EmpresaViewModel empresaVM = JsonConvert.DeserializeObject<EmpresaViewModel>(modelo);
                Empresa empresa_editada = await _empresaService.Editar(_mapper.Map<Empresa>(empresaVM));

                empresaVM = _mapper.Map<EmpresaViewModel>(empresa_editada);
                response.Estado = true;
                response.Objeto = empresaVM;
            }
            catch(Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        //
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int empresaID)
        {
            GenericResponse<string> response = new GenericResponse<string>();
            try
            {
                response.Estado = await _empresaService.Eliminar(empresaID);
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
