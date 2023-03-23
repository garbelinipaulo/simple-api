using Product.Application.Domain.Contracts.Notification;

namespace Product.Application.Domain.Dto.Notification
{
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
