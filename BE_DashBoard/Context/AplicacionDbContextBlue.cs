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
    }
}
