using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Core.Events
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
