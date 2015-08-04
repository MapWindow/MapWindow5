// -------------------------------------------------------------------------------------------
// <copyright file="LayerParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Tools.Controls.Parameters;

namespace MW5.Tools.Model.Parameters
{
    public class LayerParameterBase: BaseParameter
    {
        private List<LayerWrapper> _layers;

        /// <summary>
        /// Gets the layer control.
        /// </summary>
        protected LayerParameterControl LayerControl
        {
            get { return Control as LayerParameterControl; }
        }

        public IEnumerable<LayerWrapper> Layers
        {
            get { return _layers; }
        }

        /// <summary>
        /// Sets the layers.
        /// </summary>
        public void Initialize(IEnumerable<ILayer> layers)
        {
            if (layers == null) throw new ArgumentNullException("layers");
            _layers = layers.Select(l => new LayerWrapper(l)).ToList();
        }

        public virtual DataSourceType DataSourceType
        {
            get { return DataSourceType.All;  }
        }
    }

    public class LayerParameterBase<TLayerSource> : LayerParameterBase
        where TLayerSource: class
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        public TLayerSource Value
        {
            get
            {
                var layer = LayerControl.GetValue() as LayerWrapper;
                return layer != null ? layer.Source as TLayerSource : null;
            }
        }

        public bool SelectedOnly
        {
            get
            {
                var layer = LayerControl.GetValue() as LayerWrapper;
                if (layer != null)
                {
                    return layer.SelectedOnly;
                }

                return false;
            }
        }
    }
}