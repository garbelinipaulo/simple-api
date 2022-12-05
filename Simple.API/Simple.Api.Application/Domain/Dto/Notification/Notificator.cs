using Simple.Api.Application.Domain.Contracts.Notification;
using System.Diagnostics.CodeAnalysis;

namespace Simple.Api.Application.Domain.Dto.Notification
{
    [ExcludeFromCodeCoverage]
    public class Notificator : INotificator
    {
        public Notificator()
        {
            Notification = new Notification();
        }

        public Notification Notification { get; set; }

        public bool HasNotifications => Notification.Notifications.Any();


        public void AddNotification(string mensagem, short statusCode)
        {
            Notification.Success = false;
            Notification.Notifications.Add(mensagem);
            Notification.StatusCode = statusCode;
        }

        public void AttributeStatusCode(short statusCode)
        {
            Notification.StatusCode = statusCode;
        }

        public void AttributeData(object data)
        {
            Notification.Success = true;
            Notification.Data = data;
        }
    }
}
