using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_DashBoard.Context
{
    public class AplicacionDbContextBlue : DbContext
    {
        public AplicacionDbContextBlue(DbContextOptions<AplicacionDbContextBlue> options)
        : base(options)
        {

        }
        public DbSet<Delegacion> Delegaciones { get; set; }
        public DbSet<Secuencias> Secuencias { get; set; }
        public DbSet<RncEstado> RncEstados { get; set; }
        public DbSet<Contribuyente> Contribuyente { get; set; }
        public DbSet<TipoCertificacion> TipoCertificacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribuyente>()
            .HasKey(c => c.RNC);

            modelBuilder.Entity<TipoCertificacion>()
            .HasKey(tc => tc.Id);

            modelBuilder.Entity<TipoCertificacion>()
                .HasOne(tc => tc.Contribuyente)
                .WithMany(c => c.TiposCertificacion)
                .HasForeignKey(tc => tc.ContribuyenteId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
