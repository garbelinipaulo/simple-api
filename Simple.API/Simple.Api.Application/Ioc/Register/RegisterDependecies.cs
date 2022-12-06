using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Api.Application.Domain.Contracts;
using Simple.Api.Application.Domain.Contracts.Ioc;
using Simple.Api.Application.Domain.Contracts.Notification;
using Simple.Api.Application.Domain.Contracts.Repositories;
using Simple.Api.Application.Domain.Dto.Notification;
using Simple.Api.Application.Infra.Repositories;
using Simple.Api.Application.Infra.Repositories.Base;
using Simple.Api.Application.Service;

namespace Simple.Api.Application.Ioc.Register
{
    public class RegisterDependencies : IRegisterApiResources
    { 
        public void RegisterAppResources(IServiceCollection services, IConfiguration configuration)
        {
            /* Repositóries */
            services.AddScoped<IBaseRepository>(c => new BaseRepository(configuration["ConnectionStrings:Conn"]));
            services.AddTransient<IMovieRepository, MovieRepository>();

            /* Services */
            services.AddTransient<IMovieService, MovieService>();

            /* Mapper */
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
             
            /*Notificator*/
            services.AddScoped<INotificator, Notificator>();

        }
    }


}
