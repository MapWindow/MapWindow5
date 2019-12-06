// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Attributes.Views
{
    public interface IExpressionBuilderModel
    {
        string Expression { get; set; }
        bool IsQuery { get; }
        ILayer Layer { get; }
        TableValueType OutputType { get; }
    }
}