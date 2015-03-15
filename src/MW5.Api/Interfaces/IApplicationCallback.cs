namespace MW5.Api.Interfaces
{
    public interface IApplicationCallback
    {
        void Error(string tagOfSender, string errorMsg);
        void Progress(string tagOfSender, int percent, string message);
        void ClearProgress();
    }
}
