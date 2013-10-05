namespace MVVMSupport.Messenger
{
    /// <summary>
    /// Represents a message that contains an object with data.
    /// </summary>
    /// <typeparam name="TMessageData"></typeparam>
    public class DataMessage<TMessageData> : IMessage
    {
        /// <summary>
        /// Initializes a new instance of DataMessage.
        /// </summary>
        /// <param name="name">The name of the message.</param>
        /// <param name="data">The data associated with the message.</param>
        public DataMessage(string name, TMessageData data)
        {
            Data = data;
            Name = name;
        }

        /// <summary>
        /// Gets the data assocviated with the messsage.
        /// </summary>
        public TMessageData Data { get; private set; }

        /// <summary>
        /// Gets the name of the message.
        /// </summary>
        public string Name { get; private set; }
    }
}
