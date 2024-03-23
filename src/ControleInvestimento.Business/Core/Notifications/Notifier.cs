namespace ControleInvestimento.Business.Core.Notifications;

public class Notifier : INotifier
{
    private List<Notification> _notifications;
    public Notifier()
    {
        _notifications = new List<Notification>();
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public bool HasNotification()
    {
        return _notifications.Any();
    }

    public void Handle(Notification notification)
    {
        _notifications.Add(notification);
    }
}
