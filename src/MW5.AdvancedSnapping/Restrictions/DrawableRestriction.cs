using MW5.Api.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace MW5.Plugins.AdvancedSnapping.Restrictions
{
    public abstract class DrawableRestriction : IRestriction
    {
        protected virtual short GuidelineWidth => 1;
        protected virtual Color GuidelineColor => Color.FromArgb(128, Color.DarkOrange);

        #region Properties
        public abstract RestrictionType Type { get; }
        public abstract ICoordinate Anchor { get; set; }
        public abstract double Factor { get; set; }

        protected int DrawingHandle = -1;

        public int Handle
        {
            get; protected set;
        }
        #endregion

        #region Constructor
        public DrawableRestriction(int handle)
        {
            Handle = handle;
        }
        #endregion

        #region Methods
        public virtual void AddDrawingLayer(IMap map)
        {
            DrawingHandle = map.Drawing.AddLayer(Api.Enums.DrawReferenceList.SpatiallyReferencedList);
            DrawGuideline(map);
        }

        public virtual void RemoveDrawingLayer(IMap map)
        {
            map.Drawing.RemoveLayer(DrawingHandle);
        }

        public virtual void RefreshGuideline(IMap map)
        {
            RemoveDrawingLayer(map);
            AddDrawingLayer(map);
        }

        public abstract void DrawGuideline(IMap map);

        public abstract ICoordinate GetSnapPoint(ICoordinate original);

        public abstract IEnumerable<ICoordinate> GetIntersections(IRestriction other);
        public abstract IGeometry ToMapGeometry(IMap map);
        #endregion
    }
}
