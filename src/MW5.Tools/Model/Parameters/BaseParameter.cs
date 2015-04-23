using System;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    public abstract class BaseParameter
    {
        private ParameterControlBase _control;

        public ParameterControlBase Control
        {
            get { return _control; }
            set
            {
                _control = value;
                _control.ValueChanged += _control_ValueChanged;
            }
        }

        public event Action ValueChanged;

        public int Index { get; set; }

        public string DisplayName { get; set; }

        public abstract ParameterControlBase CreateControl();

        private void _control_ValueChanged(object sender, EventArgs e)
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler();
            }
        }
    }
}
