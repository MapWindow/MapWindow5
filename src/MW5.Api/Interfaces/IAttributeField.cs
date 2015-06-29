// -------------------------------------------------------------------------------------------
// <copyright file="IAttributeField.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IAttributeField : IComWrapper
    {
        [Browsable(false)]
        string Abbreviation { get; }

        string Alias { get; set; }

        [Browsable(false)]
        string DisplayName { get; }

        [Browsable(false)]
        int Index { get; }

        string Expression { get; set; }

        bool Joined { get; }

        string Name { get; set; }

        int Precision { get; }

        AttributeType Type { get; }

        bool Visible { get; set; }

        int Width { get; }
    }
}