using MW5.Shared.Log;

namespace MW5.Shared
{
    public class Logger
    {
        private static ILoggingService _logger;

        public static ILoggingService Current
        {
            get { return _logger; }
            internal set { _logger = value; }
        }
    }
}
