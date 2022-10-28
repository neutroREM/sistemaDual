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

            
            var estatus = new Estatus[]
            {
                new Estatus{Descripcion="Activo"},
                new Estatus{Descripcion="Egresado"},
                new Estatus{Descripcion ="Baja Definitiva del MED"},
                new Estatus{Descripcion ="Baja Temporal del MED"},
                new Estatus{Descripcion ="Baja Definitiva de la IES"},
                new Estatus{Descripcion ="Baja Temporal de la IES"}
            };
            foreach(Estatus status in estatus)
            {
                context.Estatus.Add(status);
            }
            context.SaveChanges();


            var domicilios = new Domicilio[]
            {
                new Domicilio{Direccion="Prolongacion 23de Mayo #100", Colonia="Felipe Villanueva", Municipio="Tecamac", CodigoPostal="55745"},
                new Domicilio{Direccion="ve", Colonia="res", Municipio="Ecatepa", CodigoPostal="55123"}
            };
            foreach (Domicilio dom in domicilios)
            {
                context.Domicilios.Add(dom);
            }
            context.SaveChanges();


            var roles = new Rol[]
           {
                new Rol{Descripcion="Administrador", EsActivo = true, FechaRegistro=DateTime.Now},
                new Rol{Descripcion="Usuario", EsActivo = true, FechaRegistro=DateTime.Now},
                new Rol{Descripcion="Supervisor", EsActivo = true, FechaRegistro=DateTime.Now}
           };
            foreach (Rol rol in roles)
            {
                context.Roles.Add(rol);
            }
            context.SaveChanges();

            var alumnos = new AlumnoDual[]
            {
                new AlumnoDual{AlumnoDualID="EAMR000814HMCSJLA6", Matricula="1319104647", Nombre="Raul", ApellidoP="Estrada", ApellidoM="Mejia",Telefono="132933",DomicilioID=2, Correo="dhamarloka90@gmail.com", Cuatrimestre="Decimo", Tipo="NuevoIngreso", Promedio=8.0, EsActivo = true, RolID=1, EstatusID = 1,FechaRegistro=DateTime.Now}
            };
            foreach(AlumnoDual alumno in alumnos)
            {
                context.AlumnosDuales.Add(alumno);
            }
            context.SaveChanges();

            var conf = new Configuracion[]
            {
                new Configuracion{Recurso="Servicio_Correo", Propiedad="correo", Valor="neutrorem90@gmail.com"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="clave", Valor="qdbqmtjysvalihzh"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="alias", Valor="sistemadual.com"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="host", Valor="smtp.gmail.com"},
                new Configuracion{Recurso="Servicio_Correo", Propiedad="puerto", Valor="587"}
            };
            foreach (Configuracion confg in conf)
            {
                context.Configuraciones.Add(confg);
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
