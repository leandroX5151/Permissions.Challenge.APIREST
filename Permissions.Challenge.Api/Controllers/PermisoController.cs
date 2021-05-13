using Microsoft.AspNetCore.Mvc;
using Permissions.Challenge.Api.Maps;
using Permissions.Challenge.Api.Models;
using Permissions.Challenge.Data.Model;
using Permissions.Challenge.Domain;
using Permissions.Challenge.Transversal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Permissions.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : Controller
    {
        private readonly IAppLogger<PermisoController> _logger;
        private readonly IAutoMapper _mapper;
        private readonly IPermisoDomain _permissionDomain;
        public PermisoController(IAppLogger<PermisoController> logger,
                                 IAutoMapper mapper,
                                 IPermisoDomain permissionDomain)
        {
            _mapper = mapper;
            _permissionDomain = permissionDomain;
            _logger = logger;
        }

        [HttpGet("Get")]
        public ActionResult<IEnumerable<PermisoDto>> Get()
        {
            try
            {
                var permissions = _mapper.Map<Permiso, PermisoDto>(_permissionDomain.GetAll());
                if (permissions == null || permissions.Length == 0)
                {
                    return NotFound();
                }
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("Get/{permissionId}")]
        public ActionResult<PermisoDto> GetById(int permissionId)
        {
            try
            {
                var permission = new PermisoDto();
                _mapper.Map<Permiso, PermisoDto>(_permissionDomain.GetById(permissionId), permission);
                if (permission == null || permission.Id == 0)
                {
                    return NotFound();
                }
                return Ok(permission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Permiso>> Add([FromBody] Permiso permission)
        {
            try
            {
                if (permission == null)
                {
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    await _permissionDomain.Add(permission);
                }

                return Ok(permission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }


        [HttpPut("Update")]
        public async Task<ActionResult<Permiso>> Update([FromBody] Permiso permission)
        {
            try
            {
                if (permission == null)
                {
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    await _permissionDomain.Update(permission);
                }
                return Ok(permission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("Delete/{permissionId}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] int permissionId)
        {
            try
            {
                return Ok(await _permissionDomain.Delete(permissionId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
