using Microsoft.Extensions.Logging;
using Product.Application.Domain.Contracts.Notification; 

namespace Product.Application.Service.Base
{ 

    /// <summary>
    /// This base service allows to inject the logger and the notification pattern that I use for responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T>
    {
        protected readonly ILogger<T> _logger; 
        protected readonly INotificator _notify;

        protected BaseService(ILogger<T> logger, INotificator notify)
        {
            _logger = logger;
            _notify = notify;
        }
    }
}
