using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Legend;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Views;
using MW5.UI.Helpers;

namespace MW5.Plugins.ShapeEditor.Services
{
    public class LayerEditingService: ILayerEditingService
    {
        private readonly IAppContext _context;

        public LayerEditingService(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        /// <summary>
        /// Toggles interactive editing state for vector layer.
        /// </summary>
        public void ToggleVectorLayerEditing()
        {
            // perhaps better to allow setting state explicitly as parameter
            int handle = _context.Legend.SelectedLayerHandle;
            var fs = _context.Layers.GetFeatureSet(handle);
            var ogrLayer = _context.Layers.GetVectorLayer(handle);

            if (fs != null)
            {
                if (fs.InteractiveEditing)
                {
                    SaveLayerChanges(handle);
                }
                else
                {
                    if (ogrLayer != null)
                    {
                        if (ogrLayer.DynamicLoading)
                        {
                            MessageService.Current.Info("Editing of dynamically loaded OGR layers isn't allowed.");
                            return;
                        }
                        if (!ogrLayer.get_SupportsEditing(SaveType.SaveAll))
                        {
                            MessageService.Current.Info("OGR layer doesn't support editing: " + ogrLayer.LastError);
                            return;
                        }
                    }
                    fs.InteractiveEditing = true;
                }

                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            }
        }

        /// <summary>
        /// Saves changes for the layer with specified handle.
        /// </summary>
        /// <param name="layerHandle">Handle of the layer.</param>
        /// <returns>True on success.</returns>
        public bool SaveLayerChanges(int layerHandle)
        {
            string layerName = _context.Layers.ItemByHandle(layerHandle).Name;

            string prompt = string.Format("Save changes for the layer: {0}?", layerName);
            var result = MessageService.Current.AskWithCancel(prompt);

            switch (result)
            {
                case DialogResult.Yes:
                case DialogResult.No:
                    var sf = _context.Layers.GetFeatureSet(layerHandle);
                    var ogrLayer = _context.Layers.GetVectorLayer(layerHandle);

                    bool save = result == DialogResult.Yes;
                    bool success = false;

                    if (ogrLayer != null)
                    {
                        int savedCount;
                        SaveResult saveResult = ogrLayer.SaveChanges(out savedCount);
                        success = saveResult == SaveResult.AllSaved || saveResult == SaveResult.NoChanges;
                        string msg = string.Format("{0}: {1}; features: {2}", saveResult.EnumToString(), ogrLayer.Name, savedCount);
                        MessageService.Current.Info(msg);
                    }
                    else
                    {
                        success = sf.StopEditingShapes(save, true);
                    }

                    if (success)
                    {
                        sf.InteractiveEditing = false;
                        _context.Map.GeometryEditor.Clear();
                        _context.Map.History.ClearForLayer(layerHandle);
                    }
                    _context.Map.Redraw();
                    return true;
                case DialogResult.Cancel:
                default:
                    return false;
            }
        }

        public void CreateLayer()
        {
            var view = _context.Container.GetSingleton<CreateLayerPresenter>();
            if (view.Run())
            {
                var fs = new FeatureSet(view.GeometryType, view.ZValueType);
                fs.Projection.CopyFrom(_context.Map.GeoProjection);
                fs.SaveAs(view.Filename);
                fs.InteractiveEditing = true;
                _context.Layers.Add(fs);
            }
        }
    }
}
