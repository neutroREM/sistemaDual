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
    public class MentoresEmpresarialesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMentorEmpresarialService _empresarialService;
        private readonly IEmpresaService _empresaService;

        public MentoresEmpresarialesController(IMapper mapper, IMentorEmpresarialService empresarialService, IEmpresaService empresaService)
        {
            _mapper = mapper;
            _empresarialService = empresarialService;
            _empresaService = empresaService;
        }

        // GET: MentoresEmpresariales
        public IActionResult Index()
        {
          
            return View();
        }


        // GET: MentoresEmpresariales/ListaEmpresas
        [HttpGet]
        public async Task<IActionResult> ListaEmpresas()
        {
            List<EmpresaViewModel> empresaVM = _mapper.Map<List<EmpresaViewModel>>(await _empresaService.Lista());
            return StatusCode(StatusCodes.Status200OK, empresaVM);
        }

        // GET: MentoresEmpresariales/Lista
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<MentorEmpresarialViewModel> mentorVM = _mapper.Map<List<MentorEmpresarialViewModel>>(await _empresarialService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = mentorVM });
        }


        // POST: MentoresEmpresariales/Crear
        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<MentorEmpresarialViewModel> response = new GenericResponse<MentorEmpresarialViewModel>();

            try
            {
                MentorEmpresarialViewModel mentorVM = JsonConvert.DeserializeObject<MentorEmpresarialViewModel>(modelo);
                string urlPlantillaCorreo = $"{this.Request.Scheme}://{this.Request.Host}/Plantilla/EnviarClave?correo=[correo]&clave=[clave]";

                MentorEmpresarial mentor_creado = await _empresarialService.Crear(_mapper.Map<MentorEmpresarial>(mentorVM), urlPlantillaCorreo);
                mentorVM = _mapper.Map<MentorEmpresarialViewModel>(mentor_creado);

                response.Estado = true;
                response.Objeto = mentorVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }


        // PUT: MentoresEmpresariales/Editar
        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<MentorEmpresarialViewModel> response = new GenericResponse<MentorEmpresarialViewModel>();

            try
            {
                MentorEmpresarialViewModel mentorVM = JsonConvert.DeserializeObject<MentorEmpresarialViewModel>(modelo);

                MentorEmpresarial mentor_creado = await _empresarialService.Editar(_mapper.Map<MentorEmpresarial>(mentorVM));
                mentorVM = _mapper.Map<MentorEmpresarialViewModel>(mentor_creado);

                response.Estado = true;
                response.Objeto = mentorVM;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        // DELETE: MentoresEmpresariales/Eliminar/MentorEmpresarialID
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int mentorEmpresarialID)
        {
            GenericResponse<MentorEmpresarialViewModel> response = new GenericResponse<MentorEmpresarialViewModel>();

            try
            {

                response.Estado = await _empresarialService.Eliminar(mentorEmpresarialID);
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
