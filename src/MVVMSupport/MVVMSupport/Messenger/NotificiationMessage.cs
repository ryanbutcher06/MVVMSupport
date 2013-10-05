namespace MVVMSupport.Messenger
{
    /// <summary>
    /// Represnts a message that will send data between classes registed to the messenger.
    /// </summary>
    public class NotificiationMessage : IMessage
    {
        /// <summary>
        /// Initialize a new instance of NotificationMessage.
        /// </summary>
        /// <param name="name">The name of the message.</param>
        /// <param name="notification">The notification associated with the message.</param>
        public NotificiationMessage(string name, string notification)
        {
            Notifiction = notification;
            Name = name;
        }

        /// <summary>
        /// Gets the notification associated with the message.
        /// </summary>
        public string Notifiction { get; private set; }

        /// <summary>
        /// Gets the name of the messsage.
        /// </summary>
        public string Name { get; private set; }
    }
}
