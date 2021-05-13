using Permissions.Challenge.Data.Model;
using System.Collections.Generic;

namespace Permissions.Challenge.Domain
{
    public interface ITipoPermisoDomain
    {
        IEnumerable<TipoPermiso> GetAll();
    }
}