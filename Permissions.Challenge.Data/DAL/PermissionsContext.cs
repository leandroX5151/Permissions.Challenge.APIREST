
using Permissions.Challenge.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Permissions.Challenge.Data.DAL
{
    public class PermissionsContext : DbContext
    {
        public PermissionsContext() {}

        public PermissionsContext(DbContextOptions<PermissionsContext> options) : base(options){}

        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<TipoPermiso> TipoPermiso { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
