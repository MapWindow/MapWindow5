using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Api.Legend
{
    public class LegendLayerCollection : BaseLayerCollection<LegendLayer>
    {
        private readonly LegendControl _legend;

        internal LegendLayerCollection(AxMap axMap, LegendControl legend) : base(axMap)
        {
            _legend = legend;
            if (legend == null)
            {
                throw new NullReferenceException("Legend reference is null.");
            }
        }

        public override LegendLayer ItemByHandle(int layerHandle)
        {
            return new LegendLayer(_axMap, layerHandle, _legend);
        }

        public override LegendLayer this[int position]
        {
            get
            {
                if (position >= 0 && position < Count)
                {
                    var layerHandle = _axMap.get_LayerHandle(position);
                    if (layerHandle != -1)
                    {
                        return new LegendLayer(_axMap, layerHandle, _legend);
                    }
                }
                return null;
            }
        }


        /// <summary>
        /// Gets the position (index) of the specified layer within the group
        /// </summary>
        /// <param name="LayerHandle">Handle of the layer</param>
        /// <returns>0-Based Index into list of layers within group, -1 on failure</returns>
        public int PositionInGroup(int LayerHandle)
        {
            int LayerIndex, GroupIndex;

            var lyr = _legend.FindLayerByHandle(LayerHandle, out GroupIndex, out LayerIndex);

            if (lyr != null)
                return LayerIndex;

            return -1;
        }

        /// <summary>
        /// Gets the handle of the group containing the specified layer
        /// </summary>
        /// <param name="LayerHandle">Handle of the layer</param>
        /// <returns>Group Handle of the group that contains the layer, -1 on failure</returns>
        public int GroupOf(int LayerHandle)
        {

            int LayerIndex, GroupIndex;

            var lyr = _legend.FindLayerByHandle(LayerHandle, out GroupIndex, out LayerIndex);

            if (lyr != null)
            {
                var grp = _legend.AllGroups[GroupIndex];
                return grp.Handle;
            }

            return -1;
        }

        /// <summary>
        /// Move a layer to a specified location within a specified group
        /// </summary>
        /// <param name="LayerHandle">Handle to the layer to move</param>
        /// <param name="TargetGroupHandle">Handle of the group into which to move the layer</param>
        /// <param name="PositionInGroup">0-Based index into the list of layers within the Target Group</param>
        /// <returns>True on success, False otherwise</returns>
        public bool MoveLayer(int LayerHandle, int TargetGroupHandle, int PositionInGroup)
        {
            return _legend.MoveLayer(TargetGroupHandle, LayerHandle, PositionInGroup);
        }
    }
}
