// -------------------------------------------------------------------------------------------
// <copyright file="LayerParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MW5.Api.Interfaces;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The layer parameter.
    /// </summary>
    public class LayerParameter : BaseParameter
    {
        private IEnumerable<ILayer> _layers;

        /// <summary>
        /// Gets the layer control.
        /// </summary>
        /// <value>The layer control.</value>
        public LayerParameterControl LayerControl
        {
            get { return Control as LayerParameterControl; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public ILayer Value
        {
            get { return LayerControl.GetValue() as ILayer; }
        }

        /// <summary>
        /// Create the layer control.
        /// </summary>
        /// <returns>The <see cref="ParameterControlBase" />.</returns>
        public override ParameterControlBase CreateControl()
        {
            return Control ?? (Control = new LayerParameterControl(_layers));
        }

        /// <summary>
        /// Sets the layers.
        /// </summary>
        /// <param name="layers">The layers.</param>
        public void SetLayers(IEnumerable<ILayer> layers)
        {
            if (layers == null)
            {
                throw new ArgumentNullException("layers");
            }

            _layers = layers;
        }
    }
}