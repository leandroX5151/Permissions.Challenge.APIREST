using Permissions.Challenge.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Permissions.Challenge.Data.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(PermissionsContext context)
        {
            context.Database.Migrate();

            ////
            //if (!context.Permiso.Any())
            //{
            //    var pemriso = new Pillar[]
            //    {
            //    new Permiso { Nombre = "Leandro", Apellido = "Leandro" },
            //    new Permiso { Nombre = "Leandro", Apellido = "Leandro" }
            //    };
            //    context.Permiso.AddRange(permiso);
            //    context.SaveChanges();
            //}
        }
    }
}
