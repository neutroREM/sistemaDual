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
    public class MentoresAcademicosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMentorAcademicoService _mentorService;
        private readonly IProgramaEducativoService _programaService;

        public MentoresAcademicosController(IMapper mapper, IMentorAcademicoService mentorService, IProgramaEducativoService programaService)
        {
            _mapper = mapper;
            _mentorService = mentorService;
            _programaService = programaService;
        }

        // GET: MentorAcademicoes
        public IActionResult Index()
        {
            return View();
        }

        // GET: MentoresAcademicos/ListaProgramas
        [HttpGet]
        public async Task<IActionResult> ListaProgramas()
        {
            List<ProgramaEducativoViewModel> programaVM = _mapper.Map<List<ProgramaEducativoViewModel>>(await _programaService.Lista());
            return StatusCode(StatusCodes.Status200OK, programaVM);
        }

        // GET: MentoresAcademicos/Lista
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<MentorAcademicoViewModel> mentorVM = _mapper.Map<List<MentorAcademicoViewModel>>(await _mentorService.Lista());
            return StatusCode(StatusCodes.Status200OK, new { data = mentorVM });
        }

        // POST: MentoresEmpresariales/Crear
        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<MentorAcademicoViewModel> response = new GenericResponse<MentorAcademicoViewModel>();

            try
            {
                MentorAcademicoViewModel mentorVM = JsonConvert.DeserializeObject<MentorAcademicoViewModel>(modelo);
               
                MentorAcademico mentor_creado = await _mentorService.Crear(_mapper.Map<MentorAcademico>(mentorVM));
                mentorVM = _mapper.Map<MentorAcademicoViewModel>(mentor_creado);

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

        // PUT: MentoresAcademicos/Editar
        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<MentorAcademicoViewModel> response = new GenericResponse<MentorAcademicoViewModel>();

            try
            {
                MentorAcademicoViewModel mentorVM = JsonConvert.DeserializeObject<MentorAcademicoViewModel>(modelo);

                MentorAcademico mentor_editado = await _mentorService.Editar(_mapper.Map<MentorAcademico>(mentorVM));
                mentorVM = _mapper.Map<MentorAcademicoViewModel>(mentor_editado);

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

        // DELETE: MentoresAcademicos/Eliminar/MentorAcademicoID
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int mentorAcademicoID)
        {
            GenericResponse<MentorAcademicoViewModel> response = new GenericResponse<MentorAcademicoViewModel>();
            try
            {
                response.Estado = await _mentorService.Eliminar(mentorAcademicoID);
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
