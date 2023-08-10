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
        public DbSet<Delegacion> Delegacion { get; set; }
    }
}
