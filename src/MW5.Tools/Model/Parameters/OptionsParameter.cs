using System.Collections.Generic;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    public class OptionsParameter<T>: BaseParameter
    {
        private IEnumerable<T> _options;

        public IEnumerable<T> Options
        {
            get { return _options; }
            set
            {
                _options = value;
                var control = (Control as ComboParameterControl);
                if (control != null)
                {
                    control.SetOptions(Options);
                }
            }
        }

        public T Value
        {
            get
            {
                var control = Control as ComboParameterControl;
                if (control != null)
                {
                    var value = control.GetValue();
                    if (value != null)
                    {
                        return (T)value;
                    }
                }

                return default(T);
            }
        }

        public override ParameterControlBase CreateControl()
        {
            if (Control == null)
            {
                var control = new ComboParameterControl() { ButtonVisible = false };
                control.SetOptions(_options);  // ensure that previously specified options are applied
                Control = control;
            }

            return Control;
        }
    }
}
