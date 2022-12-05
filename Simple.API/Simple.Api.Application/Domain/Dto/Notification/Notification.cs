
namespace Simple.Api.Application.Domain.Dto.Notification
{ 
    public class Notification
    {
        public Notification()
        {
            Notifications = new List<string>();
        }
        public short StatusCode { get; set; }
        public virtual bool Success { get; set; }
        public virtual List<string> Notifications { get; set; }
        public virtual object Data { get; set; }
    }
}
