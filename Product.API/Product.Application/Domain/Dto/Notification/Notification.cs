namespace Product.Application.Domain.Dto.Notification
{

    /// <summary>
    /// This class is used by responses in the base controller, just for pattern
    /// </summary>
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
