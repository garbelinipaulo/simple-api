using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Domain.Contracts.Ioc;
using Product.Application.Domain.Contracts.Notification;
using Product.Application.Domain.Contracts.Repositories;
using Product.Application.Domain.Contracts.Service;
using Product.Application.Domain.Dto.Notification;
using Product.Application.Infra.Repositories;
using Product.Application.Infra.Repositories.Base;
using Product.Application.Service;

namespace Product.Application.Ioc.Registers
{
    public class RegisterDependencies : IRegisterApiResources
    {
        public void RegisterAppResources(IServiceCollection services, IConfiguration configuration)
        {
            /* Repositóries */
            services.AddScoped<IBaseRepository>(c => new BaseRepository(configuration["ConnectionStrings:Conn"]));
            services.AddTransient<IProductRepository, ProductRepository>();
            
            /* Services */
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IFileService, FileService>();


            /*Notificator*/
            services.AddScoped<INotificator, Notificator>();
        }
    }
}
