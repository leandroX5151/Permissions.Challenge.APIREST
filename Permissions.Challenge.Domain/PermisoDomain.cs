using Microsoft.EntityFrameworkCore;
using Permissions.Challenge.Data.DAL;
using Permissions.Challenge.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Challenge.Domain
{
    public class PermisoDomain : IPermisoDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermisoDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Permiso> GetAll()
        {
            var permissions = _unitOfWork.Query<Permiso>()
                            .Include(x => x.TipoPermiso);
            return permissions;
        }
        public Permiso GetById(int permissionId)
        {
            var permission = _unitOfWork.Query<Permiso>()
                            .Include(x => x.TipoPermiso)
                            .FirstOrDefault(p => p.Id == permissionId);
            return permission;
        }
        public async Task<Permiso> Add(Permiso permission)
        {
            if (permission != null)
            {
                _unitOfWork.Add<Permiso>(permission);
                await _unitOfWork.CommitAsync();
            }
            return permission;
        }
        public async Task<Permiso> Update(Permiso permission)
        {
            if (permission != null)
            {
                _unitOfWork.Update<Permiso>(permission);
                await _unitOfWork.CommitAsync();
            }
            return permission;
        }
        public async Task<bool> Delete(int permissionId)
        {
            var result = false;
            var permission = _unitOfWork.Query<Permiso>()
                                      .FirstOrDefault(p => p.Id == permissionId);

            if (permission != null)
            {
                _unitOfWork.Remove<Permiso>(permission);
                await _unitOfWork.CommitAsync();
                result = true;
            }

            return result;
        }
    }
}
