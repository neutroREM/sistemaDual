﻿namespace sistemaDual.Models.ViewModels
{
    public class AsignaturaViewModel
    {
        public int AsignaturaID { get; set; }

        public string Nombre { get; set; }

        public Periodo Periodo { get; set; }

        public string Competencia { get; set; }

        public string Actividad { get; set; }
    }
}