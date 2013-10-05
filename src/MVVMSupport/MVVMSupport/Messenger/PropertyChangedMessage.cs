namespace MVVMSupport.Messenger
{
    /// <summary>
    /// Represents a message that updates listeners when a property changes on the sender.
    /// </summary>
    /// <typeparam name="TSender"></typeparam>
    public class PropertyChangedMessage<TSender> : IMessage
    {
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
