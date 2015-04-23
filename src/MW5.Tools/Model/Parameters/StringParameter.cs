using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    public class StringParameter: BaseParameter
    {
        public string DefaultValue { get; private set; }

        public string Value
        {
            get
            {
                return Control.AsBase.GetValue() as string;
            }
        }

        public override ParameterControlBase CreateControl()
        {
            return Control ?? (Control = new StringParameterControl());
        }
    }
}
