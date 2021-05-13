using AutoMapper;

namespace Permissions.Challenge.Api.Maps
{
    public interface IAutoMapperTypeConfigurator
    {
        void Configure(IMapperConfigurationExpression configuration);
    }
}
