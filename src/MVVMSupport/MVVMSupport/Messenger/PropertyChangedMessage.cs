namespace MVVMSupport.Messenger
{
    /// <summary>
    /// Represents a message that updates listeners when a property changes on the sender.
    /// </summary>
    /// <typeparam name="TSender"></typeparam>
    public class PropertyChangedMessage<TSender> : IMessage
    {
        /// <summary>
        /// Initilizes a new instance of PropertyChnagedMessage.
        /// </summary>
        /// <param name="name">The name of the message.</param>
        /// <param name="propertyName">The name of the property associated with the message.</param>
        /// <param name="sender">The sender of the message.</param>
        public PropertyChangedMessage(string name, string propertyName, TSender sender)
        {
            Name = name;
            PropertyName = propertyName;
            Sender = sender;
        }

        /// <summary>
        /// Gets the name of the message.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the property that changed.
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Gets the sender of the message.
        /// </summary>
        public TSender Sender { get; private set; }
    }
}
