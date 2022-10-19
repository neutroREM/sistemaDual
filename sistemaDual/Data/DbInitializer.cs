using sistemaDual.Models;

namespace sistemaDual.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProgramaDualContext context)
        {
            context.Database.EnsureCreated();

            if (context.Universidades.Any() || context.Domicilios.Any())
            {
                return;
            }

            var conf = new Configuracion[]
            {
                new Configuracion{Recurso="Servicio_Correo", Propiedad="correo", Valor="neutrorem90@gmail.com"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="valor", Valor="qdbqmtjysvalihzh"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="alias", Valor="sistemadual.com"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="host", Valor="smtp.gmail.com"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="puerto", Valor="587"}
            };

            var domicilios = new Domicilio[]
            {
                new Domicilio{Direccion="Prolongacion 23de Mayo #100", Colonia="Felipe Villanueva", Municipio="Tecamac", CodigoPostal="55745"}
            };
            foreach(Domicilio dom in domicilios)
            {
                context.Domicilios.Add(dom);
            }
            context.SaveChanges();


            var universidades = new Universidad[]
            {
                new Universidad{UniversidadID="15EPO0003Y", NombreU="Universidad Politecnica de Tecamac", DomicilioID=1}
            };
            foreach(Universidad u in universidades)
            {
                context.Universidades.Add(u);
            }
            context.SaveChanges();


           
        }
    }
}
