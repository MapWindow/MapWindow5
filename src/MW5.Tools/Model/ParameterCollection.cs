// -------------------------------------------------------------------------------------------
// <copyright file="ParameterCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MW5.Plugins.Services;
using MW5.Shared.Log;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Holds list of parameters for the tool.
    /// </summary>
    public class ParameterCollection : IEnumerable<BaseParameter>
    {
        private readonly List<BaseParameter> _list;
        private readonly GisTool _tool;

        public ParameterCollection(GisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            _tool = tool;
            _list = tool.CreateParameters().ToList();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<BaseParameter> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Clears callbacks and closes inputs datasources.
        /// </summary>
        public void CleanUp()
        {
            this.SetCallbackToInputs(null);

            this.CloseInputDatasources();
        }

        /// <summary>
        /// Validates the values of parameters and reports errors via message box.
        /// </summary>
        /// <returns>True if no validation errors were found.</returns>
        public bool Validate()
        {
            foreach (var p in _list)
            {
                var projection = p as GeoProjectionParameter;
                if (projection != null)
                {
                    if (projection.Value == null)
                    {
                        MessageService.Current.Info("Invalid or empty projection.");
                        return false;
                    }
                }

                var layerParameter = p as GenericLayerParameter;
                if (layerParameter != null)
                {
                    if (layerParameter.Datasource == null)
                    {
                        MessageService.Current.Info("Input datasource isn't selected.");
                        return false;
                    }
                }

                var outputParameter = p as OutputLayerParameter;
                if (outputParameter != null)
                {
                    string errorMessage;
                    if (!outputParameter.GetValue().Validate(out errorMessage))
                    {
                        MessageService.Current.Info(errorMessage);
                        return false;
                    }
                }

                var value = p as ISupportsValidation;
                if (value != null)
                {
                    string errorMessage;
                    if (!value.Validate(out errorMessage))
                    {
                        MessageService.Current.Info(errorMessage);
                        return false;
                    }
                }

                var field = p as FieldParameter;
                if (field != null)
                {
                    if ((int)field.Value == -1)
                    {
                        MessageService.Current.Info(p.Name + " parameter is empty.");
                        return false;
                    }
                }

                var fileParameter = p as FilenameParameter;
                if (fileParameter != null)
                {
                    string filename = fileParameter.Value as string;

                    if (string.IsNullOrWhiteSpace(filename))
                    {
                        MessageService.Current.Info("Input filename isn't specified: " + p.Name);
                        return false;
                    }

                    if (!File.Exists(filename))
                    {
                        MessageService.Current.Info("Input filename doesn't exist: " + filename);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}