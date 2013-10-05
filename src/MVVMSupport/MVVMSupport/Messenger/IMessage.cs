namespace MVVMSupport.Messenger
{
    /// <summary>
    /// Identifies a message class.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets the name of the message.
        /// </summary>
        string Name { get; }
    }
}
