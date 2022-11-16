﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDual.Data;
using sistemaDual.Interfaces;
using sistemaDual.Models;
using sistemaDual.Models.ViewModels;
using sistemaDual.Utilidades.Response;

namespace sistemaDual.Controllers
{
    public class CatalagoProyectosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICatalagoProyectoService _proyectoService;

        public CatalagoProyectosController(IMapper mapper, ICatalagoProyectoService proyectoService)
        {
            _mapper = mapper;
            _proyectoService = proyectoService;    
        }

        public IActionResult NuevoProyecto()
        {
            return View();
        }

        public IActionResult HistorialProyectos()
        {
            return View();
        }

        //
        [HttpGet]
        public async Task<IActionResult> ObtenerAlumnos(string busqueda)
        {
            List<AlumnoDualViewModel> alumnoVM = _mapper.Map<List<AlumnoDualViewModel>>(await _proyectoService.ObtenerAlumnos(busqueda));
            return StatusCode(StatusCodes.Status200OK, alumnoVM);
        }

        //
        [HttpGet]
        public async Task<IActionResult> ObtenerEmpresas(string busqueda)
        {
            List<EmpresaViewModel> empresaVM = _mapper.Map<List<EmpresaViewModel>>(await _proyectoService.ObtenerEmpresas(busqueda));
            return StatusCode(StatusCodes.Status200OK, empresaVM);
        }

        //
        [HttpGet]
        public async Task<IActionResult> RegistrarProyecto([FromBody] CatalagoProyectoViewModel modelo)
        {
            GenericResponse<CatalagoProyectoViewModel> response = new GenericResponse<CatalagoProyectoViewModel>();
            try
            {
                CatalagoProyecto proyecto_creado = await _proyectoService.Registrar(_mapper.Map<CatalagoProyecto>(modelo));
                modelo = _mapper.Map<CatalagoProyectoViewModel>(proyecto_creado);

                response.Estado = true;
                response.Objeto = modelo;
            }
            catch (Exception ex)
            {
                response.Estado = true;
                response.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        public async Task<IActionResult> Historial(string numeroProyecto, string fechaInicio, string fechaFin)
        {
            List<CatalagoProyectoViewModel> historialProyectoVM = _mapper.Map<List<CatalagoProyectoViewModel>>(await _proyectoService.Historial(numeroProyecto, fechaInicio, fechaFin));
            return StatusCode(StatusCodes.Status200OK, historialProyectoVM);
        }

    }
}
