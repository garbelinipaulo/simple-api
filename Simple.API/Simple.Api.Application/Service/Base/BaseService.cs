using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Simple.Api.Application.Service.Base
{
    public class BaseService<T>
    {
        protected readonly ILogger<T> _logger; 
        protected readonly IMapper _mapper;
        protected BaseService(ILogger<T> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
