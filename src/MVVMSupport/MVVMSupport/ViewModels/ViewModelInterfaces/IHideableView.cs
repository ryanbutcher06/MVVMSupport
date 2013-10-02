namespace MVVMSupport.ViewModels.ViewModelInterfaces
{
    /// <summary>
    /// Represents a viewmodel whose view can be hidden.
    /// </summary>
    public interface IHideableView
    {
        /// <summary>
        /// Notifies clients that the viewmodel requested to hide.
        /// </summary>
        event HideViewRequestedHandler HideViewRequested;
    }

    /// <summary>
    /// Represnts the method that will handle the HideViewRequested event raised when a viewmodel requests to be hidden.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    public delegate void HideViewRequestedHandler(object sender);
}
