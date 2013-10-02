namespace MVVMSupport.ViewModels.ViewModelInterfaces
{
    /// <summary>
    /// Represnts a viewmodel whose view is showable.
    /// </summary>
    public interface IShowableView
    {
        /// <summary>
        /// Notifies clients that the viewmodel requested to be shown.
        /// </summary>
        event ShowViewRequestedHandler ShowViewRequested;
    }

    /// <summary>
    /// Represnts the method that will handle the ShowViewRequested event raised when the viewmodel requests to be shown.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    public delegate void ShowViewRequestedHandler(object sender);
}
