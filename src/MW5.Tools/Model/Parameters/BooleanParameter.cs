using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    public class BooleanParameter: BaseParameter
    {
        public bool DefaultValue { get; private set; }

        public override ParameterControlBase CreateControl()
        {
            return Control ?? (Control = new BooleanParameterControl());
        }

        public bool Value
        {
            get { return (bool) Control.AsBase.GetValue(); }
        }
    }
}
