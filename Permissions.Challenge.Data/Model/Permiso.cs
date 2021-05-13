using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Challenge.Data.Model
{
    public class Permiso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreEmpleado { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApellidosEmpleado { get; set; }

        [Required]
        public int TipoPermisoId { get; set; }

        public TipoPermiso TipoPermiso { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

    }
}
