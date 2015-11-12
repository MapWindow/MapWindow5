using System;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Controls.Parameters.Interfaces;

namespace MW5.Tools.Controls.Parameters.Input
{
    public abstract partial class InputParameterControlBase : ParameterControlBase, IInputParameterControl
    {
        protected IFileDialogService _dialogService;
        protected DataSourceType _dataType;

        /// <summary>
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        public abstract bool BatchMode { get; }

        /// <summary>
        /// Initializes control with the specified data source type.
        /// </summary>
        /// <param name="dataSourceType">Type of the data source.</param>
        /// <param name="dialogService"></param>
        /// <param name="current"></param>
        public virtual void Initialize(DataSourceType dataSourceType, IFileDialogService dialogService, ILayer current)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dataType = dataSourceType;
            _dialogService = dialogService;
        }
    }
}
