
using Permissions.Challenge.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Permissions.Challenge.Data.DAL
{
    public class PermissionsContext : DbContext
    {
        public PermissionsContext(DbContextOptions<PermissionsContext> options) : base(options)
        {
        }

        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
