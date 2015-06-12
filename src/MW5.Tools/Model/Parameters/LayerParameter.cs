// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayerParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The layer parameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model.Parameters
{
    #region

    using System;
    using System.Collections.Generic;

    using MW5.Api.Interfaces;
    using MW5.Tools.Views.Controls;

    #endregion

    /// <summary>
    /// The layer parameter.
    /// </summary>
    public class LayerParameter : BaseParameter
    {
        #region Fields

        private IEnumerable<ILayer> _layers;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the layer control.
        /// </summary>
        public LayerParameterControl LayerControl
        {
            get
            {
                return Control as LayerParameterControl;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public ILayer Value
        {
            get
            {
                return LayerControl.GetValue() as ILayer;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create control.
        /// </summary>
        /// <returns>
        /// The <see cref="ParameterControlBase"/>.
        /// </returns>
        public override ParameterControlBase CreateControl()
        {
            return Control ?? (Control = new LayerParameterControl(_layers));
        }

        /// <summary>
        /// The set layers.
        /// </summary>
        /// <param name="layers">
        /// The layers.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public void SetLayers(IEnumerable<ILayer> layers)
        {
            if (layers == null)
            {
                throw new ArgumentNullException("layers");
            }

            _layers = layers;
        }

        #endregion
    }
}