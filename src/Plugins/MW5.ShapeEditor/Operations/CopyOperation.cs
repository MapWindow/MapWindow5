using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Attributes.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Helpers;

namespace MW5.Plugins.ShapeEditor.Operations
{
    internal class CopyOperation
    {
        private readonly IMuteMap _map;
        private const double SCREEN_OFFSET = 50.0;

        private IFeatureSet _buffer;

        public CopyOperation(IMuteMap map)
        {
            if (map == null) throw new ArgumentNullException("map");

            _map = map;
        }

        public bool IsEmpty
        {
            get { return _buffer == null; }
        }

        public IFeatureSet Buffer
        {
            get { return _buffer; }
        }

        public void Clear()
        {
            if (_buffer != null)
            {
                _buffer.Close();
                _buffer = null;
            }
        }

        public void Copy(int layerHandle, IFeatureSet fs)
        {
            if (fs == null || fs.NumSelected == 0) return;
            PopulateBuffer(fs);
            OffsetShapes();
        }

        public bool Cut(int layerHandle, IFeatureSet fs)
        {
            if (fs == null || fs.NumSelected == 0)
            {
                return false;
            }

            PopulateBuffer(fs);
            RemoveOperation.Remove(_map, fs, layerHandle);
            return true;
        }

        public PasteResult Paste(int layerHandle, IFeatureSet fs)
        {
            if (fs == null || IsEmpty || !fs.InteractiveEditing)
            {
                return PasteResult.NoInput;
            }

            if (_buffer.GeometryType != fs.GeometryType)
            {
                return PasteResult.ShapeTypeMismatch;
            }

            var fieldMap = _buffer.Table.BuildFieldMap(fs.Table);

            var history = _map.History;
            history.BeginBatch();

            fs.ClearSelection();

            for (int i = 0; i < _buffer.Features.Count; i++)
            {
                // don't create a copy, buffer won't be used any more
                int shapeIndex = fs.Features.EditAdd(_buffer.Features[i].Geometry.Clone());    

                _buffer.Table.CopyAttributes(i, fs.Table, shapeIndex, fieldMap);   // TODO: don't use field map for the same FeatureSet
                history.Add(UndoOperation.AddShape, layerHandle, shapeIndex);
                fs.Features[i].Selected = true;
            }

            history.EndBatch();

            Clear();
            return PasteResult.Ok;
        }

        private void FeatureSetToSystemClipboard(IFeatureSet fs)
        {
            string s = fs.SerializeForClipboard();
            Clipboard.SetText(s);
        }

        private void PopulateBuffer(IFeatureSet sf)
        {
            var buffer = sf.ExportSelection();
            Clear();
            _buffer = buffer;
            FeatureSetToSystemClipboard(buffer);
        }

        private void OffsetShapes()
        {
            if (IsEmpty) return;
            OffsetShapes(_buffer, SCREEN_OFFSET, SCREEN_OFFSET);
        }

        public void OffsetShapes(IFeatureSet fs, double screenOffsetX, double screenOffsetY)
        {
            double x1, x2, y1, y2;
            _map.PixelToProj(0.0, 0.0, out x1, out y1);
            _map.PixelToProj(screenOffsetX, screenOffsetY, out x2, out y2);
            foreach(var ft in fs.Features)
            {
                ft.Geometry.Move(x2 - x1, y2 - y1);
            }
        }
    }
}
