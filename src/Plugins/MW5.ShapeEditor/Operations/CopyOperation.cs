using System.Windows.Forms;
using MWLite.ShapeEditor.Operations;

namespace MW5.Plugins.ShapeEditor.Operations
{
    //public class CopyOperation
    //{
    //    private const double SCREEN_OFFSET = 50.0;

    //    private Shapefile _buffer = null;

    //    #region Properties

    //    public bool IsEmpty
    //    {
    //        get { return _buffer == null; }
    //    }

    //    public Shapefile Buffer
    //    {
    //        get { return _buffer; }
    //    }

    //    #endregion

    //    #region Methods

    //    public void Clear()
    //    {
    //        if (_buffer != null)
    //        {
    //            _buffer.Close();
    //            _buffer = null;
    //        }
    //    }

    //    public void Copy(int layerHandle, Shapefile sf)
    //    {
    //        if (sf == null || sf.NumSelected == 0) return;
    //        PopulateBuffer(sf);
    //        OffsetShapes();
    //    }

    //    public bool Cut(int layerHandle, Shapefile sf)
    //    {
    //        if (sf == null || sf.NumSelected == 0) return false;
    //        PopulateBuffer(sf);
    //        RemoveOperation.Remove(sf, layerHandle);
    //        return true;
    //    }

    //    public PasteResult Paste(int layerHandle, Shapefile sf)
    //    {
    //        if (sf == null || IsEmpty) return PasteResult.NoInput;
    //        if (!sf.InteractiveEditing) return PasteResult.NoInput;
    //        if (IsEmpty) return PasteResult.NoInput;

    //        if (_buffer.ShapefileType != sf.ShapefileType) 
    //            return PasteResult.ShapeTypeMismatch;

    //        var fieldMap = _buffer.BuildFieldMap(sf);

    //        var undoList = App.Map.UndoList;
    //        undoList.BeginBatch();

    //        sf.SelectNone();

    //        for (int i = 0; i < _buffer.NumShapes; i++)
    //        {
    //            int shapeIndex = sf.EditAddShape(_buffer.Shape[i].Clone());    // don't create a copy, buffer won't be used any more
    //            _buffer.CopyAttributes(i, sf, shapeIndex, fieldMap);   // TODO: don't use field map for the same shapefile
    //            undoList.Add(tkUndoOperation.uoAddShape, layerHandle, shapeIndex);
    //            sf.ShapeSelected[shapeIndex] = true;
    //        }

    //        undoList.EndBatch();

    //        Clear();
    //        return PasteResult.Ok;
    //    }

    //    #endregion

    //    #region Private methods

    //    private void ShapefileToSystemClipboard(Shapefile sf)
    //    {
    //        string s = ShapefileEx.SerializeForClipboard(sf);
    //        Clipboard.SetText(s);
    //    }

    //    private void PopulateBuffer(Shapefile sf)
    //    {
    //        var buffer = sf.ExportSelection();
    //        Clear();
    //        _buffer = buffer;
    //        ShapefileToSystemClipboard(buffer);
    //    }

    //    private void OffsetShapes()
    //    {
    //        if (IsEmpty) return;
    //        _buffer.OffsetShapes(SCREEN_OFFSET, SCREEN_OFFSET);
    //    }

    //    #endregion
    //}
}
