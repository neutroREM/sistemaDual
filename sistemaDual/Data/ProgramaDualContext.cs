using Microsoft.EntityFrameworkCore;
using sistemaDual.Models;

namespace sistemaDual.Data
{
    public class ProgramaDualContext : DbContext
    {
        //ctor
        public ProgramaDualContext(DbContextOptions<ProgramaDualContext> options) : base(options)
        {
        }
       
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<ProgramaEducativo> ProgramasEducativos { get; set; }
        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<AlumnoDual> AlumnosDuales { get; set; }
        public DbSet<AsesorInstitucional> AsesoresInstitucionales { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<BecaDual> BecasDuales { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<MentorAcademico> MentoresAcademicos { get; set; }
        public DbSet<MentorEmpresarial> MentoresEmpresariales { get; set; }
        public DbSet<ResponsableInstitucional> ResponsablesInstitucionales { get; set; }
        public DbSet<AlumnoMentor> AlumnosMentores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlumnoDual>().ToTable("AlumnoDual");
            modelBuilder.Entity<Domicilio>().ToTable("Domicilio");
            modelBuilder.Entity<ProgramaEducativo>().ToTable("ProgramaEducativo");
            modelBuilder.Entity<Universidad>().ToTable("Universidad");
            modelBuilder.Entity<AsesorInstitucional>().ToTable("AsesorInstitucional");
            modelBuilder.Entity<Asignatura>().ToTable("Asignatura");
            modelBuilder.Entity<BecaDual>().ToTable("BecaDual");
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<MentorAcademico>().ToTable("MentorAcademico");
            modelBuilder.Entity<MentorEmpresarial>().ToTable("MentorEmpresarial");
            modelBuilder.Entity<ResponsableInstitucional>().ToTable("ResponsableInstitucional");
            modelBuilder.Entity<AlumnoMentor>()
                .HasKey(c => new { c.AlumnoDualID, c.MentorEmpresarialID });
        }
    }
}
