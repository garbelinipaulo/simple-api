using AutoMapper;
using Microsoft.Extensions.Logging;
using Simple.Api.Application.Domain.Contracts.Notification;

namespace Simple.Api.Application.Service.Base
{
    public class BaseService<T>
    {
        protected readonly ILogger<T> _logger; 
        protected readonly IMapper _mapper;
        protected readonly INotificator _notify;

        protected BaseService(ILogger<T> logger, INotificator notify, IMapper mapper)
        {
            _logger = logger;
            _notify = notify;
            _mapper = mapper;
        }
    }
}
