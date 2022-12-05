using Microsoft.AspNetCore.Mvc;
using Simple.Api.Application.Domain.Contracts.Notification;

namespace Simple.API.Controllers
{
    /// <summary>
    /// Base controller for returns and main methods.
    /// </summary>
    public abstract class BaseController : ControllerBase
    { 
        private readonly INotificator _notify;

        protected BaseController(INotificator notify)
        {
            _notify = notify;
        }

        protected IActionResult RetornoApi<T>(T data)
        {
            dynamic resultado;

            switch (_notify.Notification.StatusCode)
            {
                case StatusCodes.Status200OK:
                    resultado = Ok(data);
                    break;
                case StatusCodes.Status204NoContent:
                    resultado = NoContent();
                    break;
                case StatusCodes.Status400BadRequest:
                case StatusCodes.Status404NotFound:
                    resultado = BadRequest(_notify.Notification);
                    break;
                case StatusCodes.Status401Unauthorized:
                    resultado = Unauthorized();
                    break;
                case StatusCodes.Status403Forbidden:
                    resultado = Forbid();
                    break;
                default:
                    resultado = Ok(data);
                    break;
            }

            if (_notify.HasNotifications)
                return resultado;

            _notify.AttributeData(data);

            return resultado;
        }

    }
}
