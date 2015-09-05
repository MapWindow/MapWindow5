// -------------------------------------------------------------------------------------------
// <copyright file="VectorStylePresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Forms;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Projections.UI.Forms;
using MW5.Services.Serialization;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Views
{
    public class VectorStylePresenter : ComplexPresenter<IVectorStyleView, VectorStyleCommand, ILegendLayer>
    {
        private readonly IAppContext _context;

        public VectorStylePresenter(IVectorStyleView view, IAppContext context )
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            view.UpdateSpatialIndex += CreateSpatialIndex;
            view.ModifyCharts += () => RunCommand(VectorStyleCommand.ChartAppearance);
            view.ModifyLabels += () => RunCommand(VectorStyleCommand.LabelAppearance);
        }

        private IFeatureSet FeatureSet
        {
            get { return Model.FeatureSet; }
        }

        private IWin32Window ViewAsParent
        {
            get { return View as IWin32Window; }
        }

        public override void RunCommand(VectorStyleCommand command)
        {
            switch (command)
            {
                case VectorStyleCommand.ClearVisibilityExpression:
                    FeatureSet.VisibilityExpression = "";
                    View.UpdateView();
                    break;
                case VectorStyleCommand.ChangeVisibilityExpression:
                    string s = FeatureSet.VisibilityExpression;
                    if (FormHelper.ShowQueryBuilder(_context, Model, ViewAsParent, ref s, false))
                    {
                        FeatureSet.VisibilityExpression = s;
                        View.UpdateView();
                    }
                    break;
                case VectorStyleCommand.ClearLabels:
                    if (MessageService.Current.Ask("Do you want to remove labels?"))
                    {
                        FeatureSet.Labels.Items.Clear();
                        FeatureSet.Labels.Expression = "";
                    }
                    View.RefreshLabels();
                    break;
                case VectorStyleCommand.LabelAppearance:
                    using (var form = new LabelStyleForm(_context, Model))
                    {
                        _context.View.ShowChildView(form, ViewAsParent);
                    }
                    View.RefreshLabels();
                    break;
                case VectorStyleCommand.ClearCharts:
                    if (MessageService.Current.Ask("Do you want to remove charts?"))
                    {
                        FeatureSet.Diagrams.Fields.Clear();
                        FeatureSet.Diagrams.Clear();
                    }
                    View.RefreshCharts();
                    break;
                case VectorStyleCommand.OpenLocation:
                    string filename = Model.Filename;
                    if (!string.IsNullOrWhiteSpace(filename))
                    {
                        PathHelper.OpenFolderWithExplorer(filename);
                    }
                    else
                    {
                        MessageService.Current.Info("Can't find the datasource.");
                    }
                    break;
                case VectorStyleCommand.SaveStyle:
                    LayerSerializationHelper.SaveSettings(Model);
                    break;
                case VectorStyleCommand.RemoveStyle:
                    LayerSerializationHelper.RemoveSettings(Model, false);
                    break;
                case VectorStyleCommand.ProjectionDetails:
                    using (var form = new ProjectionPropertiesForm(Model.Projection))
                    {
                        _context.View.ShowChildView(form);
                    }
                    break;
                case VectorStyleCommand.ChartsEditColorScheme:
                    FormHelper.EditColorSchemes(_context, SchemeTarget.Charts, ViewAsParent);
                    break;
                case VectorStyleCommand.ChartAppearance:
                    using (var form = new ChartStyleForm(_context, Model))
                    {
                        _context.View.ShowChildView(form, ViewAsParent);
                    }
                    View.RefreshCharts();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }

        private void CreateSpatialIndex()
        {
            var spatialIndex = FeatureSet.SpatialIndex;

            if (!View.SpatialIndex)
            {
                spatialIndex.UseDiskIndex = false;
                return;
            }

            if (spatialIndex.DiskIndexExists)
            {
                spatialIndex.UseDiskIndex = true;
                return;
            }

            if (!spatialIndex.DiskIndexExists)
            {
                View.LockView();
                try
                {
                    bool result = spatialIndex.CreateDiskIndex();
                    if (result)
                    {
                        MessageService.Current.Info("Spatial index was successfully created.");
                    }
                    else
                    {
                        MessageService.Current.Warn("Failed to create spatial index");
                    }
                }
                finally
                {
                    View.UnlockView();
                }
            }
        }
    }
}