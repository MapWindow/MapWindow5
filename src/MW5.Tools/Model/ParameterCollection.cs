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
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared.Log;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;

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

        public IEnumerable<OutputLayerInfo> Outputs
        {
            get { return _list.OfType<OutputLayerParameter>().Select(p => p.Value as OutputLayerInfo); }
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

        public void CleanUp()
        {
            SetCallbackToInputs(null);

            CloseInputDatasources();
        }

        /// <summary>
        /// Clones parameters to the new instance of the GisTool of the same type.
        /// </summary>
        public GisTool Clone()
        {
            var tool = Activator.CreateInstance(_tool.GetType()) as GisTool;

            foreach (var p in _list)
            {
                p.ToolProperty.SetValue(tool, p.Value);
            }

            return tool;
        }

        /// <summary>
        /// Detaches controls from parameters.
        /// </summary>
        public void DetachControls()
        {
            foreach (var p in _list.Where(p => p.Control != null))
            {
                p.Control = null;
            }
        }




        /// <summary>
        /// Sets callback to the input datasource to provide IStopExecution implementation
        /// for MapWinGIS methods.
        /// </summary>
        public void SetCallbackToInputs(IApplicationCallback callback)
        {
            foreach (var p in _list.OfType<LayerParameterBase>())
            {
                var ds = p.Datasource;
                if (ds != null)
                {
                    ds.Callback = callback;
                }
            }
        }

        /// <summary>
        /// Sets default values and list of options to the controls.
        /// </summary>
        public void SetControlDefaults()
        {
            SetOptionsToControls();

            SetControlDefaultsCore();
        }

        /// <summary>
        /// Copies values from controls to the properties of the tool.
        /// </summary>
        public void ApplyControlValues()
        {
            foreach (var p in _list.Where(p => p.Control != null))
            {
                p.SetToolValue(p.Value);
            }
        }

        /// <summary>
        /// Validates the values of parameters and reports errors via message box.
        /// </summary>
        /// <returns>True if no validation errors were found.</returns>
        public bool Validate()
        {
            foreach (var p in _list)
            {
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

        /// <summary>
        /// Closes the input datasources.
        /// </summary>
        internal void CloseInputDatasources()
        {
            foreach (var p in _list.OfType<LayerParameterBase>())
            {
                var info = p.Value as IDatasourceInput;
                if (info != null)
                {
                    p.ClosedPointer = info.Pointer;
                    info.Close();
                }
            }
        }

        /// <summary>
        /// Sets the defaults values to controls. Can be specified as: 
        /// a) attributes, 
        /// b) configuration, 
        /// c) values of the previous run.
        /// </summary>
        private void SetControlDefaultsCore()
        {
            foreach (var p in this)
            {
                var init = p.InitialValue;
                if (init != null && p.Control != null)
                {
                    p.Control.SetValue(init);
                }
            }
        }

        /// <summary>
        /// Sets list of options for OptionsParameter controls.
        /// </summary>
        private void SetOptionsToControls()
        {
            foreach (var p in this)
            {
                var op = p as OptionsParameter;
                if (op == null || op.Options == null)
                {
                    continue;
                }

                var ctrl = op.Control as ComboParameterControl;
                if (ctrl != null)
                {
                    ctrl.SetOptions(op.Options);
                }
            }
        }
    }
}