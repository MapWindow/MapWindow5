// -------------------------------------------------------------------------------------------
// <copyright file="ITemplateView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Model;

namespace MW5.Plugins.Printing.Views.Abstract
{
    internal interface ITemplateView : IView<TemplateModel>
    {
        event Action LayoutSizeChanged;

        event Action FitToPage;

        IEnvelope MapExtents { get; }

        int MapScale { get; }

        Orientation Orientation { get; }

        string PaperFormat { get; }

        LayoutTemplate Template { get; }

        bool IsNewLayout { get; }

        void PopulateScales(int customScale = 0);
    }
}