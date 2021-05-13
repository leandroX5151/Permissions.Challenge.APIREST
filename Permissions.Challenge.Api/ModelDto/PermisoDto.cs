using Permissions.Challenge.Data.Model;
using System;


namespace Permissions.Challenge.Api.Models
{
    public class PermisoDto
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public int TipoPermisoId { get; set; }
        public TipoPermiso TipoPermiso { get; set; }
        public DateTime Fecha { get; set; }
    }
}
