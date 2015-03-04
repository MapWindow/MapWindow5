using System;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend
{
    public class LegendLayerCollection : BaseLayerCollection<ILegendLayer>
    {
        private readonly LegendControl _legend;

        internal LegendLayerCollection(AxMap axMap, IMuteLegend legend)
            : base(axMap)
        {
            _legend = legend as LegendControl;
            if (_legend == null)
            {
                throw new NullReferenceException("Invalid legend reference.");
            }
        }

        public override ILegendLayer this[int position]
        {
            get
            {
                if (position >= 0 && position < Count)
                {
                    var layerHandle = _axMap.get_LayerHandle(position);
                    if (layerHandle != -1)
                    {
                        return new LegendLayer(_axMap, _legend, layerHandle);
                    }
                }

                return null;
            }
        }

        public override ILegendLayer ItemByHandle(int layerHandle)
        {
            return new LegendLayer(_axMap, _legend, layerHandle);
        }

        /// <summary>
        /// Gets the position (index) of the specified layer within the group
        /// </summary>
        /// <param name="layerHandle">Handle of the layer</param>
        /// <returns>0-Based Index into list of layers within group, -1 on failure</returns>
        public int PositionInGroup(int layerHandle)
        {
            int layerIndex, groupIndex;

            var lyr = _legend.FindLayerByHandle(layerHandle, out groupIndex, out layerIndex);

            if (lyr != null)
            {
                return layerIndex;
            }

            return -1;
        }

        /// <summary>
        /// Gets the handle of the group containing the specified layer
        /// </summary>
        /// <param name="layerHandle">Handle of the layer</param>
        /// <returns>Group Handle of the group that contains the layer, -1 on failure</returns>
        public int GroupOf(int layerHandle)
        {
            int layerIndex, groupIndex;

            var lyr = _legend.FindLayerByHandle(layerHandle, out groupIndex, out layerIndex);

            if (lyr != null)
            {
                var grp = _legend.Groups[groupIndex];
                return grp.Handle;
            }

            return -1;
        }

        /// <summary>
        /// Move a layer to a specified location within a specified group
        /// </summary>
        /// <param name="layerHandle">Handle to the layer to move</param>
        /// <param name="targetGroupHandle">Handle of the group into which to move the layer</param>
        /// <param name="positionInGroup">0-Based index into the list of layers within the Target Group</param>
        /// <returns>True on success, False otherwise</returns>
        public bool MoveLayer(int layerHandle, int targetGroupHandle, int positionInGroup)
        {
            return _legend.MoveLayer(targetGroupHandle, layerHandle, positionInGroup);
        }

        /// <summary>
        /// Adds a layer to the topmost Group
        /// </summary>
        /// <param name="layerSource"> object to be added as new layer </param>
        /// <param name="visible"> Should this layer to be visible in the map? </param>
        /// <param name="targetGroupHandle"> layerHandle of the group into which this layer should be added </param>
        /// <param name="legendVisible"> Should this layer be visible in the legend? </param>
        /// <param name="afterLayerHandle"> The after Layer handle. </param>
        /// <returns> layerHandle to the Layer on success, -1 on failure </returns>
        public int Add(ILayerSource layerSource, bool visible, int targetGroupHandle, bool legendVisible, int afterLayerHandle = -1)
        {
            var newLayer = layerSource.InternalObject;

            var mapLayerHandle = _axMap.AddLayer(newLayer, visible);
            if (mapLayerHandle < 0)
            {
                return mapLayerHandle;
            }

            _axMap.LockWindow(tkLockMode.lmLock);

            var legendGroups = _legend.Groups as LegendGroups;
            if (legendGroups != null)
            {
                var grp = legendGroups.FindOrCreateGroup(targetGroupHandle) as LegendGroup;

                var lyr = _legend.CreateLayer(mapLayerHandle, newLayer);
                lyr.HideFromLegend = !legendVisible;

                if (grp != null)
                {
                    grp.InsertLayer(afterLayerHandle, lyr);
                }
            }

            if (legendVisible)
            {
                _legend.SelectedLayer = mapLayerHandle;
            }

            _axMap.LockWindow(tkLockMode.lmUnlock);

            _legend.Redraw();
            _legend.FireGroupAdded(mapLayerHandle);

            return mapLayerHandle;
        }

        /// <summary>
        /// Adds a layer to the topmost Group
        /// </summary>
        /// <param name="newLayer"> object to be added as new layer </param>
        /// <param name="visible"> Should this layer to be visible? </param>
        /// <param name="targetGroupHandle"> layerHandle of the group into which this layer should be added </param>
        /// <returns> layerHandle to the Layer on success, -1 on failure </returns>
        public int Add(ILayerSource newLayer, bool visible, int targetGroupHandle)
        {
            return Add(newLayer, visible, targetGroupHandle, true);
        }

        /// <summary>
        /// Adds a layer to the topmost Group
        /// </summary>
        /// <param name="newLayer"> object to be added as new layer </param>
        /// <param name="visible"> Should this layer to be visible? </param>
        /// <returns> layerHandle to the Layer on success, -1 on failure </returns>
        public override int Add(ILayerSource newLayer, bool visible = true)
        {
            return Add(newLayer, visible, -1, true);
        }

        /// <summary>
        /// Adds a layer to the map, optionally placing it above the currently selected layer (otherwise at top of layer list).
        /// </summary>
        /// <param name="newLayer"> The object to add (must be a supported Layer type) </param>
        /// <param name="visible"> Whether or not the layer is visible upon adding it </param>
        /// <param name="placeAboveCurrentlySelected"> Whether the layer should be placed above currently selected layer, or at top of layer list. </param>
        /// <returns> layerHandle of the newly added layer, -1 on failure </returns>
        public int Add(ILayerSource newLayer, bool visible, bool placeAboveCurrentlySelected)
        {
            var mapLayerHandle = Add(newLayer, visible);

            if (!placeAboveCurrentlySelected)
            {
                return mapLayerHandle;
            }

            int selectedLayer = _legend.SelectedLayer;
            if (_legend.SelectedLayer != -1)
            {
                var addPos = PositionInGroup(selectedLayer) + 1;
                var addGrp = GroupOf(selectedLayer);
                MoveLayer(mapLayerHandle, addGrp, addPos);
            }

            return mapLayerHandle;
        }

        public override bool Remove(int layerHandle)
        {
            return _legend.RemoveLayer(layerHandle);
        }

        public override void Clear()
        {
            _legend.ClearLayers();
        }
    }
}