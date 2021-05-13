using Permissions.Challenge.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Permissions.Challenge.Domain
{
    public interface IPermisoDomain
    {
        Task<Permiso> Add(Permiso permission);
        Task<bool> Delete(int permissionId);
        IEnumerable<Permiso> GetAll();
        Permiso GetById(int permissionId);
        Task<Permiso> Update(Permiso permission);
    }
}