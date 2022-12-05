namespace Simple.Api.Application.Domain.Contracts.Notification
{
    public interface INotificator
    {
        Simple.Api.Application.Domain.Dto.Notification.Notification Notification { get; set; }
        bool HasNotifications { get; }
        void AddNotification(string mensagem, short statusCode);
        void AttributeStatusCode(short statusCode);
        void AttributeData(object data);
    }
}
