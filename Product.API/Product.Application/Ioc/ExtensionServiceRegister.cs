using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Domain.Contracts.Ioc;

namespace Product.Application.Ioc
{
    /// <summary>
    /// This class is used to register injections of dependents service, just for clean pattern
    /// </summary>
    public static class ExtensionsServiceRegister
    {
        public static void AddResourcesList(this IServiceCollection sevices, IConfiguration configuration)
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
