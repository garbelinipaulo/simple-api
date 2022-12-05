using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Api.Application.Domain.Contracts;
using Simple.Api.Application.Domain.Contracts.Ioc;
using Simple.Api.Application.Domain.Contracts.Repositories;
using Simple.Api.Application.Infra.Repositories;
using Simple.Api.Application.Service;

namespace Simple.Api.Application.Ioc.Register
{
    public class RegisterDependencies : IRegisterApiResources
    { 
        public void RegisterAppResources(IServiceCollection services, IConfiguration configuration)
        {
            /* Repositóries */ 
            services.AddTransient<IMovieRepository, MovieRepository>();

            /* Services */
            services.AddTransient<IMovieService, MovieService>();

            /* Mapper */
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }


}
