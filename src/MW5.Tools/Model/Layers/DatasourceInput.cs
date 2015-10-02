using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;

namespace MW5.Tools.Model.Layers
{
    /// <summary>
    /// Darasource which serves as an input for a certain GIS tool.
    /// </summary>
    public class DatasourceInput: IVectorInput, IRasterInput
    {
        private string _filename = string.Empty;

        public DatasourceInput(ILayerSource source)
        {
            if (source == null) throw new ArgumentNullException("source");
            Datasource = source;
        }

        public DatasourceInput(string filename)
        {
            // TODO: datasource must be closed in case of OGR layers
            var identity = new LayerIdentity(filename);
            var ds = GeoSource.OpenFromIdentity(identity);
            Datasource = ds.GetLayers().FirstOrDefault();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the datasource must be closed after the task is completed.
        /// </summary>
        public bool CloseAfterRun
        {
            get {  return true; }
        }

        /// <summary>
        /// Gets or sets the datasource serving as input for GIS task.
        /// </summary>
        IRasterSource IRasterInput.Datasource
        {
            get { return Datasource as IRasterSource; }
            set { throw new NotSupportedException(""); }
        }

        /// <summary>
        /// Gets or sets the datasource serving as input for GIS task.
        /// </summary>
        IFeatureSet IVectorInput.Datasource
        {
            get { return Datasource as IFeatureSet;  }
            set { throw new NotSupportedException(""); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether only selected features of the input layer should be processed.
        /// </summary>
        public virtual bool SelectedOnly { get; set; }

        /// <summary>
        /// Gets or sets the datasource serving as input for GIS task.
        /// </summary>
        public ILayerSource Datasource { get; set; }

        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(Datasource != null ? Datasource.Filename: _filename);  }
        }

        /// <summary>
        /// Gets filename of the datasource.
        /// </summary>
        public string Filename 
        {
            get { return Datasource != null ? Datasource.Filename: _filename; } 
        }

        /// <summary>
        /// A pointer to datasource holding either identity or layer handler, sufficient to reopen 
        /// the datasource in the future.
        /// </summary>
        public DatasourcePointer Pointer 
        {
            get { return new DatasourcePointer(Filename); } 
        }

        /// <summary>
        /// Gets the type of the input.
        /// </summary>
        public InputType InputType 
        {
            get { return InputType.Datasource; } 
        }

        /// <summary>
        /// Closes the input layer if CloseAfterRun flag was set.
        /// </summary>
        public void Close()
        {
            _filename = Datasource.Filename;

            if (CloseAfterRun)
            {
                Datasource.Dispose();
            }

            Datasource = null;
        }

        /// <summary>
        /// Gets the layer handle of the input datasource. If datasource isn't added to the map -1 will be returned.
        /// </summary>
        public int LayerHandle 
        {
            get { return -1; } 
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
