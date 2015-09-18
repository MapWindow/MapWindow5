// -------------------------------------------------------------------------------------------
// <copyright file="ToolConfigurationManager.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Services
{
    /// <summary>
    /// Applies configuration values to the parameters. The values are passed to the controls at the later stage.
    /// </summary>
    internal class ToolConfigurationManager
    {
        private ToolConfiguration _config;
        private IEnumerable<BaseParameter> _parameters;

        /// <summary>
        /// Applies configuration values to the parameters.
        /// </summary>
        public void Apply(ToolConfiguration config, IEnumerable<BaseParameter> parameters)
        {
            if (config == null) throw new ArgumentNullException("config");
            if (parameters == null) throw new ArgumentNullException("parameters");

            _config = config;
            _parameters = parameters;

            ApplyDefaults();

            ApplyRanges();

            SetComboLists();
        }

        /// <summary>
        /// Sets default values for parameters.
        /// </summary>
        private void ApplyDefaults()
        {
            foreach (var p in _parameters)
            {
                if (_config.DefaultValues.ContainsKey(p.Name))
                {
                    p.DefaultValue = _config.DefaultValues[p.Name];
                }
            }
        }

        /// <summary>
        /// Sets minimum and maximum values for parameters.
        /// </summary>
        private void ApplyRanges()
        {
            foreach (var p in _parameters.OfType<NumericParameter>())
            {
                if (_config.Ranges.ContainsKey(p.Name))
                {
                    var range = _config.Ranges[p.Name];
                    p.SetRange(range.Min, range.Max);
                }
            }
        }

        /// <summary>
        /// Sets list of options for parameters.
        /// </summary>
        private void SetComboLists()
        {
            foreach (var p in _parameters.OfType<OptionsParameter>())
            {
                if (_config.ComboLists.ContainsKey(p.Name))
                {
                    p.Options = _config.ComboLists[p.Name];
                }
            }
        }
    }
}