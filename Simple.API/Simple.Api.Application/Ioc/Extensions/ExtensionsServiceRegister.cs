using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Api.Application.Domain.Contracts.Ioc;

namespace Simple.Api.Application.Ioc.Extensions
{

    public static class ExtensionsServiceRegister
    {
        public static void AdicionarRecursosAplicativoNoAssembly(this IServiceCollection sevices, IConfiguration configuration)
        {
            var appServices = typeof(ExtensionsServiceRegister).Assembly.DefinedTypes
                            .Where(x => typeof(IRegisterApiResources)
                            .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .Select(Activator.CreateInstance)
                            .Cast<IRegisterApiResources>().ToList();

            appServices.ForEach(svc => svc.RegisterAppResources(sevices, configuration));
        }
    }
}
