using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Simple.Api.Application.Domain.Contracts.Ioc
{
    public interface IRegisterApiResources
    {
        void RegisterAppResources(IServiceCollection services, IConfiguration configuration);
    }
}
