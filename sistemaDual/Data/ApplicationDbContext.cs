using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using sistemaDual.Models;

namespace sistemaDual.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Alumno_Asignatura> Alumno_Asignaturas { get; set; }
        public DbSet<Alumno_MentorEmpresarial> Alumno_MentorEmpresarials { get; set; }
        public DbSet<Alumno_ProgramaEducativo> Alumno_ProgramaEducativos { get; set; }
        public DbSet<AsesorInstitucional> AsesorInstitucionals { get; set; }
        public DbSet<Asignatura> Asignaturas  { get; set; }
        public DbSet<BecaDual> BecaDuals  { get; set; }
        public DbSet<CatalagoProyecto> CatalagoProyectos { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Empresa> Empresas  { get; set; }
        public DbSet<Estatus> Estatus  { get; set; }
        public DbSet<MentorAcademico> MentorAcademicos { get; set; }
        public DbSet<MentorEmpresarial> MentorEmpresarials { get; set; }
        public DbSet<ProgramaEducativo> ProgramaEducativos { get; set; }
        public DbSet<ResponsableInstitucional> ResponsableInstitucionals  { get; set; }
        public DbSet<Universidad> Universidades { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .HasOne(e => e.id_domicilio1)
                .WithMany();


        }
    }
}
