// -------------------------------------------------------------------------------------------
// <copyright file="IAttributeExplorer.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Attributes.Views.Abstract
{
    public interface IAttributeExplorer : IView<ILayer>
    {
        event Action ZoomTo;

        event Action CurrentFeatureChanged;

        int CurrentFeatureIndex { get; }
    }
}