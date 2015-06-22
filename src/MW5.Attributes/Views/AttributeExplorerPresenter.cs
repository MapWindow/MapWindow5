// -------------------------------------------------------------------------------------------
// <copyright file="AttributeExplorerPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Linq;
using MW5.Api.Interfaces;
using MW5.Attributes.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;

namespace MW5.Attributes.Views
{
    public class AttributeExplorerPresenter : BasePresenter<IAttributeExplorer, ILayer>
    {
        private readonly IAppContext _context;

        public AttributeExplorerPresenter(IAttributeExplorer view, IAppContext context)
            : base(view)
        {
            _context = context;
            View.ZoomTo += ViewZoomTo;
            View.CurrentFeatureChanged += OnCurrentFeatureChanged;
        }

        private void OnCurrentFeatureChanged()
        {
            int index = View.CurrentFeatureIndex - 1;

            var feature = Model.FeatureSet.Features.Where(ft => ft.Selected).Skip(index).FirstOrDefault();
            if (feature != null)
            {
                _context.Map.ZoomToShape(Model.Handle, feature.Index);
            }
        }

        private void ViewZoomTo()
        {
            _context.Map.ZoomToSelected(Model.Handle);
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}