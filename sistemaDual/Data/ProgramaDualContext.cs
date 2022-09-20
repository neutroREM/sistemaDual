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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domicilio>().ToTable("Domicilio");
            modelBuilder.Entity<ProgramaEducativo>().ToTable("ProgramaEducativo");
            modelBuilder.Entity<Universidad>().ToTable("Universidad");
        }
    }
}
