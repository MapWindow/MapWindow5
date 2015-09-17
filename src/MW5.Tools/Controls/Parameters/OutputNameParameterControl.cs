// -------------------------------------------------------------------------------------------
// <copyright file="StringParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Controls.Parameters
{
    public partial class OutputNameParameterControl : StringParameterControl, IOuputputParameterControl
    {
        private readonly bool _batchMode;
        private string _templateName = string.Empty;
        private string _inputFilename = string.Empty;

        public OutputNameParameterControl(bool batchMode)
            : base(false)
        {
            _batchMode = batchMode;
        }

        public override void SetValue(object value)
        {
            var s = Convert.ToString(value);
            _templateName = s;
            RefreshName();
        }
        
        public void SetExtension(string extension)
        {
            // not needed
        }

        public void OnFilenameChanged(string filename)
        {
            _inputFilename = Path.GetFileNameWithoutExtension(filename);
            RefreshName();
        }

        public void OnDatasourceChanged(IDatasourceInput input)
        {
            _inputFilename = input.Name;
            RefreshName();
        }

        private void RefreshName()
        {
            if (_batchMode)
            {
                textBoxExt1.Text = _templateName;
            }
            else
            {
                textBoxExt1.Text = _templateName.Replace(TemplateVariables.Input, _inputFilename);
            }
        }
    }
}