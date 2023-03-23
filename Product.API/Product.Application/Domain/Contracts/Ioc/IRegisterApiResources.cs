using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Product.Application.Domain.Contracts.Ioc
{
    public interface IRegisterApiResources
    {
        void RegisterAppResources(IServiceCollection services, IConfiguration configuration);
    }
}
