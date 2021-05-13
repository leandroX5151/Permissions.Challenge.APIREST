using Microsoft.AspNetCore.Mvc;
using Permissions.Challenge.Api.Maps;
using Permissions.Challenge.Data.Model;
using Permissions.Challenge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisoController : Controller
    {
        private readonly IAutoMapper _mapper;
        private readonly ITipoPermisoDomain _permissionTypeDomain;
        public TipoPermisoController(IAutoMapper mapper,
                                     ITipoPermisoDomain permissionTypeDomain)
        {
            _mapper = mapper;
            _permissionTypeDomain = permissionTypeDomain;
        }

        [HttpGet("Get")]
        public ActionResult<IEnumerable<TipoPermiso>> Get()
        {
            try
            {
                var permissionType = _permissionTypeDomain.GetAll();
                return Ok(permissionType);
            }
            catch (Exception ex)
            {
                // TODO: ILLOGER
                return BadRequest(ex.Message);
            }
        }
    }
}
