namespace MW5.Shared.Log
{
    /// <summary>
    /// Represents an interface to be implemented by classes that want to receive 
    /// notifications from long running tasks (primarily from MapWinGIS native method).
    /// </summary>
    public interface IGlobalListener
    {
        /// <summary>
        /// Method to be called to notify the listener about error.
        /// </summary>
        void Error(string tagOfSender, string errorMsg);

        /// <summary>
        /// Method to be called to notify the listener about change of progress.
        /// </summary>
        void Progress(string tagOfSender, int percent, string message);

        /// <summary>
        /// Method to be called to notify the listener that progress should be cleared (hidden).
        /// </summary>
        void ClearProgress();

        /// <summary>
        /// Method to be called to check if the task was aborted by user.
        /// </summary>
        bool CheckAborted();

        /// <summary>
        /// Gets the thread identifier the task is running at.
        /// </summary>
        /// <remarks>Notifications are passed only to listeners with the same thread id.</remarks>
        int ThreadId { get; }

        /// <summary>
        /// Gets a value indicating whether this callback is a main application logger.
        /// </summary>
        bool MainLogger { get; }
    }
}
