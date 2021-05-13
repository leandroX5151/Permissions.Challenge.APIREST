using Permissions.Challenge.Data.DAL;
using Permissions.Challenge.Data.Model;
using System.Collections.Generic;

namespace Permissions.Challenge.Domain
{
    public class TipoPermisoDomain : ITipoPermisoDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoPermisoDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TipoPermiso> GetAll()
        {
            var permissions = _unitOfWork.Query<TipoPermiso>();
            return permissions;
        }
    }
}
