using AutoMapper;
using Permissions.Challenge.Api.Models;
using Permissions.Challenge.Data.Model;

namespace Permissions.Challenge.Api.Maps
{
    public class PermisoMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<Permiso, PermisoDto>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.NombreEmpleado, source => source.MapFrom(src => src.NombreEmpleado))
            .ForMember(destination => destination.ApellidosEmpleado, source => source.MapFrom(src => src.ApellidosEmpleado))
            .ForMember(destination => destination.Fecha, source => source.MapFrom(src => src.Fecha))
            .ForMember(destination => destination.TipoPermisoId, source => source.MapFrom(src => src.TipoPermisoId))
            .ForMember(destination => destination.TipoPermiso, source => source.MapFrom(src => src.TipoPermiso)).ReverseMap();

            var mapTipoPemriso = configuration.CreateMap<TipoPermiso, TipoPermisoDto>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Descripcion, source => source.MapFrom(src => src.Descripcion)).ReverseMap();
        }
    }
}

