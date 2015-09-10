// -------------------------------------------------------------------------------------------
// <copyright file="InputSource.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Tools.Enums;

namespace MW5.Tools.Model.Layers
{
    /// <summary>
    /// Represents a layer added to the map which serves as an input to a certain GIS tool.
    /// </summary>
    internal class LayerInput : IRasterInput, IVectorInput
    {
        private string _filename = string.Empty;
        private string _name = string.Empty;
        private ILayer _layer;

        public LayerInput(ILayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            _layer = layer;
        }

        public IFeatureSet FeatureSet
        {
            get { return Datasource as IFeatureSet; }
        }

        public IRasterSource Raster
        {
            get { return Datasource as IRasterSource; }
        }

        public ILayerSource Datasource
        {
            get { return _layer != null ? _layer.LayerSource : null; }
            set { throw new NotSupportedException(""); }
        }

        IRasterSource IRasterInput.Datasource
        {
            get { return Raster; }
            set { throw new NotSupportedException(""); }
        }

        IFeatureSet IVectorInput.Datasource
        {
            get { return FeatureSet; }
            set { throw new NotSupportedException(""); }
        }

        public bool CloseAfterRun
        {
            get { return false; }
            set { throw new NotSupportedException(""); }
        }

        public string Filename
        {
            get { return _layer != null ? _layer.Filename : _filename; }
        }

        public string Name
        {
            get { return _layer != null ? _layer.Name : _name; }
        }

        /// <summary>
        /// A pointer to datasource holding either identity or layer handler, sufficient to reopen 
        /// the datasource in the future.
        /// </summary>
        public DatasourcePointer Pointer
        {
            get
            {
                if (_layer == null)
                {
                    return null;
                }
                
                if (_layer.LayerType == Api.Enums.LayerType.Shapefile)
                {
                    var fs = _layer.FeatureSet;
                    if (fs.SourceType == Api.Enums.FeatureSourceType.InMemory)
                    {
                        // for in-memory layer we can only save the handle
                        return new DatasourcePointer(_layer.Handle, _layer.Name);
                    }
                }

                return new DatasourcePointer(_layer.Filename);
            }
        }

        /// <summary>
        /// Gets the type of the input.
        /// </summary>
        public InputType InputType 
        {
            get { return InputType.Layer; } 
        }

        /// <summary>
        /// Closes the input layer if CloseAfterRun flag was set.
        /// </summary>
        public void Close()
        {
            // nothing else is needed, it's not our responsibility to cose the layer
            if (_layer != null)
            {
                _filename = _layer.Filename;
                _name = _layer.Name;
                _layer = null;
            }
        }

        public bool SelectedOnly { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
