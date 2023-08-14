using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_DashBoard.Context
{
    public class AplicacionDbContext: DbContext
    {

        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
        : base(options)
        {

        }
        public DbSet<Delegacion> Delegaciones { get; set; }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Delegacion>(entity =>
             {
                 entity.ToTable("Delegaciones");
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.Rnc).HasColumnName("RNC");
                 entity.Property(e => e.RazonSocial).HasColumnName("RAZON_SOCIAL");
                 entity.Property(e => e.NombreComercial).HasColumnName("NOMBRE_COMERCIAL");
                 entity.Property(e => e.ActividadEconomicaPrincipal).HasColumnName("ACTIVIDAD_ECONOMICA_PRINCIPAL");
                 entity.Property(e => e.ActividadEconomicaSecundaria).HasColumnName("ACTIVIDAD_ECONOMICA_SECUNDARIA");
                 entity.Property(e => e.Domicilio).HasColumnName("DOMICILIO");
                 entity.Property(e => e.CorreoElectronico).HasColumnName("CORREO_ELECTRONICO");
                 entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
                 entity.Property(e => e.Celular).HasColumnName("CELULAR");
                 entity.Property(e => e.CodigoProvincia).HasColumnName("COD_PROV");
                 entity.Property(e => e.CodigoMunicipio).HasColumnName("COD_MUN");
                 entity.Property(e => e.Logo).HasColumnName("LOGO").HasColumnType("BLOB");
                 entity.Property(e => e.ContentType).HasColumnName("TIPO_IMAGEN");
                 entity.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
                 entity.Property(e => e.FechaActualizacion).HasColumnName("FECHA_ACTUALIZACION");
                 entity.Property(e => e.InformacionAdicional).HasColumnName("INFORMACION_ADICIONAL");
                 entity.HasOne(p => p.ProvinciaContribuyente)
                .WithMany(c => c.Contribuyentes)
                .HasForeignKey(p => p.CodigoProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull);



                 entity.HasOne(p => p.MunicipioContribuyente)
                .WithMany(c => c.Contribuyentes)
                .HasForeignKey(p => p.CodigoMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull);



                 entity.HasIndex(i => i.Rnc).IsUnique();
             });
            */


    }
}


