﻿using sistemaDual.Models;

namespace sistemaDual.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProgramaDualContext context)
        {
            context.Database.EnsureCreated();

            if (context.Universidades.Any() && context.ProgramasEducativos.Any())
            {
                return;
            }


            var domicilios = new Domicilio[]
            {
                new Domicilio{Direccion="Prolongacion 5 de Mayo #10", Colonia="Felipe Villanueva", Municipio="Tecamac", CodigoPostal="55740", Otros="No"}
            };
            foreach (Domicilio d in domicilios)
            {
                context.Domicilios.Add(d);
            }
            context.SaveChanges();


            var universidades = new Universidad[]
            {
                new Universidad{ID="15EPO003Y", Nombre="Universidad Politecnica de Tecamac", DomicilioID=11}
            };
            foreach(Universidad u in universidades)
            {
                context.Universidades.Add(u);
            }
            context.SaveChanges();


            var programasEducativos = new ProgramaEducativo[]
            {
                new ProgramaEducativo{Nombre="Educacion Dual", Version="Primera", UniversidadID="15EPO0003Y"}
            };
            foreach (ProgramaEducativo p in programasEducativos)
            {
                context.ProgramasEducativos.Add(p);
            }
            context.SaveChanges();
        }
    }
}
