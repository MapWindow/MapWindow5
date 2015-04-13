namespace MW5.Shared.Log
{
    public interface IApplicationCallback
    {
        void Error(string tagOfSender, string errorMsg);
        void Progress(string tagOfSender, int percent, string message);
        void ClearProgress();
    }
}
