using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class MeasuringChangedEventArgs: EventArgs
    {
        private readonly _DMapEvents_MeasuringChangedEvent _args;

        internal MeasuringChangedEventArgs(_DMapEvents_MeasuringChangedEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public MeasuringAction Action
        {
            get { return (MeasuringAction)_args.action; }
        }
    }
}
