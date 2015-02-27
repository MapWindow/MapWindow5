using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class ShapeValidationFailedEventArgs: EventArgs
    {
        private readonly _DMapEvents_ShapeValidationFailedEvent _args;

        internal ShapeValidationFailedEventArgs(_DMapEvents_ShapeValidationFailedEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public string ErrorMessage
        {
            get { return _args.errorMessage; }
        }
    }
}
