using System;
using System.Drawing;
using AxMapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Events
{
    public class SelectBoxFinalEventArgs: EventArgs
    {
        private Rectangle _bounds;
        private IEnvelope _projectedBounds;
        private readonly Guid _cliendId;

        internal SelectBoxFinalEventArgs(Rectangle bounds, IEnvelope projectedBounds, Guid clientId)
        {
            if (projectedBounds == null) throw new ArgumentNullException("projectedBounds");

            _bounds = bounds;
            _projectedBounds = projectedBounds;
            _cliendId = clientId;
        }

        public Rectangle Bounds
        {
            get { return _bounds; }
        }

        public IEnvelope ProjectedBounds
        {
            get { return _projectedBounds;  }
        }

        public Guid ClientId
        {
            get { return _cliendId; }
        }
    }
}
