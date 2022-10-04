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

            var universidades = new Universidad[]
            {
                new Universidad{UniversidadID="15EPO0003Y", NombreU="Universidad Politecnica de Tecamac"}
            };
            foreach(Universidad u in universidades)
            {
                context.Universidades.Add(u);
            }
            context.SaveChanges();


           
        }
    }
}
