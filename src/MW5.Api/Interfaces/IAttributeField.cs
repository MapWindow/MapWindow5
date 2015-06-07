using System.ComponentModel;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IAttributeField: IComWrapper
    {
        AttributeType Type { get; }
        string Name { get; set; }
        int Precision { get; }
        int Width { get; }
        bool Visible { get; set; }
        string Alias { get; set; }
        int Index { get; }

        [Browsable(false)]
        string DisplayName { get; }
    }
}
